using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour

{

    /* liste de gameobject et ensuite une sorte de foreach element in the list */

    public GameObject[] planches;

    public int damage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            /* Le pont s'�croule */

            foreach (GameObject planche in planches)
            {
                planche.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }

            /* le player prend un peu de d�gats */

            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);

            /* le nombre de d�gat devient 0 */
            /* �a corrige un bug qui donnait des d�gats quand le joueur arrive � l'emplacement du pont */

            damage = 0;
            
        }
    }

}
