using UnityEngine;

public class CurrentStates : MonoBehaviour
{
    public static GameStates current_gameState;

    void Start()
    {
        current_gameState = GameStates.PLAYERTURNS;
        IATurnsBlocker.BlockPlayersButtons();
    }

    public static bool IsPlayerTurns()
    {
        return current_gameState == GameStates.PLAYERTURNS;
    }
}
