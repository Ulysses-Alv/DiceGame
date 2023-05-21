using UnityEngine;

public class DiceSprites : MonoBehaviour
{
    [SerializeField] Sprite[] Default_sprites;
    [SerializeField] Sprite[] f_sprites;
    [SerializeField] Sprite[] s_sprites;
    [SerializeField] Sprite[] t_sprites;
    [SerializeField] Sprite[] p_sprites;

    private Sprite[][] spriteArray = new Sprite[5][];

    public static Sprite[] final_sprites;
    private void Awake()
    {
        spriteArray[0] = Default_sprites;
        spriteArray[1] = f_sprites;
        spriteArray[2] = s_sprites;
        spriteArray[3] = t_sprites;
        spriteArray[4] = p_sprites;
    }
    private void Start()
    {
        SetSprites(0);
    }
    void SetSprites(int i)
    {
        final_sprites = spriteArray[i];
    }
}
