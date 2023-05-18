using UnityEngine;

public class Dice_Roller : MonoBehaviour
{
    public int diceValue;


    public GameObject diceGO;
    public static GameObject _dice => instance.diceGO;

    private static Dice_Roller instance;  // Instancia privada de la clase

    private void Awake()
    {
        instance = this;  // Asignar la instancia actual a la variable estática "instance"
    }

    public static GameObject gameObjectDiceGO;

    DiceData diceData;

    [SerializeField]
    Transform positionOfInstance;

    [SerializeField]
    Sprite[] sprites;
    private void Start() 
    {
        gameObjectDiceGO = null;

        ObjectPooling.PreLoad(diceGO, 18); 
    }
    
    public void DiceRoll()
    {
        
        if (gameObjectDiceGO != null) return;

        diceValue = Random.Range(0, 6);


        gameObjectDiceGO = ObjectPooling.GetObject(diceGO);

        gameObjectDiceGO.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[diceValue];
        gameObjectDiceGO.gameObject.transform.position = positionOfInstance.position;

        gameObjectDiceGO.gameObject.GetComponent<DiceData>().SetData(diceValue + 1, sprites[diceValue], positionOfInstance.position);

        //DiceDictionary.DictionaryOfDices.Add(diceValue, diceData);

        PutDiceIn.unasiggnedDice = gameObjectDiceGO;
    }
}
