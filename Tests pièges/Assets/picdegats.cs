using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picdegats : MonoBehaviour

{
    public int damage = 50; /* Quantit� de d�gats */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
