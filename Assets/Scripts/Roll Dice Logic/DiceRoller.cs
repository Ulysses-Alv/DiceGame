using UnityEngine;
using UniRx;
using System.Collections;
public class DiceRoller : MonoBehaviour
{
    public int diceValue;


    public GameObject diceGO;
    public static GameObject _dice => instance.diceGO;

    private static DiceRoller instance;

    public static ReactiveProperty<GameObject> gameObjectDiceGO;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ObjectPooling.PreLoad(diceGO, 18);
        gameObjectDiceGO = new ReactiveProperty<GameObject>(initialValue: null);
        //StartCoroutine(RollDiceAfterDelay(null));

        gameObjectDiceGO.Subscribe(RollTheDice);
    }
    void RollTheDice(GameObject diceReactive)
    {
        StartCoroutine(RollDiceAfterDelay(diceReactive));
    }
    private IEnumerator RollDiceAfterDelay(GameObject diceObject)
    {
        yield return new WaitForSeconds(0.5f);
        
        DiceRoll(diceObject);

    }

    public void DiceRoll(GameObject diceReactive)
    {

        if (diceReactive != null) return;
        diceValue = Random.Range(0, 6);

        GameObject diceToPut = ObjectPooling.GetObject(diceGO);

        diceToPut.gameObject.GetComponent<SpriteRenderer>().sprite = DiceSprites.final_sprites[diceValue];
        diceToPut.gameObject.transform.position = this.transform.position;

        diceToPut.gameObject.GetComponent<DiceData>().SetData(diceValue + 1, DiceSprites.final_sprites[diceValue], this.transform.position);

        gameObjectDiceGO.Value = diceToPut;

        PutDiceIn.unasiggnedDice = diceToPut;
    }

    public static void ReRollDice()
    {
        gameObjectDiceGO.Value = null;
    }
}
