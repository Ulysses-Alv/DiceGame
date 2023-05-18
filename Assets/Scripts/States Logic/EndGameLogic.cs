using UnityEngine;
using UniRx;

public class EndGameLogic : MonoBehaviour
{
    GameObject[] firstPlayerRows;
    GameObject[] secondPlayerRows;

    private void Start()
    {
        firstPlayerRows = PlayerTurnsBlocker._gameObjects;
        secondPlayerRows = AITurnsBlocker._gameObjects;
        CurrentStates.current_gameState.Subscribe(OnGameEnd);
    }

    public void OnGameEnd(GameStates state)
    {
        if (IsThePlayerTableFull(firstPlayerRows))
        {
            CurrentStates.current_gameState.Value = GameStates.WIN_A_GAME;
            print("TERMINÓ EL PARTIDO TURUTU");
            return;
        }
        if (IsThePlayerTableFull(secondPlayerRows))
        {
            CurrentStates.current_gameState.Value = GameStates.LOSE_A_GAME;
            print("TERMINÓ EL PARTIDO TURUTU");
            return;
        }
    }

    private bool IsThePlayerTableFull(GameObject[] gameObjects)
    {
        var sumOfDices = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            sumOfDices += gameObject.GetComponent<PutDiceIn>().dicesInTheRow.Count;
        }

        return sumOfDices == 9;
    }
}