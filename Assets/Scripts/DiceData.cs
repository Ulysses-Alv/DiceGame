using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceData : MonoBehaviour
{
    public int diceValue;
    public Vector3 position;
    public GameObject thisGameObject;
    public Sprite spriteDice;
    
    
    public int rowAssigned;
    public bool isPlayerOne;

    public DiceData(int diceValue, Vector3 position, Sprite spriteDice, GameObject gameObject)
    {
        this.thisGameObject = gameObject;

        this.diceValue = diceValue;
        this.position = position;
        this.spriteDice = spriteDice;

        gameObject.GetComponent<SpriteRenderer>().sprite = spriteDice;
        gameObject.GetComponent<DiceData>().diceValue = diceValue;
        gameObject.transform.position = position;
    }
}
