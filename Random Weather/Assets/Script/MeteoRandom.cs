using UnityEngine;

public class MeteoRandom : MonoBehaviour
{

    public GameObject rainGenerator;
    public GameObject snowGenerator;

    void Awake()
    {
        
        /* On génére un chiffre aléatoire */
        int meteo = Random.Range(0, 3);
        Debug.Log("meteo");

        switch (meteo)
        {
            case 1:
                Debug.Log("Il pleut !");
                /* On affiche le générateur de pluie, on masque le générateur de neige. Il pleut. */
                rainGenerator.SetActive(true);
                snowGenerator.SetActive(false);
                break;

            case 2:
                Debug.Log("Il fait beau !");
                /* On masque le générateur de pluie et le générateur de neige. Il fait beau. */
                rainGenerator.SetActive(false);
                snowGenerator.SetActive(false);
                break;

            case 3:
                Debug.Log("Il neige !");
                /* On masque le générateur de pluie, on affiche le générateur de neige. il neige. */
                rainGenerator.SetActive(false);
                snowGenerator.SetActive(true);
                break;

            default:
                Debug.Log("On est dans le default");
                break;
        }

    }

}
