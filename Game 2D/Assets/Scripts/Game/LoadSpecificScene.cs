using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
    
{

    public string sceneName;
    public Animator fadeSystem;


    /* Gestion de l'ouverture de la porte */
    public Sprite sprite1; // porte fermée
    public Sprite sprite2; // porte ouverte
    public bool DoorClosed = true; // Elle est fermée ou ouverte ? Par défaut elle est fermée.
    private SpriteRenderer spriteRenderer; /* On récupére le spriterenderer pour pouvoir modifier le sprite tout à l'heure */

    public int CoinsGoal; /* Nombre de coins à trouver dans le niveau. Valeur à completer dans Unity */

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Accès au SpriteRenderer de l'objet      
    }

    void Update()
    {

        if (Inventory.Instance.coinsCount == CoinsGoal) /* Si toutes les pieces sont ramassées */
        {
            ChangeSprite2(); // On appelle la méthode qui change le Sprite
        }

    }

    void ChangeSprite2()
    {

        spriteRenderer.sprite = sprite2; /* On remplace le sprite */
        DoorClosed = false; /* La porte est maintenant ouverte */

    }

    private void Awake()
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
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}
