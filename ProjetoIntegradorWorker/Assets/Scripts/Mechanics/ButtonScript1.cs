using UnityEngine;
using UnityEngine.UI;
using Fusion;
using System.Linq;

public class ButtonScript : NetworkBehaviour
{
    [Networked] public NetworkObject player { get; set; }
    [Networked] public NetworkObject player2 { get; set; }
    [SerializeField] public GameManager gameManager;
    [SerializeField] public Animator playerAnimator;
    [SerializeField] public Animator player2Animator;

    [Header("Botões de movimento base")]
    [SerializeField] public Button[] buttonsMoveBase;

    [Networked] public NetworkObject buttonMoveSpecial { get; set; }

    [Header("Sprite")]
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Sprite[] cenario;
    [SerializeField] public GameObject backGround1;
    [SerializeField] public GameObject backGround2;
    [SerializeField] public GameObject backGround3;

    [Header("Animação")]
    private GameObject animManager;

    [Header("Váriaves de movimento")]
    public string bottomSimple1;
    public string bottomSimple2;
    public string bottomNormal;
    public string bottomSpecial;

    [Networked] private int currentAnimation { get; set; }

    void Start()
    {
        Animation();
        IsNetworkReady();
    }

    void Animation()
    {
        animManager = GameObject.Find("AnimManager");

        if (animManager != null)
        {
            var chooseAnim = animManager.GetComponent<ChooseAnim>();
            if (chooseAnim != null)
            {
                // Proteção caso as listas não tenham a quantidade esperada de elementos
                if (chooseAnim.bottonSimple.Count > 0) bottomSimple1 = chooseAnim.bottonSimple.ElementAt(0);
                if (chooseAnim.bottonSimple.Count > 1) bottomSimple2 = chooseAnim.bottonSimple.ElementAt(1);
                if (chooseAnim.bottonNormal.Count > 0) bottomNormal = chooseAnim.bottonNormal.ElementAt(0);
                if (chooseAnim.bottonSpecial.Count > 0) bottomSpecial = chooseAnim.bottonSpecial.ElementAt(0);
            }
        }

    }
    void ChangeScenario()
    {
        if (gameManager == null) return;

        if (gameManager.score >= 5 && backGround1 != null)
        {
            backGround1.gameObject.SetActive(true);
            if (backGround2 != null) backGround2.gameObject.SetActive(false);
            if (backGround3 != null) backGround3.gameObject.SetActive(false);
        }
        if (gameManager.score >= 25 && backGround2 != null)
        {
            backGround2.gameObject.SetActive(true);
            if (backGround1 != null) backGround1.gameObject.SetActive(false);
            if (backGround3 != null) backGround3.gameObject.SetActive(false);
        }
        if (gameManager.score >= 50 && backGround3 != null)
        {
            backGround3.gameObject.SetActive(true);
            if (backGround1 != null) backGround1.gameObject.SetActive(false);
            if (backGround2 != null) backGround2.gameObject.SetActive(false);

        }
    }

    public override void FixedUpdateNetwork()
    {
       if (HasStateAuthority)
       {
        if (player == null  && Runner.IsRunning)
        {
            player = Runner.GetPlayerObject(Runner.LocalPlayer);
        }
        else
        {  
            
            player2 = Runner.GetPlayerObject(Runner.LocalPlayer);

        }
       

       }
    }

    public override void Render()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        ChangeScenario();

        ApplyNetworkedAnimation();
    }

    private bool IsNetworkReady()
    {
        if (Object == null || !Object.IsValid || player == null)
        {
            
            return false;
        }
        return true;
    }

    private void ApplyNetworkedAnimation()
    {
        

        if (playerAnimator == null)
        {
            
            if (player != null)
            {
                playerAnimator = player.GetComponentInChildren<Animator>();
            }
            else
            {
                
                playerAnimator = FindAnyObjectByType<Animator>();
            }
        }

        
        if (playerAnimator != null && playerAnimator.runtimeAnimatorController != null)
        {
            if (!string.IsNullOrEmpty(bottomSimple1)) playerAnimator.SetBool(bottomSimple1, currentAnimation == 1);
            if (!string.IsNullOrEmpty(bottomSimple2)) playerAnimator.SetBool(bottomSimple2, currentAnimation == 2);
            if (!string.IsNullOrEmpty(bottomNormal)) playerAnimator.SetBool(bottomNormal, currentAnimation == 3);
            if (!string.IsNullOrEmpty(bottomSpecial)) playerAnimator.SetBool(bottomSpecial, currentAnimation == 4);
        }
    }


    //private void SetAnimatorBools(bool s1, bool s2, bool normal, bool special)
    //{

    //    if (playerAnimator == null && player != null)
    //    {
    //        playerAnimator = player.GetComponentInChildren<Animator>();
    //    }


    //    if (playerAnimator != null && playerAnimator.runtimeAnimatorController != null)
    //    {
    //        if (!string.IsNullOrEmpty(bottomSimple1)) playerAnimator.SetBool(bottomSimple1, s1);
    //        if (!string.IsNullOrEmpty(bottomSimple2)) playerAnimator.SetBool(bottomSimple2, s2);
    //        if (!string.IsNullOrEmpty(bottomNormal)) playerAnimator.SetBool(bottomNormal, normal);
    //        if (!string.IsNullOrEmpty(bottomSpecial)) playerAnimator.SetBool(bottomSpecial, special);
    //    }
    //    else
    //    {
    //        Debug.LogWarning($"Não foi possível animar: O playerAnimator está ausente ou sem Controller na cena.");
    //    }
    //}

    //public void ClickMoves()
    //{
    //    if (HasInputAuthority)
    //    {
            
    //    ClickMoveBaseFirst();
    //    ClickMoveBaseSecond();
    //    ClickMoveBaseThird();
    //    ClickMoveBaseSpecial();
    //    }
    //}    
    public void ClickMoveBaseFirst()
    {
        if (player == null) return;

        var spriteAtual = player.GetComponent<SpriteRenderer>();
        if (spriteAtual != null && sprites.Length > 0) spriteAtual.sprite = sprites[0];

        if (gameManager != null) gameManager.Rpc_GainPoints(1);

        gameManager.AddSpecialCount(1);

        currentAnimation = 1;
    }

    public void ClickMoveBaseSecond()
    {
        if (player == null) return;

        var spriteAtual = player.GetComponent<SpriteRenderer>();
        if (spriteAtual != null && sprites.Length > 1)
        {
            spriteAtual.sprite = sprites[1];
        }

        if (gameManager != null) gameManager.Rpc_GainPoints(5);

        gameManager.AddSpecialCount(1);

        //SetAnimatorBools(false, true, false, false);
        currentAnimation = 2;
    }

    public void ClickMoveBaseThird()
    {
        if (player == null) return;

        var spriteAtual = player.GetComponent<SpriteRenderer>();
        if (spriteAtual != null && sprites.Length > 2)
        {
            spriteAtual.sprite = sprites[2];
        }

        if (gameManager != null) gameManager.Rpc_GainPoints(5);

        gameManager.AddSpecialCount(1);

        currentAnimation = 3;
    }

    public void ClickMoveBaseSpecial()
    {
        if (player == null) return;

        var spriteAtual = player.GetComponent<SpriteRenderer>();
        if (spriteAtual != null && sprites.Length > 3)
        {
            spriteAtual.sprite = sprites[3];
        }

        if (gameManager != null) gameManager.Rpc_GainPoints(10);

        gameManager.ResetSpecial();

        currentAnimation = 4;
    }
}