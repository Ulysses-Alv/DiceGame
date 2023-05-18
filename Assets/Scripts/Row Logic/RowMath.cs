using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class RowMath : MonoBehaviour
{
    
    public TextMeshProUGUI thisText;

    [SerializeField]
    PutDiceIn myRow_Button;

    public int resultado;

    private void Start()
    {
        
        thisText.text = 0.ToString();
    }    
    public void RefreshMaths()
    {
        thisText.text = Row_math().ToString();
    }

    public int Row_math()
    {
        resultado = SumAll();
        return resultado;
    }

    int SumAll()
    {
        int suma = SumSobrantes() + SumIguales();
        
        return suma;
    }

    int SumSobrantes()
    {
        int resultadoSuma = 0;
        
        var listas = ObtenerIgualesYSobrantes(GetGameObjects());
        foreach(GameObject gameObject in listas.sobrantes)
        {
            resultadoSuma += gameObject.GetComponent<DiceData>().diceValue;
        }
        return resultadoSuma;
    }
    int SumIguales()
    {
        int resultadoSuma = 0;

        var listas = ObtenerIgualesYSobrantes(GetGameObjects());
        foreach (GameObject gameObject in listas.iguales)
        {
            resultadoSuma += gameObject.GetComponent<DiceData>().diceValue;
        }
        resultadoSuma = resultadoSuma * listas.iguales.Count;
        
        return resultadoSuma;
    }

    private List<GameObject> GetGameObjects()
    {
        return myRow_Button.dicesInTheRow;
    }
    public (List<GameObject> iguales, List<GameObject> sobrantes) ObtenerIgualesYSobrantes(List<GameObject> lista)
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
