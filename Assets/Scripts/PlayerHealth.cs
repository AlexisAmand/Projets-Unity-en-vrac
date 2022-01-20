using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100; /* par defaut, on a 100 point de vie */
    public int currentHealth;  /* via actuelle */

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false; /* par defaut, le perso n'est pas invinsible */

    public SpriteRenderer graphics; /* fait r�f�rence au dessin du player */
    public HealthBar healthBar;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la sc�ne");
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
            TakeDamage(60);
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
        /* Si le perso n'est pas invinsible, il subit des d�gats */

        if (!isInvincible)
        {
            currentHealth -= damage; /* nouvelle valeur du nbre de pts de vie */
            healthBar.SetHealth(currentHealth); /* mise � jour du visuel */

            // v�rifier si le joueur est toujours vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash()); /* coroutine : clignote car invinsible */
            StartCoroutine(HandleInvincibilityDelay()); /* coroutine : dur�e qu'il clignote car invinsible */
        }

    }

    public void Die()
    {
        Debug.Log("Le joueur est �limin�");

        /* on bloque les mouvements du perso en bloquant le script PlayerMovement.cs */
        PlayerMovement.Instance.enabled = false;

        /* jouer l'animation d'�limination */
        PlayerMovement.Instance.animator.SetTrigger("Die");

        // emp�cher les interactions avec les �l�ments de la sc�ne
        PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.Instance.playerCollider.enabled = false;

        // on appelle la m�thode qui affiche le menu
        GameOverManager.Instance.OnPlayerDeath();

    }

    public void Respawn()
    {

        /* on restaure les mouvements du perso en bloquant le script PlayerMovement.cs */
        PlayerMovement.Instance.enabled = true;

       
        PlayerMovement.Instance.animator.SetTrigger("Respawn");

        // on restaure les interactions avec les �l�ments de la sc�ne
        PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.Instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

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
