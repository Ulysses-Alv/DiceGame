using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_button : MonoBehaviour
{
    public static GameObject unasiggnedDice;

    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private bool isPlayerOne;

    public int rowInt;

    public List<GameObject> gameObjects = new();

    public void PutDiceIn()
    {
        if (unasiggnedDice == null) return;

        int getLength = gameObjects.Count;

        unasiggnedDice.transform.position = positions[getLength].position;
        
        unasiggnedDiceData().rowAssigned = rowInt;
        unasiggnedDiceData().isPlayerOne = isPlayerOne;

        gameObjects.Add(unasiggnedDice);
    }
    DiceData unasiggnedDiceData()
    {
        return unasiggnedDice.GetComponent<DiceData>();
    }
}
