using UnityEngine;

public class MatchEnd : MonoBehaviour
{
    void OnMatchEnd()
    {
        if (AddGameWin.FirstPlayerGamesWon == 3)
        {
            Debug.Log("CONGRATS MATCH WON");
        }
        if (AddGameWin.AIPlayerGamesWon == 3)
        {
            Debug.Log("BETTER LUCK NEXT TIME");
        }
    }
}