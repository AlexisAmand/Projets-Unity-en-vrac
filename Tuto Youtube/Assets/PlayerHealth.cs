using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100; /* par defaut, on a 100 point de vie */
    public int currentHealth;  /* via actuelle */

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; /* nouvelle valeur du nbre de pts de vie */
        healthBar.SetHealth(currentHealth); /* mise à jour du visuel */

    }
}
