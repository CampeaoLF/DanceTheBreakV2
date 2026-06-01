
using System.Linq;

using UnityEngine;

using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [Header("Váriaveis Gerais")]
    [SerializeField] public GameObject player;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public Animator playerAnimator;
    

    [Header("Botões de movimento base")]
    [SerializeField] public Button[] buttonsMoveBase;

    [Header("Botão de movimento especial")]
    [SerializeField] public GameObject buttonMoveSpecial;

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

    void Start()
    {
        animManager = GameObject.Find("AnimManager");

        bottomSimple1 = animManager.gameObject.GetComponent<ChooseAnim>().bottonSimple.ElementAt(0);
        bottomSimple2 = animManager.gameObject.GetComponent<ChooseAnim>().bottonSimple.ElementAt(1);
        bottomNormal = animManager.gameObject.GetComponent<ChooseAnim>().bottonNormal.ElementAt(0);
        bottomSpecial = animManager.gameObject.GetComponent<ChooseAnim>().bottonSpecial.ElementAt(0);
        
    }


    void Update()
    {

        //if (gameManager.score >= 5 && cenario[0])
        //{

        //    var scenarioAtual = gameManager.background.GetComponent<SpriteRenderer>();
        //    scenarioAtual.sprite = cenario[0];
        //}
        //if (gameManager.score >= 10 && cenario[1])
        //{
        //    var scenarioAtual = gameManager.background.GetComponent<SpriteRenderer>();
        //    scenarioAtual.sprite = cenario[1];
        //}
        //if (gameManager.score >= 50 && cenario[2])
        //{
        //    var scenarioAtual = gameManager.background.GetComponent<SpriteRenderer>();
        //    scenarioAtual.sprite = cenario[2];
        //}

        if (gameManager.score >= 5)
        {
            backGround1.SetActive(true);
            backGround2.SetActive(false);
            backGround3.SetActive(false);
        }
        if (gameManager.score >= 10)
        {
            backGround1.SetActive(false);
            backGround2.SetActive(true);
            backGround3.SetActive(false);
        }
        if (gameManager.score >= 50)
        {
            backGround1.SetActive(false);
            backGround2.SetActive(false);
            backGround3.SetActive(true);
        }

    }

    public void ClickMoveBaseFirst(Button botao)
    {
        

        if (Input.touchCount == 1 && buttonsMoveBase[0])
        {
            
            var spriteAtual = player.GetComponent<SpriteRenderer>();
            spriteAtual.sprite = sprites[0];
            gameManager.GainPoints(1);
            gameManager.AddSpecialCount(1);
            playerAnimator.SetBool(bottomSimple1, true);
            playerAnimator.SetBool(bottomSimple2, false);
            playerAnimator.SetBool(bottomNormal, false);
            playerAnimator.SetBool(bottomSpecial, false);
        }
        
    }

    public void ClickMoveBaseSecond()
    {
        if (Input.touchCount == 1 && buttonsMoveBase[1])
        {
            
            var spriteAtual = player.GetComponent<SpriteRenderer>();
            spriteAtual.sprite = sprites[1];
            gameManager.GainPoints(5);
            gameManager.AddSpecialCount(1);
            playerAnimator.SetBool(bottomSimple1, false);
            playerAnimator.SetBool(bottomSimple2, true);
            playerAnimator.SetBool(bottomNormal, false);
            playerAnimator.SetBool(bottomSpecial, false);
        }

    }

    public void ClickMoveBaseThird()
    {
        if (Input.touchCount == 1 && buttonsMoveBase[2])
        {
            
            var spriteAtual = player.GetComponent<SpriteRenderer>();
            spriteAtual.sprite = sprites[2];
            gameManager.GainPoints(5);
            gameManager.AddSpecialCount(1);
            
            playerAnimator.SetBool(bottomSimple1, false);
            playerAnimator.SetBool(bottomSimple2, false);
            playerAnimator.SetBool(bottomNormal, true);
            playerAnimator.SetBool(bottomSpecial, false);
        }

    }

    public void ClickMoveBaseSpecial(Button botao)
    {
        if (Input.touchCount == 1 && buttonMoveSpecial)
        {
            var spriteAtual = player.GetComponent<SpriteRenderer>();
            spriteAtual.sprite = sprites[3];
            gameManager.GainPoints(10);
            gameManager.ResetSpecial();
            playerAnimator.SetBool(bottomSimple1, false);
            playerAnimator.SetBool(bottomSimple2, false);
            playerAnimator.SetBool(bottomNormal, false);
            playerAnimator.SetBool(bottomSpecial, true);
        }
    }


}
