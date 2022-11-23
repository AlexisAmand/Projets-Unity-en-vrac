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
            /* Le pont s'écroule */

            foreach (GameObject planche in planches)
            {
                planche.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }

            /* le player prend un peu de dégats */

            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }

}
