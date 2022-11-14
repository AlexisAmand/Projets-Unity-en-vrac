using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour

{

    /* liste de gameobject et ensuite une sorte de foreach element in the list */

    //public GameObject planche01;
    //public GameObject planche02;
    //public GameObject planche03;
    //public GameObject planche04;
    //public GameObject planche05;
    //public GameObject planche06;
    //public GameObject planche07;
    //public GameObject planche08;

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

            /*
            planche01.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche02.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche03.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche04.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche05.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche06.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche07.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            planche08.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            */

            /* le player prend un peu de dégats */
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }

}
