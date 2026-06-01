using UnityEngine;


public class ClosePanelScript : MonoBehaviour
{
    public GameObject painel;


    void Start()
    {
        
    }

    
    void Update()
    {
        
        

    }

public void OnClick()
    {
        if (painel != null)
        {
            painel.SetActive(false);
        }
    }
}
