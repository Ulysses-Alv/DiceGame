using UnityEngine;

[CreateAssetMenu(fileName = "New Re-Roll", menuName = "Power Card/ReRoll")]
public class PowerCardReRoll : PowerCard
{
    public override void Effect()
    {
        DiceRoller.ReRollDice();
    }
}

[CreateAssetMenu(fileName = "New Delete Enemy Board", menuName = "Power Card/Delete Enemy Board.")]
public class PowerCardDeleteEnemyBoard : PowerCard
{
    public string tagToSearch;
    public override void Effect()
    {
        GameObject[] enemyRows = GameObject.FindGameObjectsWithTag(tagToSearch);
        foreach (GameObject enemyRow in enemyRows)
        {
            enemyRow.GetComponent<PutDiceIn>().DeleteDicesInThisRow();
        }
    }
}

