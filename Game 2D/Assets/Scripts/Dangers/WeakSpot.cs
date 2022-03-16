using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;

    /* son quand on tue un ennemi */
    public AudioClip killSound;

    /* nombre de pi�ces re�ues quand on tue un ennemi */
    private int killCoins = 5;

    /* fonction lue quand un objet rentre dans le weakspot */
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // on joue le son
        AudioManager.Instance.PlayClipAt(killSound, transform.position);

        /* On va regarder que c'est bien le joueur qui entre */
        /* Si oui, on d�truit l'ennemi */

        if (collision.CompareTag("Player"))
        {

            // on ajoute 5 pieces � l'inventaire comme r�compense

            Inventory.Instance.AddCoins(killCoins);
            CurrentSceneManager.Instance.coinsPickedUpInThisSceneCount++;
   
            Destroy(objectToDestroy);
        }

    }

}
