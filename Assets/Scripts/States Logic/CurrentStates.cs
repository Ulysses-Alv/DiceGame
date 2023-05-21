using System.Transactions;
using UnityEngine;
using UniRx;

public class CurrentStates : MonoBehaviour
{
    public static ReactiveProperty<GameStates> current_gameState;

    private void Awake()
    {
        current_gameState = new ReactiveProperty<GameStates>(initialValue: GameStates.PLAYER_TURNS);
    }

    public static bool IsPlayerTurns()
    {
        return current_gameState.Value == GameStates.PLAYER_TURNS;
    }

    public static bool IsAITurns()
    {
        return current_gameState.Value == GameStates.AI_TURNS;
    }

    public static bool IsWinAGame()
    {
        return current_gameState.Value == GameStates.PLAYER_WIN_A_GAME;
    }

    public static bool IsLoseAGame()
    {
        return current_gameState.Value == GameStates.AI_WIN_A_GAME;
    }

    public static bool IsEndGame()
    {
        return current_gameState.Value == GameStates.END_A_GAME;
    }
    public static bool IsWinAMatch()
    {
        return current_gameState.Value == GameStates.WIN_A_MATCH;
    }

    public static bool IsLoseAMatch()
    {
        return current_gameState.Value == GameStates.LOSE_A_MATCH;
    }
}
