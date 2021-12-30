using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;  /* vitesse de déplacement du Player */
    public float jumpForce;  

    private bool isJumping; /* à true si le joueur est en train de sauter */
    private bool isGrounded; /* à true si le joueur touche le sol */

    /* bornes d'une ligne sous le perso, elle detecte la collision du perso avec le sol */
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb; /* fait référence au Rigidbody du Player */
    public Animator animator; /* fait référence à l'animator */
    public SpriteRenderer SpriteRenderer;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        /* Création d'une zone entre les deux bornes */
        /* Si la zone touche qqch, isGrounded prend la valeur true */
        /* Si la zone touche rien, isGrounded prend la valeur false */
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        /* Calcul du mvnt : Quel direction et quelle vitesse ? */
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        /* on bouge le perso ! */
        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        /* envoie de la vitesse à l'animator */
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
            
    }

    /* Méthode qui bouge le perso */

    void MovePlayer(float _horizontalMovement)
    {
        /* vers quelle direction va le perso ? */
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);

        /* on fait le mouvement du perso */
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        /* si le joueur à demander un saut, on ajoute une force au mvnt */
        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false; /* Après le saut... on est plus en train de sauter */
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

}
