using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{

    public float speed; /* vitesse de d�placement de l'ennemi */
    public Transform[] waypoints; /* liste de points vers lesquels l'ennemi doit se d�placer */

    public int damageOnCollision = 20; /* Quantit� de d�gats de la part d'un ennemi */

    public SpriteRenderer graphics; /* fait r�f�rence � la partie graphique de l'ennemi */
    private Transform target; /* Cible vers laquelle l'ennemi va se d�placer */
    private int destPoint = 0; /* le point de destination, sorte d'index */

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

            /* le personne se tourne vers la direction o� il va */
            graphics.flipX = !graphics.flipX;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth   = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }


}
