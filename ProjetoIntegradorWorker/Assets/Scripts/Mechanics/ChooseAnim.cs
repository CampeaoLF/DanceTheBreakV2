using Fusion;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseAnim : NetworkBehaviour
{
    private string animation;
    private bool value;

    public List<string> bottonSpecial = new List<string>();
    public List<string> bottonSimple = new List<string>();
    public List<string> bottonNormal = new List<string>();

    public GameObject simpleSelect;
    public GameObject normalSelect;
    public GameObject specialSelect;
    public GameObject lobbyP;

    public int qtdMaxSimple = 2;
    public int qtdMaxNormal = 1;
    public int qtdMaxSpecial = 1;

    public GameObject Runner;

    public GameObject refBBoy;
    public GameObject refBGirl;


    public Button nextPanelNormal;
    public Button nextPanelSpecial;
    public Button game;
    public Button lobby;


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
            lobby.gameObject.SetActive(true);
            if (LobbyManager.Instance != null)
            {
                LobbyManager.Instance.RPC_EntrouLobby();
                
            }
        }

    }

    public void NextPanelLobby()
    {
        simpleSelect.SetActive(false);
        normalSelect.SetActive(false);
        specialSelect.SetActive(false);
        lobbyP.SetActive(true);
    }

    public void MainGame()
    {
        
        NetworkRunner runner = FindObjectOfType<NetworkRunner>();

        if (runner != null && runner.IsRunning)
        {
            
            runner.LoadScene("MainGame", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        else
        {
            
            SceneManager.LoadScene("MainGame");
        }
    }

    void Update()
    {
        if (LobbyManager.Instance == null)
            return;

        if (LobbyManager.Instance.LobbyCount >= 1)
            refBBoy.SetActive(true);

        if (LobbyManager.Instance.LobbyCount >= 2)
            refBGirl.SetActive(true);

        if (game != null)
        {
            game.gameObject.SetActive(
                LobbyManager.Instance.LobbyCount >= 2
            );
        }
    }
    void Start()
    {
        refBBoy.SetActive(false);
        refBGirl.SetActive(false);

        DontDestroyOnLoad(this);
    }
}


