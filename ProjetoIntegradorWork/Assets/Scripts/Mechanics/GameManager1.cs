
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] public int score = 0;
    [SerializeField] public int specialCount = 0;

    [Header("Cooldown")]
    [SerializeField] public Image buttonCooldownImage;
    [SerializeField] public Image buttonCooldownImage2;
    [SerializeField] public Image buttonCooldownImage3;

    [Header("Screen Info")]
    [SerializeField] public GameObject background;
    [SerializeField] public TextMeshProUGUI scoreNumber;
    [SerializeField] public Button special;

   

    [SerializeField] public Button buttonSimple1;
    [SerializeField] public Button buttonSimple2;
    [SerializeField] public Button buttonNormal;


    void Start()
    {
        
    }


    void Update()
    {
        scoreNumber.text = score.ToString();

        EnabledMoveSpecial();

       if(buttonCooldownImage.fillAmount > 0)
        {
            buttonCooldownImage.fillAmount -= 0.5f * Time.deltaTime;
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
            buttonCooldownImage2.fillAmount -= 0.5f * Time.deltaTime;
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
            buttonCooldownImage3.fillAmount -= 0.5f * Time.deltaTime;
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

    private void EnabledMoveSpecial()
    {
        ButtonScript buttonScript = FindAnyObjectByType<ButtonScript>();
        if (specialCount < 10)
        {
            buttonScript.buttonMoveSpecial.SetActive(false);
        }
        
        if (!buttonScript && !buttonScript.buttonMoveSpecial) return;
        if (specialCount == 10)
        {
            buttonScript.buttonMoveSpecial.SetActive(true);
        }
        
    }
    
    public void GainPoints(int value)
    {
        score = score + value;
    }

    public void AddSpecialCount (int value)
    {
        specialCount = specialCount + value;
    }

    public void ResetSpecial()
    {
        specialCount = 0;
    }

    public void Special()
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
