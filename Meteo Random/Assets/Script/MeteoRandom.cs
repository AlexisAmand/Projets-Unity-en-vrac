using UnityEngine;

public class MeteoRandom : MonoBehaviour
{

    public GameObject rainGenerator;

    void Awake()
    {
        
        /* On génére un chiffre aléatoire */
        int meteo = Random.Range(0, 2);

        if (meteo == 1)
        {
            Debug.Log("Il pleut !");
            /* On affiche le générateur de pluie, il pleut */
            rainGenerator.SetActive(true);
        }
        else
        {
            Debug.Log("Il fait beau !");
            /* On masque le générateur de pluie, il fait beau */
            rainGenerator.SetActive(false);
        }

    }

}
