using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    /* Ajout d'un singleton pour avoir une seule classe Inventoy dans le jeu */

    public int coinsCount;
    public Text coinsCountText;

    public static Inventory Instance;

    /* La fonction Awake est lue avant tout le monde, avant m�me la fonction start */
    /* on va pouvoir acc�der � l'inventory depuis n'importe o� */

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la sc�ne");
            return;
        }

        Instance = this;
    }

    /* ajout de pieces dans l'inventaire */

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }
}
