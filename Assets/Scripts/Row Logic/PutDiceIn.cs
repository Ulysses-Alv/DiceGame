using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UniRx;
public class PutDiceIn : MonoBehaviour
{
    public static GameObject unasiggnedDice;

    public RowMath row_Math;

    [SerializeField]
    private Transform[] positions;


    [SerializeField] int rowInt;

    public List<GameObject> dicesInTheRow;

    public PutDiceIn enemy_row_Button;
    public bool IsRowFull()
    {
        return dicesInTheRow.Count == 3;
    }
    int lastDiceValue;

    private void Start()
    {
        EndGameLogic.resetGame.Subscribe(ResetValues);
    }
    public void ResetValues(bool isReset)
    {
        if (!isReset) return;
        DeleteDicesInThisRow();
    }

    public void DeleteDicesInThisRow()
    {
        foreach (var dice in dicesInTheRow)
        {
            DeleteDice.DestroyDice(DiceRoller._dice, dice);
        }
        dicesInTheRow = new();
    }

    public void PutDiceInRow()
    {
        if (unasiggnedDice == null) return;

        if (IsRowFull()) return;
        int getLength = dicesInTheRow.Count;

        unasiggnedDice.transform.position = positions[getLength].position;

        UnasiggnedDiceData().rowAssigned = rowInt;
        lastDiceValue = UnasiggnedDiceData().diceValue;
        dicesInTheRow.Add(unasiggnedDice);
    }    

    public void DoLogic()
    {
        row_Math.RefreshCountText();
        DiceRoller.gameObjectDiceGO.Value = null;
        unasiggnedDice = null;
    }

    public void DestroyOtherDiceWhenPlay()
    {
        if (Is_Filter_Game_Objects_Length_Zero()) return;

        DestroyOthersDices(UnasiggnedDiceData().diceValue);
    }

    public void MoveTheDices()
    {
        if (GetEnemyDicesInTheRow().Count is 3 or
            0) return;

        for (int i = 0; i < GetEnemyDicesInTheRow().Count; i++)
        {
            if (GetEnemyDicesInTheRow()[i].transform.position != enemy_row_Button.positions[i].position)
            {
                GetEnemyDicesInTheRow()[i].transform.position = enemy_row_Button.positions[i].position;
            }
        }
    }

    private List<GameObject> GetEnemyDicesInTheRow()
    {
        return enemy_row_Button.dicesInTheRow;
    }

    private bool Is_Filter_Game_Objects_Length_Zero()
    {
        return FilterGameObjects(GetEnemyDicesInTheRow(), lastDiceValue).Count == 0;
    }

    private void DestroyOthersDices(int _diceValue)
    {
        List<GameObject> originalList = GetEnemyDicesInTheRow();
        List<GameObject> list = FilterGameObjects(GetEnemyDicesInTheRow(), _diceValue);

        foreach (GameObject go in list)
        {
            DeleteDice.DestroyDice(DiceRoller._dice, go);
        }

        enemy_row_Button.row_Math.RefreshCountText();
        enemy_row_Button.dicesInTheRow = RemoveDuplicates(originalList, list);
    }
    List<GameObject> RemoveDuplicates(List<GameObject> listaA, List<GameObject> listaB)
    {
        List<GameObject> resultado = new List<GameObject>(listaA);

        foreach (GameObject objetoB in listaB)
        {
            resultado.RemoveAll(objeto => objeto == objetoB);
        }

        return resultado;
    }

    List<GameObject> FilterGameObjects(List<GameObject> originalList, int _diceValue)
    {
        List<GameObject> filteredList = new List<GameObject>();

        foreach (GameObject gameObject in originalList)
        {
            if (gameObject.GetComponent<DiceData>().diceValue == _diceValue)
            {
                filteredList.Add(gameObject);
            }
        }

        return filteredList;
    }
    DiceData UnasiggnedDiceData()
    {
        return unasiggnedDice.GetComponent<DiceData>();
    }
}
