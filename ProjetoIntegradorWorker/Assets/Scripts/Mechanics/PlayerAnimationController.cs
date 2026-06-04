using Fusion;
using UnityEngine;

public class PlayerAnimationController : NetworkBehaviour
{
    [Networked]
    public int CurrentAnimation { get; set; }
    [Networked]
    public int SpecialCount { get; set; }

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] sprites;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAnimation(int id)
    {
        if (!HasStateAuthority)
            return;

        CurrentAnimation = id;

        if (sprites != null &&
            id > 0 &&
            id <= sprites.Length)
        {
            spriteRenderer.sprite = sprites[id - 1];
        }
    }

    public override void Render()
    {
        if (anim == null)
            return;

        anim.SetBool("isTopRock1", CurrentAnimation == 1);
        anim.SetBool("isTopRock2", CurrentAnimation == 2);
        anim.SetBool("isPowerMove3", CurrentAnimation == 3);
        anim.SetBool("isFreeze4", CurrentAnimation == 4);
    }

    public void AddSpecial(int value)
    {
        SpecialCount += value;
    }

    public void ResetSpecial()
    {
        SpecialCount = 0;
    }

    public bool CanUseSpecial()
    {
        return SpecialCount >= 10;
    }
}