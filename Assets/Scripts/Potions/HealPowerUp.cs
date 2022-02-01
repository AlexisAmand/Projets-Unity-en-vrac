
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healthpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Player"))
        {

            /* g�n�ration d'un nombre entre 0 et 20 pour une quantit� de points de vie al�atoire */
            healthpoint = Random.Range(5, 25);
            Debug.LogWarning("Le joueur a r�pup�r� " + healthpoint + "Points de vie");

            if (PlayerHealth.Instance.currentHealth != PlayerHealth.Instance.maxHealth)
            {
                // rendre de la vie au joueur
                PlayerHealth.Instance.HealPlayer(healthpoint);
                // mettre � jour de dessin
                Destroy(gameObject);
            }
        }
    }

}
