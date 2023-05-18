using UnityEngine;

public class SetPlayersTurns : MonoBehaviour
{
    public static void EndTurnOfIA()
    {
        CurrentStates.current_gameState = GameStates.PLAYERTURNS;
    }
    public static void EndTurnOfPlayer()
    {
        CurrentStates.current_gameState = GameStates.IATURNS;
    }
}