using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed; /* vitesse de d�placement de l'ennemi */
    public Transform[] waypoints; /* liste de points vers lesquels l'ennemi doit se d�placer */

    private Transform target; /* Cible vers laquelle l'ennemi va se d�placer */
    private int destPoint = 0; /* le point de destination, sorte d'index */

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

    /* Dans quelle direction faut-il d�placer l'ennemi ? */
    Vector3 dir = target.position - transform.position;

        /* d�placement de l'ennemi */
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        /* Si l'ennemi est quasiment arriv� � sa destination */
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }

    }

}

