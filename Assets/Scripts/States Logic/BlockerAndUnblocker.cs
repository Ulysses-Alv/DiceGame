using UniRx;
using UnityEngine;

public class BlockerAndUnblocker : MonoBehaviour
{
    private void Start()
    {
        CurrentStates.current_gameState.Subscribe(BlockAndUnblock);
    }
    private void BlockAndUnblock(GameStates states)
    {
        if (states == GameStates.PLAYER_TURNS)
        {
            PlayerTurnsBlocker.UnblockPlayersButtons();
            AITurnsBlocker.BlockPlayersButtons();
        }
        if (states == GameStates.AI_TURNS)
        {
            AITurnsBlocker.UnblockPlayersButtons();
            PlayerTurnsBlocker.BlockPlayersButtons();
        }
    }
}