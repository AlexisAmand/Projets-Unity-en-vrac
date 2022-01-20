
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healthpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.Instance.currentHealth != PlayerHealth.Instance.maxHealth)
            {
                // rendre de la vie au joueur
                PlayerHealth.Instance.HealPlayer(healthpoint);
                Destroy(gameObject);
            }
        }
    }

}
