using UnityEngine;

public class pieges : MonoBehaviour

{
    public bool isInRange = false;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* On regarde si l'objet qui entre en contact avec la zone de piegen et on démarre l'anim */
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            animator.SetBool("isInRange", isInRange);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        /* On regarde si l'objet quitte la zone du piege et on arrête l'anim */
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            animator.SetBool("isInRange", isInRange);
        }

    }
}
