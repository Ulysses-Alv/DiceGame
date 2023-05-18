using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RowMath : MonoBehaviour
{
    
    public TextMeshProUGUI thisText;

    [SerializeField]
    PutDiceIn myRow_Button;

    public int result;

    private void Start()
    {
        thisText.text = 0.ToString();
    }    
    public void RefreshCountText()
    {
        thisText.text = SumAll().ToString(); //Refresh the 
    }    

    int SumAll()
    {
        result = SumOthers() + SumBonusValues();
        return result;
    }

    int SumOthers()
    {
        int resultSum = 0;
        
        var lists = GetSameAndOther(GetGameObjects());
        foreach(GameObject gameObject in lists.sobrantes)
        {
            resultSum += gameObject.GetComponent<DiceData>().diceValue;
        }
        return resultSum;
    }
    int SumBonusValues()
    {
        int resultSum = 0;

        var lists = GetSameAndOther(GetGameObjects());
        foreach (GameObject gameObject in lists.iguales)
        {
            resultSum += gameObject.GetComponent<DiceData>().diceValue;
        }
        resultSum = resultSum * lists.iguales.Count; // Multiply the values with two or three as a bonus.
        
        return resultSum;
    }

    private List<GameObject> GetGameObjects()
    {
        return myRow_Button.dicesInTheRow;
    }
    public (List<GameObject> iguales, List<GameObject> sobrantes) GetSameAndOther(List<GameObject> lista) 
        //Split the list in two so I can multiply the values for the bonus.
    {
        List<GameObject> iguales = new List<GameObject>();
        List<GameObject> sobrantes = new List<GameObject>();


        if (lista.Count == 2) // Caso de dos elementos
        {
            if (lista[0].GetComponent<DiceData>().diceValue == lista[1].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(lista[0]);
                iguales.Add(lista[1]);
            }
            else
            {
                sobrantes.Add(lista[0]);
                sobrantes.Add(lista[1]);
            }
        }
        else if (lista.Count == 3) // Caso de tres elementos
        {
            if (lista[0].GetComponent<DiceData>().diceValue == lista[1].GetComponent<DiceData>().diceValue && lista[0].GetComponent<DiceData>().diceValue == lista[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(lista[0]);
                iguales.Add(lista[1]);
                iguales.Add(lista[2]);
            }
            else if (lista[0].GetComponent<DiceData>().diceValue == lista[1].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(lista[0]);
                iguales.Add(lista[1]);
                sobrantes.Add(lista[2]);
            }
            else if (lista[0].GetComponent<DiceData>().diceValue == lista[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(lista[0]);
                iguales.Add(lista[2]);
                sobrantes.Add(lista[1]);
            }
            else if (lista[1].GetComponent<DiceData>().diceValue == lista[2].GetComponent<DiceData>().diceValue)
            {
                iguales.Add(lista[1]);
                iguales.Add(lista[2]);
                sobrantes.Add(lista[0]);
            }
            else
            {
                sobrantes.Add(lista[0]);
                sobrantes.Add(lista[1]);
                sobrantes.Add(lista[2]);
            }
        }
        else // Caso de un elemento
        {
            sobrantes.Add(lista[0]);
        }

        return (iguales, sobrantes);
    }

}
