using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100; /* par defaut, on a 100 point de vie */
    public int currentHealth;  /* via actuelle */

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false; /* par defaut, le perso n'est pas invinsible */

    public SpriteRenderer graphics; /* fait référence au dessin du player */
    public HealthBar healthBar;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        Instance = this;
    }

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

    public void HealPlayer (int amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        /* Si le perso n'est pas invinsible, il subit des dégats */

        if (!isInvincible)
        {
            currentHealth -= damage; /* nouvelle valeur du nbre de pts de vie */
            healthBar.SetHealth(currentHealth); /* mise à jour du visuel */
            isInvincible = true;
            StartCoroutine(InvincibilityFlash()); /* coroutine : clignote car invinsible */
            StartCoroutine(HandleInvincibilityDelay()); /* coroutine : durée qu'il clignote car invinsible */
        }

    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
