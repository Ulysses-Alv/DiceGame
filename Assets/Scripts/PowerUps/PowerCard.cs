using UnityEngine;

public abstract class PowerCard : ScriptableObject
{
    [Tooltip("The Name of the Card.")]
    public string powerCardName;

    [Tooltip("What the card does.")]
    public string description;

    [Tooltip("Image Of the card.")]
    public Sprite sprite;

    [Tooltip("the rarity of the card.")]
    public RarityOfCards rarity;

    [Tooltip("Seconds Until Refresh.")]
    public int coolDown;

    [Tooltip("Max Uses until coolDown.")]
    public int maxUses;

    [Tooltip("Cost of selling the card.")]
    public int sellingTokensCost;

    [Tooltip("Cost of buying the card.")]
    public int buyingTokensCost;

    [Tooltip("Max uses until the card disappeared.")]
    public int maxUsesUntilDestroy;

    public abstract void Effect();

}

/*
    Re-Roll: 1/5  *DONE*
    Eliminar dado enemigo. 2/5   Dificil  
    Aumentar Suerte. 3/5    Medio
    Duplicar tokens. 3/5 Facil
    Tirar de nuevo. 3/5 Facil
    Duplicar puntos. 5/5 Facil
    Inmunidad de Linea. 3/5 Medio
    Eliminar Linea enemiga. 4/5 Facil
    Bloquear Linea Enemiga. 3/5 Facil
    Eliminar Tablero Enemigo. 5/5 *DONE*
    Convertir toda la linea en el numero más alto. 4/5 Dificil.

*/
