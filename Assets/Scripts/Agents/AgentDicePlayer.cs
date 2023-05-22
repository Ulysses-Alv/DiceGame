using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;
using UnityEngine.UI;
using UniRx;


public class AgentDicePlayer : Agent
{

    [SerializeField] Button[] myButtonsRows;

    [SerializeField] int multiplier;

    [SerializeField] BoardMath myBoardMath;
    [SerializeField] BoardMath otherPlayerBoardMath;

    [SerializeField] PutDiceIn[] myPutDiceIns;
    [SerializeField] PutDiceIn[] otherPutDiceIns;

    [HideInInspector] public float IWin;

    public GameStates gameState;
    int lastResult;
    private void Start()
    {
        myBoardMath.total_result.Subscribe(SetRewards);
        otherPlayerBoardMath.total_result.Subscribe(SetPunishments);
        CurrentStates.current_gameState.Subscribe(EndGame);
    }
    void SetRewards(int myPoints)
    {
        AddReward(myPoints * multiplier);
    }
    void SetPunishments(int otherPoints)
    {
        if(otherPoints < lastResult)
        {
            AddReward(lastResult - otherPoints * multiplier);
        }
        lastResult = otherPoints;
    }
    void EndGame(GameStates state)
    {
        if (state == GameStates.END_A_GAME)
        {
            AddReward(100f * IWin);
            EndEpisode();
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int first_actionReceived = actions.DiscreteActions[0];
        //Debug.Log(first_actionReceived);

        if (CurrentStates.current_gameState.Value != gameState ||
            myPutDiceIns[first_actionReceived].IsRowFull() ||
            !myButtonsRows[first_actionReceived].enabled || PutDiceIn.unasiggnedDice == null)
        {
            return;
        }
        myButtonsRows[first_actionReceived].onClick.Invoke();
        //Debug.Log(gameObject.name + ": " + StepCount);
        //StartCoroutine(WaitAction(1f, first_actionReceived));
    }
    IEnumerator WaitAction(float seconds, int action)
    {

        yield return new WaitForSeconds(seconds);

        myButtonsRows[action].onClick.Invoke();

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if(PutDiceIn.unasiggnedDice != null)
        {
            sensor.AddObservation(PutDiceIn.unasiggnedDice.GetComponent<DiceData>().diceValue);
        }
        
        sensor.AddObservation(myBoardMath.row_one_int);
        sensor.AddObservation(myBoardMath.row_two_int);
        sensor.AddObservation(myBoardMath.row_three_int);

        sensor.AddObservation(otherPlayerBoardMath.row_one_int);
        sensor.AddObservation(otherPlayerBoardMath.row_two_int);
        sensor.AddObservation(otherPlayerBoardMath.row_three_int);

        sensor.AddObservation(myPutDiceIns[0].IsRowFull() ? 0 : 1);
        sensor.AddObservation(myPutDiceIns[1].IsRowFull() ? 0 : 1);
        sensor.AddObservation(myPutDiceIns[2].IsRowFull() ? 0 : 1);

        sensor.AddObservation(otherPutDiceIns[0].IsRowFull() ? 1 : 0);
        sensor.AddObservation(otherPutDiceIns[1].IsRowFull() ? 1 : 0);
        sensor.AddObservation(otherPutDiceIns[2].IsRowFull() ? 1 : 0);
    }



}