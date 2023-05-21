using UnityEngine;
using TMPro;

public class AddGameWin : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI contador;

    private static AddGameWin instance;
    
    public static int FirstPlayerGamesWon;
    public static int AIPlayerGamesWon;

    void Update()
    {
        contador.text = FirstPlayerGamesWon.ToString() + " - " + AIPlayerGamesWon.ToString();
    }
}
