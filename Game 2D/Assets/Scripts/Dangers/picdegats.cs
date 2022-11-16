// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class picdegats : MonoBehaviour

{
    public int picDamage = 15; /* Quantit� de d�gats */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(picDamage);
            Debug.Log("Ouuuh �a pique les fesses !");
        }
    }
}
