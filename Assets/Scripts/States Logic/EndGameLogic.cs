using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class EndGameLogic : MonoBehaviour
{

    [SerializeField] BoardMath firstPlayer;
    [SerializeField] BoardMath secondPlayer;

    public static ReactiveProperty<bool> resetGame;

    private void Awake()
    {
        resetGame = new ReactiveProperty<bool>(initialValue: false);
    }
    private void Start()
    {
        CurrentStates.current_gameState.Subscribe(OnGameEnd);
        CurrentStates.current_gameState.Subscribe(SetWinner);
    }
    public void OnGameEnd(GameStates state)
    {
        if ((firstPlayer.IsThePlayerTableFull() || secondPlayer.IsThePlayerTableFull()) &&
            state != GameStates.END_A_GAME)
        {
            CurrentStates.current_gameState.Value = GameStates.END_A_GAME;
        }
    }

    public void SetWinner(GameStates state)
    {

        if (state != GameStates.END_A_GAME) return;

        float first_value = firstPlayer.total_result.Value;
        float second_value = secondPlayer.total_result.Value;

        if (firstPlayer.IsThePlayerTableFull())
        {
            if (first_value >= second_value)
            {
                print("se ejecuta A");
                AddGameWin.FirstPlayerGamesWon++;
            }
            if (first_value < second_value)
            {
                print("se ejecuta B");
                AddGameWin.AIPlayerGamesWon++;
            }
            ResetForNewGame();
            return;
        }
        if (secondPlayer.IsThePlayerTableFull())
        {
            if (first_value > second_value)
            {
                print("se ejecuta C");
                AddGameWin.FirstPlayerGamesWon++;

            }
            if (first_value <= second_value)
            {
                print("se ejecuta D");
                AddGameWin.AIPlayerGamesWon++;
            }
            ResetForNewGame();
            return;
        }
    }
    void ResetForNewGame()
    {
        resetGame.Value = true;
    }

}
