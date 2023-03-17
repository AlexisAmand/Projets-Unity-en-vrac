using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    /* Ajout d'un singleton pour avoir une seule classe Inventory dans le jeu */

    public int coinsCount;
    public Text coinsCountText;

    public int keysCount;
    public Text keysCountText;

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

    /* ajout d'une piece dans l'inventaire */

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    /* suppression d'une cl� de l'inventaire */

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }

    /* ajout d'une cl� dans l'inventaire */

    public void AddKeys(int count)
    {        
        keysCount += count;
        keysCountText.text = keysCount.ToString();
    }

    /* suppression d'une cl� de l'inventaire */

    public void RemoveKeys(int count)
    {
        keysCount -= count;
        keysCountText.text = keysCount.ToString();
    }

}
