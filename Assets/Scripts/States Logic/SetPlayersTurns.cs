using UnityEngine;

public class SetPlayersTurns : MonoBehaviour
{
    public static void EndTurnOfIA()
    {
        CurrentStates.current_gameState.Value = GameStates.PLAYER_TURNS;
    }
    public static void EndTurnOfPlayer()
    {
        CurrentStates.current_gameState.Value = GameStates.AI_TURNS;
    }
}