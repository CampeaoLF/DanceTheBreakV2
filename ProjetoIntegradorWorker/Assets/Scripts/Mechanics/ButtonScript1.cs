using UnityEngine;
using UnityEngine.UI;
using Fusion;
using System.Linq;
using System.Collections;

public class ButtonScript : NetworkBehaviour
{
   
    [SerializeField] public GameManager gameManager;
  

    [Header("Botões de movimento base")]
    [SerializeField] public Button[] buttonsMoveBase;

    [SerializeField] public Button buttonMoveSpecial;

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

    [SerializeField] private float cooldownSimple1 = 2f;
    [SerializeField] private float cooldownSimple2 = 3f;
    [SerializeField] private float cooldownNormal = 3f;

    private bool canUseSimple1 = true;
    private bool canUseSimple2 = true;
    private bool canUseNormal = true;
    private Sprite spriteOriginalSimple1;

    private IEnumerator CooldownSimple1()
    {
        canUseSimple1 = false;

        gameManager.buttonSimple1.interactable = false;

        Color cor = gameManager.buttonSimple1.image.color;
        cor.a = 0.3f; 
        gameManager.buttonSimple1.image.color = cor;

        yield return new WaitForSeconds(2f);

        cor.a = 1f; 
        gameManager.buttonSimple1.image.color = cor;

        gameManager.buttonSimple1.interactable = true;

        canUseSimple1 = true;
    }
    private IEnumerator CooldownSimple2()
    {
        canUseSimple2 = false;

        gameManager.buttonSimple2.interactable = false;

        Color cor = gameManager.buttonSimple2.image.color;
        cor.a = 0.3f; 
        gameManager.buttonSimple2.image.color = cor;

        yield return new WaitForSeconds(2f);

        cor.a = 1f; 
        gameManager.buttonSimple2.image.color = cor;

        gameManager.buttonSimple2.interactable = true;

        canUseSimple2 = true;
    }
    private IEnumerator CooldownNormal()
    {
        canUseNormal = false;

        gameManager.buttonNormal.interactable = false;

        Color cor = gameManager.buttonNormal.image.color;
        cor.a = 0.3f; 
        gameManager.buttonNormal.image.color = cor;

        yield return new WaitForSeconds(2f);

        cor.a = 1f; 
        gameManager.buttonNormal.image.color = cor;

        gameManager.buttonNormal.interactable = true;

        canUseNormal = true;
    }
    private PlayerAnimationController GetMyPlayer()
    {
        if (Runner == null)
            return null;

        var playerObj =
            Runner.GetPlayerObject(Runner.LocalPlayer);

        if (playerObj == null)
            return null;

        return playerObj.GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        spriteOriginalSimple1 = gameManager.buttonSimple1.image.sprite;
        Animation();
        //IsNetworkReady();
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



    public override void Render()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        ChangeScenario();

        var player = GetMyPlayer();

        if (player != null && buttonMoveSpecial != null)
        {
            buttonMoveSpecial.gameObject.SetActive(
                player.CanUseSpecial()
            );
        }
    }

    //private bool IsNetworkReady()
    //{
    //    if (Object == null || !Object.IsValid || player == null)
    //    {

    //        return false;
    //    }
    //    return true;
    //}




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
        if (!canUseSimple1)
            return;
        var player = GetMyPlayer();

        if (player == null)
            return;

        player.SetAnimation(1);

        if (gameManager != null)
        {
            gameManager.Rpc_GainPoints(1);
        }

        player.AddSpecial(1);
        StartCoroutine(CooldownSimple1());
    }

    public void ClickMoveBaseSecond()
    {
        if (!canUseSimple2)
            return;
        var player = GetMyPlayer();

        if (player == null)
            return;

        player.SetAnimation(2);

        if (gameManager != null)
        {
            gameManager.Rpc_GainPoints(5);
        }

        player.AddSpecial(1);
        StartCoroutine(CooldownSimple2());
    }

    public void ClickMoveBaseThird()
    {
        if (!canUseNormal)
            return;
        var player = GetMyPlayer();

        if (player == null)
            return;

        player.SetAnimation(3);

        if (gameManager != null)
        {
            gameManager.Rpc_GainPoints(5);
        }

        player.AddSpecial(1);
        StartCoroutine(CooldownNormal());
    }

    public void ClickMoveBaseSpecial()
    {
        var player = GetMyPlayer();

        if (player == null)
            return;

        player.SetAnimation(4);

        if (gameManager != null)
        {
            gameManager.Rpc_GainPoints(10);
        }

        player.ResetSpecial();
    }
}