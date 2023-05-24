using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerCardInGame : MonoBehaviour
{

    [Serializable]
    public class CardParts
    {
        public Button button;
        public Image card_image;
        public Image frameOfCard;

        public TextMeshProUGUI text_Name;
        public TextMeshProUGUI text_MaxUses;
        public TextMeshProUGUI text_MaxUsesUntilDestroy;
        public TextMeshProUGUI text_CoolDown;
        public TextMeshProUGUI text_MaxAndRemainingUses;
        public TextMeshProUGUI text_SellingCost;
        public TextMeshProUGUI text_BuyingCost;
    }
    public CardParts fields;

    public PowerCard powerCard;
    public CardData cardData;

    public Image rarityImage;

    public virtual void Start()
    {
        SetBasicCard();
    }

    public void SetBasicCard()
    {
        SetFrame();
        fields.text_Name.text = powerCard.name;
        fields.card_image.sprite = powerCard.sprite;
        fields.button.onClick.AddListener(UseCard);
    }

    public abstract void UseCard();

    private void SetFrame() //Set card frame color.
    {
        switch (powerCard.rarity)
        {
            case RarityOfCards.COMMON:
                fields.frameOfCard.color = Color.grey;
                break;
            case RarityOfCards.RARE:
                fields.frameOfCard.color = Color.green;
                break;
            case RarityOfCards.EPIC:
                fields.frameOfCard.color = Color.magenta;
                break;
            case RarityOfCards.LEGENDARY:
                fields.frameOfCard.color = Color.yellow;
                break;
        }
    }
}