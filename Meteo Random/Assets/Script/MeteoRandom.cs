using UnityEngine;

public class MeteoRandom : MonoBehaviour
{

    public GameObject rainGenerator;

    void Awake()
    {
        
        /* On g�n�re un chiffre al�atoire */
        int meteo = Random.Range(0, 2);

        if (meteo == 1)
        {
            Debug.Log("Il pleut !");
            /* On affiche le g�n�rateur de pluie, il pleut */
            rainGenerator.SetActive(true);
        }
        else
        {
            Debug.Log("Il fait beau !");
            /* On masque le g�n�rateur de pluie, il fait beau */
            rainGenerator.SetActive(false);
        }

    }

}
