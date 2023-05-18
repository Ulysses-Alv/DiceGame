using UnityEngine;
using UnityEngine.UI;

public class AITurnsBlocker : MonoBehaviour, ITurnBlocker
{
    public GameObject[] gameObjects;

    [SerializeField]
    public  static GameObject[] _gameObjects => instance.gameObjects;

    private static AITurnsBlocker instance;  // Instancia privada de la clase

    private void Awake()
    {
        instance = this;  // Asignar la instancia actual a la variable estática "instance"
    }

    
    public static void BlockPlayersButtons()
    {        
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
    public static void UnblockPlayersButtons()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
