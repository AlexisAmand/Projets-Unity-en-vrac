using UnityEngine;

public class FireDamage : MonoBehaviour
{

    public int damageIfFire = 5; /* Quantit� de d�gats si perso tombe dans le feu */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageIfFire);
        }
    }

}
