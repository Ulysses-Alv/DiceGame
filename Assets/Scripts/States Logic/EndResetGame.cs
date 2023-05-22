using UnityEngine;
using UniRx;

public class EndResetGame :MonoBehaviour
{
    private void Start()
    {
        EndGameLogic.resetGame.Subscribe(EndReset);
    }
    void EndReset(bool isReset)
    {
        if (!isReset) return;
        //ResetBool();
        Invoke("ResetBool", 0.1f);
    }

    void ResetBool()
    {
        EndGameLogic.resetGame.Value = false;
        CurrentStates.current_gameState.Value = GameStates.PLAYER_TURNS;
    }
}