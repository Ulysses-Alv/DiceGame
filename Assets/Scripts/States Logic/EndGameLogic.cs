using UnityEngine;
using UniRx;

public class EndGameLogic : MonoBehaviour
{

    [SerializeField] BoardMath firstPlayer;
    [SerializeField] BoardMath secondPlayer;

    [SerializeField] AgentDicePlayer agentDicePlayerOne;
    [SerializeField] AgentDicePlayer agentDicePlayerIA;

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
                AddGameWin.FirstPlayerGamesWon++;
                agentDicePlayerOne.IWin = 1f;
                agentDicePlayerIA.IWin = -1f;

            }
            if (first_value < second_value)
            {
                AddGameWin.AIPlayerGamesWon++;
                agentDicePlayerOne.IWin = -1f;
                agentDicePlayerIA.IWin = 1f;
            }
            ResetForNewGame();
            return;
        }
        if (secondPlayer.IsThePlayerTableFull())
        {
            if (first_value > second_value)
            {
                AddGameWin.FirstPlayerGamesWon++;
                agentDicePlayerOne.IWin = 1f;
                agentDicePlayerIA.IWin = -1f;
            }
            if (first_value <= second_value)
            {
                AddGameWin.AIPlayerGamesWon++;
                agentDicePlayerOne.IWin = -1f;
                agentDicePlayerIA.IWin = 1f;
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
