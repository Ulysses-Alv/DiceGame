using UnityEngine;
public class ButtonOfTheRow : MonoBehaviour
{
    PutDiceIn putDiceIn;

    private void Awake()
    {
        putDiceIn = GetComponent<PutDiceIn>();
    }   
    public void PutDice_One()
    {
        putDiceIn.PutDiceInRow();
    }
    public void DestroyOtherDice_Two()
    {
        putDiceIn.DestroyOtherDiceWhenPlay();
    }
    public void DoLogic_Three()
    {
        putDiceIn.DoLogic();
    }
    public void MoveDices_Four()
    {
        putDiceIn.MoveTheDices();
    }
    public void EndTurnOfPlayer_Five()
    {
        SetPlayersTurns.EndTurnOfPlayer();
    }
    public void EndTurnOfIA()
    {
        SetPlayersTurns.EndTurnOfIA();
    }
}
