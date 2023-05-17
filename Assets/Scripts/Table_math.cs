using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Table_math : MonoBehaviour
{
    public Row_math R1;
    public Row_math R2;
    public Row_math R3;
    TextMeshProUGUI text;
    int resultadoFinal;
    private void Start()
    {
        resultadoFinal = 0;
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        text.text = resultadoFinal.ToString();

    }
    void Update()
    {
        resultadoFinal = R1.resultado + R2.resultado + R3.resultado;
        text.text = resultadoFinal.ToString();
    }
}
