using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    

    [Networked, OnChangedRender(nameof(UpdateScore))] public int score { get; set; }
    [SerializeField] public int specialCount = 0;

    [Header("Screen Info")]
    [SerializeField] public GameObject background;
    [SerializeField] public TextMeshProUGUI scoreNumber;
    [SerializeField] public Button special;

    [SerializeField] public Button buttonSimple1;
    [SerializeField] public Button buttonSimple2;
    [SerializeField] public Button buttonNormal;

    [Header("Cooldown")]
    [SerializeField] public Image buttonCooldownImage;
    [SerializeField] public Image buttonCooldownImage2;
    [SerializeField] public Image buttonCooldownImage3;

    

    void Start()
    {

    }

    void UpdateScore()
    {
        scoreNumber.text = score.ToString();
        if (buttonCooldownImage.fillAmount > 0)
        {
            buttonCooldownImage.fillAmount -= 20f * Time.deltaTime;
            buttonSimple1.enabled = false;
            buttonSimple2.enabled = false;
            buttonNormal.enabled = false;


        }
        else
        {
            buttonSimple1.enabled = true;
            buttonSimple2.enabled = true;
            buttonNormal.enabled = true;
        }

        if (buttonCooldownImage2.fillAmount > 0)
        {
            buttonCooldownImage2.fillAmount -= 20f * Time.deltaTime;
            buttonSimple1.enabled = false;
            buttonSimple2.enabled = false;
            buttonNormal.enabled = false;
        }
        else
        {
            buttonSimple1.enabled = true;
            buttonSimple2.enabled = true;
            buttonNormal.enabled = true;
        }

        if (buttonCooldownImage3.fillAmount > 0)
        {
            buttonCooldownImage3.fillAmount -= 20f * Time.deltaTime;
            buttonSimple1.enabled = false;
            buttonSimple2.enabled = false;
            buttonNormal.enabled = false;
        }
        else
        {
            buttonSimple1.enabled = true;
            buttonSimple2.enabled = true;
            buttonNormal.enabled = true;
        }
    }



    public override void FixedUpdateNetwork()
    {
    
        if (HasStateAuthority == false)
            return;


        EnabledMoveSpecial();
        UpdateScore();
    }


    private void EnabledMoveSpecial()
    {
        ButtonScript buttonScript = FindAnyObjectByType<ButtonScript>();
        if (buttonScript == null || buttonScript.buttonMoveSpecial == null) return;

        if (specialCount < 10)
        {
            buttonScript.buttonMoveSpecial.gameObject.SetActive(false);
        }
        else if (specialCount == 10)
        {
            buttonScript.buttonMoveSpecial.gameObject.SetActive(true);
        }
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void Rpc_GainPoints(int value)
    {
        score = score + value;
    }

    public void AddSpecialCount(int value)
    {
        specialCount = specialCount + value;
    }
    public void ResetSpecial()
    {
        specialCount = 0;
    }
    //[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void Rpc_Special()
    {
        var buttonSpecial = special.GetComponent<Button>();
        if (specialCount == 10)
        {
            buttonSpecial.interactable = true;
        }

        if (specialCount <= 9)
        {
            buttonSpecial.interactable = false;
        }
    }
    public void ButtonCoolDown()
    {

        buttonCooldownImage.fillAmount = 1;
        buttonCooldownImage2.fillAmount = 1;
        buttonCooldownImage3.fillAmount = 1;

    }
}
