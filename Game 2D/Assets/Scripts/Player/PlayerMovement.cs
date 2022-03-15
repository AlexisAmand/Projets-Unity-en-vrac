                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;  /* vitesse de d�placement du Player */
    public float climbSpeed;  /* vitesse de d�placement du Player */
    public float jumpForce;  

    private bool isJumping; /* � true si le joueur est en train de sauter */
    private bool isGrounded; /* � true si le joueur touche le sol */
    [HideInInspector]
    public bool isClimbing; /* � true si le joueur est en train de grimper */

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb; /* fait r�f�rence au Rigidbody du Player */
    public Animator animator; /* fait r�f�rence � l'animator */
    public SpriteRenderer SpriteRenderer;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;

    private float horizontalMovement;
    private float verticalMovement;

    public static PlayerMovement Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la sc�ne");
            return;
        }

        Instance = this;
    }

    void Update()
    {

        /* Calcul du mvnt : Quel direction et quelle vitesse ? */
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        /* envoie de la vitesse � l'animator */
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        /* envoie � l'animator si le perso est en train de monter ou descendre */
        animator.SetBool("isClimbing", isClimbing);

    }

    void FixedUpdate()
    {

        /* Cr�ation d'une zone entre les deux bornes */
        /* Si la zone touche qqch, isGrounded prend la valeur true */
        /* Si la zone touche rien, isGrounded prend la valeur false */
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        /* on bouge le perso ! */
        MovePlayer(horizontalMovement, verticalMovement);     

    }

    /* M�thode qui bouge le perso */

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        /* si le joueur n'est pas en train de grimper, il peut aller vers la droite, la gauche et sauter */
        if (!isClimbing)
        {
            /* vers quelle direction va le perso ? */
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);

            /* on fait le mouvement du perso */
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            /* si le joueur � demander un saut, on ajoute une force au mvnt */
            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false; /* Apr�s le saut... on est plus en train de sauter */
            }
        } else
        {

            /* vers quelle direction va le perso ? */
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);

            /* on fait le mouvement du perso */
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        }

    }

    void Flip(float _velocity)
    {

        /* On tourne le perso dans le bon sens, selon si il va vers la droite ou vers la gauche */
        if (_velocity > 0.1f)
        {
            SpriteRenderer.flipX = false;
        } else if (_velocity < -0.1f)
            {
            SpriteRenderer.flipX = true;
            }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
