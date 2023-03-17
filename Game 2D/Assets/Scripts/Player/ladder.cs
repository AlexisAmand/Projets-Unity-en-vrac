using UnityEngine.UI;
using UnityEngine;

public class ladder : MonoBehaviour
{
    /* le perso est-il a port� de l'echelle ? */
    private bool isInRange;
    private PlayerMovement playerMovement;
    /* R�f�rence � la plate forme en haut de l'�chelle */
    public BoxCollider2D topCollider;

    public Text interactUI;
    

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            /* descendre de l'echelle */
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true; 
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* On regarde si l'objet qui entre en contact avec l'�chelle est bien le player */
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            /* Le player est donc � proximit� de l'�chelle */
            isInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        /* On regarde si l'objet qui s'�loigne de l'�chelle est bien le player */
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            /* Le player n'est donc plus � proximit� de l'�chelle */
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
        }

    }
}
