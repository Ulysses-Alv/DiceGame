using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DiceData : MonoBehaviour
{
    public int diceValue;
    public int rowAssigned;

    public Vector3 position;
    
    public Sprite sprite;
    


    public void SetData(int _diceValue, Sprite _sprite, Vector3 _position)
    {
        diceValue = _diceValue;
        sprite= _sprite;
        position = _position;
    }

    public void ResetData()
    {
        diceValue = 0;
        sprite = null;
        rowAssigned = 0;
        position = Vector3.zero;
    }
}
