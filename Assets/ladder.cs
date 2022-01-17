using UnityEngine;

public class ladder : MonoBehaviour
{
    /* le perso est-il a porté de l'echelle ? */
    private bool isInRange;
    private PlayerMovement playerMovement;
    /* Référence à la plate forme en haut de l'échelle */
    public BoxCollider2D collider;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            collider.isTrigger = true; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* On regarde si l'objet qui entre en contact avec l'échelle est bien le player */
        if (collision.CompareTag("Player"))
        {
            /* Le player est donc à proximité de l'échelle */
            isInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /* On regarde si l'objet qui s'éloigne de l'échelle est bien le player */
        if (collision.CompareTag("Player"))
        {
            /* Le player n'est donc plus à proximité de l'échelle */
            isInRange = false;
            playerMovement.isClimbing = false;
            collider.isTrigger = false;
        }
    }
}
