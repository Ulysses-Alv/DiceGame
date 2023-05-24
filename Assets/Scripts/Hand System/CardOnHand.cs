public class CardOnHand : PowerCardInGame
{
    public override void Start()
    {
        base.Start();

        fields.text_MaxAndRemainingUses.text = string.Format("{0}/{1}", cardData.remainingUses, powerCard.maxUses);
    }

    public override void UseCard()
    {
        if (powerCard.maxUses <= 0 || powerCard.maxUsesUntilDestroy <= 0 || cardData.remainingUses <= 0) return;

        powerCard.Effect();
        cardData.remainingUses--;
    }
}
