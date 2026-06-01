
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChooseAnim : MonoBehaviour
{
    private string animation;
    private bool value;

    public List<string> bottonSpecial = new List<string>();
    public List<string> bottonSimple = new List<string>();
    public List<string> bottonNormal = new List<string>();

    public GameObject simpleSelect;
    public GameObject normalSelect;
    public GameObject specialSelect;

    public int qtdMaxSimple = 2;
    public int qtdMaxNormal = 1;
    public int qtdMaxSpecial = 1;

    


    public Button nextPanelNormal;
    public Button nextPanelSpecial;
    public Button game;


    public void ChooseSimple(string name)
    {
        Debug.Log(name);

        if (!bottonSimple.Contains(name) && bottonSimple.Count < qtdMaxSimple)
        {
            bottonSimple.Add(name);
            Debug.Log("Não existe na lista");
        }
        else
        {
            Debug.Log("Existe na lista");
            bottonSimple.Remove(name);
           
        }

        Debug.Log("Quantidade de escolhas: " + bottonSimple.Count);

        // colocar essa logica dentro de um botão de submit
        if (bottonSimple.Count == qtdMaxSimple)
        {
            nextPanelNormal.gameObject.SetActive(true);
          
            
        }


    }

    public void NextPanelNormal()
    {
        simpleSelect.SetActive(false);
        normalSelect.SetActive(true);
    }
    public void ChooseNormal(string name)
    {
        if(!bottonNormal.Contains(name) && bottonNormal.Count < qtdMaxNormal)
        {
            bottonNormal.Add(name);
            Debug.Log("Não existe na lista");
        }
        else
        {
            Debug.Log("Existe na lista");
            bottonNormal.Remove(name);
        }
        Debug.Log("Quantidade de escolhas: " + bottonNormal.Count);
        if (bottonNormal.Count == qtdMaxNormal)
        {
            nextPanelNormal.gameObject.SetActive(false);
            nextPanelSpecial.gameObject.SetActive(true);
        }
    }
    public void NextPanelSpecial()
    {
        simpleSelect.SetActive(false);
        normalSelect.SetActive(false);
        specialSelect.SetActive(true);
    }
    public void ChooseSpecial(string name)
    {
        if (!bottonSpecial.Contains(name) && bottonSpecial.Count < qtdMaxSpecial)
        {
            bottonSpecial.Add(name);
            Debug.Log("Não existe na lista");
        }
        else
        {
            Debug.Log("Existe na lista");
            bottonSpecial.Remove(name);
        }
        Debug.Log("Quantidade de escolhas: " + bottonSpecial.Count);
        if (bottonSpecial.Count == qtdMaxSpecial)
        {
            game.gameObject.SetActive(true);
        }

    }

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}


