using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject levelTitle;

    /* Spawnage du player, on en profite pour afficher le titre du niveau via une coroutine */
    public void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        StartCoroutine(showLeveLTitle());
    }

    /* Coroutine qui affiche le titre du niveau pendant 3 secondes */
    /* Note : le titre est la prefab welcome */

    IEnumerator showLeveLTitle()
    {
        levelTitle.SetActive(true);
        yield return new WaitForSeconds(3f);
        levelTitle.SetActive(false);
    }
}
