using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Dice : MonoBehaviour
{
    private void DestroyDice(GameObject primitive, GameObject diceGO)
    {
        ObjectPooling.RecicleObject(primitive, diceGO);
    }
}
