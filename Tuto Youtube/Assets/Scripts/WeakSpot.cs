using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;

    /* fonction lue quand un objet rentre dans le weakspot */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* On va regarder que c'est bien le joueur qui entre */
        /* Si oui, on détruit l'ennemi */
        if(collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }

}
