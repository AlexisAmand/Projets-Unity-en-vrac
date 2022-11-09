using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSpecificScene : MonoBehaviour
    
{

    public string sceneName;
    public Animator fadeSystem;

    /* Gestion de l'ouverture de la porte */
    public Sprite sprite1; // porte ferm�e
    public Sprite sprite2; // porte ouverte
    public bool DoorClosed = true; // Elle est ferm�e ou ouverte ? Par d�faut elle est ferm�e.
    private SpriteRenderer spriteRenderer; /* On r�cup�re le spriterenderer pour pouvoir modifier le sprite tout � l'heure */

    public int CoinsGoal; /* Nombre de coins � trouver dans le niveau. Valeur � completer dans Unity */

    /* Son qui indique qu'on change de niveau */
    // public AudioClip levelEnd;
    /* Son qui indique que la porte s'ouvre */
    // public AudioClip doorOpen;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Acc�s au SpriteRenderer de l'objet      
    }

    void Update()
    {

        if (Inventory.Instance.coinsCount == CoinsGoal) /* Si toutes les pieces sont ramass�es */
        {
            ChangeSprite2(); // On appelle la m�thode qui change le Sprite
        }

    }

    void ChangeSprite2()
    {
        /* On joue le son qui indique que la porte s'ouvre */
        // AudioManager.Instance.PlayClipAt(doorOpen, transform.position);

        /* On change le sprite pour la version "porte ouverte */
        spriteRenderer.sprite = sprite2; /* On remplace le sprite */
        DoorClosed = false; /* La porte est maintenant ouverte */
    }

    void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.CompareTag("Player")) && (DoorClosed == false))
        {
            StartCoroutine(loadNextScene());
        }
        
    }

    public IEnumerator loadNextScene()
    {
        /* On joue le son du changement de sc�ne */
        // AudioManager.Instance.PlayClipAt(levelEnd, transform.position);

        fadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}
