using UnityEngine;
using TMPro;
public class BoardMath : MonoBehaviour
{
    /* Do The Math of a player (or AI) board and update the counting UI text*/
    public RowMath row_one;
    public RowMath row_two;
    public RowMath row_three;

    TextMeshProUGUI text;

    public int total_result;
    private void Awake()
    {
        total_result = 0;
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = total_result.ToString();
    }
    void Update()
    {
        total_result = row_one.result + row_two.result + row_three.result;
        text.text = total_result.ToString();
    }
}
