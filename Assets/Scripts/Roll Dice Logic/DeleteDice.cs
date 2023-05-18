using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDice : MonoBehaviour
{
    public static void DestroyDice(GameObject primitive, GameObject diceGO)
    {
        diceGO.GetComponent<DiceData>().ResetData();
        ObjectPooling.RecicleObject(primitive, diceGO);
    }
}
