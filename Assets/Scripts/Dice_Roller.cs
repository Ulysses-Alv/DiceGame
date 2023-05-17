using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_Roller : MonoBehaviour
{
    public int diceValue;

    public GameObject diceGO;

    [SerializeField]
    Transform positionOfInstance;

    Sprite[] sprites;
    private void Start() { ObjectPooling.PreLoad(diceGO, 18); }
    
    public void DiceRoll()
    {
        GameObject gameObjectDiceGO = null;
        
        if (gameObjectDiceGO != null) return;

        diceValue = Random.Range(1, 7);

        gameObjectDiceGO = ObjectPooling.GetObject(diceGO);

        DiceData dice = new(diceValue, positionOfInstance.position, sprites[diceValue], gameObjectDiceGO);

        DiceDictionary.DictionaryOfDices.Add(diceValue, dice);

        Row_button.unasiggnedDice = gameObjectDiceGO;
    }
}
