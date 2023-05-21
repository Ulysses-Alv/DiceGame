using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;
using UnityEngine.UI;
using UniRx;
public class AgentDicePlayerTwo : Agent
{
    public Button[] myButtonsRows;

    [SerializeField]
    int multiplier;

    [SerializeField]
    BoardMath myBoardMath;

    [SerializeField]
    BoardMath otherPlayerBoardMath;

    [SerializeField]
    public PutDiceIn[] myPutDiceIns;


    [SerializeField]
    public PutDiceIn[] otherPutDiceIns;

    public override void OnEpisodeBegin()
    {
        //REINICIAR TODO EL JUEGO;
        //OSEA EL GAMESTATE.
        //PODRIA AÑADIR UN LISTENER EN TODOS LOS SCRIPTS, QUE CUANDO GAMESTATE CAMBIA A FIRST MATCH, TODOS SE RESETEEN.
        //O MANUALMENTE RESETEAR TODOS LOS SCRIPTS.
    }
    private void Start()
    {
        myBoardMath.total_result.Subscribe(SetRewards);
        otherPlayerBoardMath.total_result.Subscribe(SetPunishments);
    }
    void SetRewards(int myPoints)
    {
        AddReward(myPoints * multiplier);
    }
    void SetPunishments(int otherPoints)
    {
        AddReward(otherPoints * multiplier * -1);
    }

    void EndGameIf(GameStates state)
    {
        if (state == GameStates.PLAYER_WIN_A_GAME)
        {
            AddReward(200f);
            EndEpisode();
        }
        if (state == GameStates.AI_WIN_A_GAME)
        {
            AddReward(-200f);
            EndEpisode();
        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log(StepCount);

        if (CurrentStates.current_gameState.Value != GameStates.AI_TURNS) return;
        int first_actionReceived = actions.DiscreteActions[0];
        int second_actionReceived = actions.DiscreteActions[1];
        int third_actionReceived = actions.DiscreteActions[2];

        if (!myPutDiceIns[first_actionReceived].IsRowFull())
        {
            myButtonsRows[first_actionReceived].onClick.Invoke();
            return;
        }
        if (!myPutDiceIns[second_actionReceived].IsRowFull())
        {
            myButtonsRows[second_actionReceived].onClick.Invoke();
            return;
        }
        if (!myPutDiceIns[third_actionReceived].IsRowFull())
        {
            myButtonsRows[third_actionReceived].onClick.Invoke();
            return;
        }

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(myBoardMath.row_one_int);
        sensor.AddObservation(myBoardMath.row_two_int);
        sensor.AddObservation(myBoardMath.row_three_int);

        sensor.AddObservation(otherPlayerBoardMath.row_one_int);
        sensor.AddObservation(otherPlayerBoardMath.row_two_int);
        sensor.AddObservation(otherPlayerBoardMath.row_three_int);

        sensor.AddObservation(myPutDiceIns[0].IsRowFull() ? 0 : 1);
        sensor.AddObservation(myPutDiceIns[1].IsRowFull() ? 0 : 1);
        sensor.AddObservation(myPutDiceIns[2].IsRowFull() ? 0 : 1);

    }



}