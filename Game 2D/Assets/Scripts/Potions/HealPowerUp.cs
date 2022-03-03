
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healthpoint;

    /* son pour la vie en + */
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Player"))
        {

            /* g�n�ration d'un nombre entre 0 et 20 pour une quantit� de points de vie al�atoire */
            healthpoint = Random.Range(5, 25);
            Debug.LogWarning("Le joueur a r�pup�r� " + healthpoint + "Points de vie");

            if (PlayerHealth.Instance.currentHealth != PlayerHealth.Instance.maxHealth)
            {
                // on joue le son
                AudioManager.Instance.PlayClipAt(pickupSound, transform.position);
                // rendre de la vie au joueur
                PlayerHealth.Instance.HealPlayer(healthpoint);
                // mettre � jour de dessin
                Destroy(gameObject);
            }
        }
    }

}
