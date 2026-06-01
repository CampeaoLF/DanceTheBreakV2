
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
        if (Input.touchCount == 1)
        {
            painel.SetActive(false);
        }
    }
}
