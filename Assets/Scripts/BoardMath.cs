using UnityEngine;
using TMPro;
using UniRx;
using UnityEditor.Presets;

public class BoardMath : MonoBehaviour
{
    /* Do The Math of a player (or AI) board and update the counting UI text*/
    public RowMath row_one;
    public RowMath row_two;
    public RowMath row_three;

    public int row_one_int;
    public int row_two_int;
    public int row_three_int;

    public ReactiveProperty<int> total_result;


    TextMeshProUGUI text;

    private void Awake()
    {
        ResetText(true);
    }
    private void Start()
    {
        EndGameLogic.resetGame.Subscribe(ResetText);
    }

    void ResetText(bool isReset)
    {
        if (!isReset) return;

        row_one_int = 0;
        row_two_int = 0;
        row_three_int = 0;

        total_result = new ReactiveProperty<int>(initialValue: 0);

        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = total_result.ToString();
    }
    void Update()
    {
        row_one_int = row_one.result;
        row_two_int = row_two.result;
        row_three_int = row_three.result;

        total_result.Value = row_one.result + row_two.result + row_three.result;
        text.text = total_result.ToString();
    }
    public bool IsThePlayerTableFull()
    {
        bool isFirstRowFull = row_one.myRow_Button.IsRowFull();
        bool isSecondRowFull = row_two.myRow_Button.IsRowFull();
        bool isThirdRowFull = row_three.myRow_Button.IsRowFull();

        return isFirstRowFull && isSecondRowFull && isThirdRowFull;
    }


}
