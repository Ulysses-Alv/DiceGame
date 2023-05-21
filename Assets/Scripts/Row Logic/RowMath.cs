using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class RowMath : MonoBehaviour
{

    public TextMeshProUGUI thisText;

    [SerializeField]
    public PutDiceIn myRow_Button;

    public int result;

    private void Start()
    {
        result = 0;
        thisText.text = 0.ToString();
        EndGameLogic.resetGame.Subscribe(ResetText);
    }
    private void ResetText(bool isReset)
    {
        if (!isReset) return;
        result = 0;
        thisText.text = "0";
    }
    public void RefreshCountText()
    {
        thisText.text = SumAll().ToString();
    }

    int SumAll()
    {
        result = SumOthers() + SumBonusValues();
        return result;
    }

    int SumOthers() //Sum the values that are not the same in the row.
    {
        int resultSum = 0;

        var lists = GetSameAndOther();
        foreach (GameObject gameObject in lists.sobrantes)
        {
            resultSum += gameObject.GetComponent<DiceData>().diceValue;
        }
        return resultSum;
    }
    int SumBonusValues() // Multiply the values with two or three as a bonus.
    {
        int resultSum = 0;

        var lists = GetSameAndOther();
        foreach (GameObject gameObject in lists.iguales)
        {
            resultSum += gameObject.GetComponent<DiceData>().diceValue;
        }
        resultSum = resultSum * lists.iguales.Count;
        return resultSum;
    }

    (List<GameObject> iguales, List<GameObject> sobrantes) GetSameAndOther()
    //Split the list in two so I can multiply the values for the bonus.
    {
        List<GameObject> iguales = new List<GameObject>();
        List<GameObject> sobrantes = new List<GameObject>();
        List<GameObject> list = GetGameObjects();

        if (list.Count == 2) // Caso de dos elementos
        {
            if (list[0].GetComponent<DiceData>().diceValue == list[1].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(list[0]);
                iguales.Add(list[1]);
            }
            else
            {
                sobrantes.Add(list[0]);
                sobrantes.Add(list[1]);
            }
        }
        else if (list.Count == 3) // Caso de tres elementos
        {
            if (list[0].GetComponent<DiceData>().diceValue == list[1].GetComponent<DiceData>().diceValue && list[0].GetComponent<DiceData>().diceValue == list[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(list[0]);
                iguales.Add(list[1]);
                iguales.Add(list[2]);
            }
            else if (list[0].GetComponent<DiceData>().diceValue == list[1].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(list[0]);
                iguales.Add(list[1]);
                sobrantes.Add(list[2]);
            }
            else if (list[0].GetComponent<DiceData>().diceValue == list[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(list[0]);
                iguales.Add(list[2]);
                sobrantes.Add(list[1]);
            }
            else if (list[1].GetComponent<DiceData>().diceValue == list[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(list[1]);
                iguales.Add(list[2]);
                sobrantes.Add(list[0]);
            }
            else
            {
                sobrantes.Add(list[0]);
                sobrantes.Add(list[1]);
                sobrantes.Add(list[2]);
            }
        }
        else // Caso de un elemento
        {
            sobrantes.Add(list[0]);
        }

        return (iguales, sobrantes);
    }
    List<GameObject> GetGameObjects()
    {
        return myRow_Button.dicesInTheRow;
    }

}
