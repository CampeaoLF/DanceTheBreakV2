
using Fusion;
using UnityEngine;

public class PlayerSkin : NetworkBehaviour
{
    public static PlayerSkin Local;

    public GameObject boy;
    public GameObject girl;
    [Networked]public int skinAtual { get; set; }

    public override void Render()
    {
        boy.SetActive(skinAtual == 0);
        girl.SetActive(skinAtual == 1);
    }

    public override void Spawned()
    {
        Debug.Log("Boy = " + boy.name);
        Debug.Log("Girl = " + girl.name);
        Debug.Log("PlayerSkin Spawned - InputAuthority: " + Object.HasInputAuthority);

        if (Object.HasInputAuthority)
        {
            Local = this;
        }
    }
    public void EscolherBoy()
    {
        if (Object.HasInputAuthority)
        {
            skinAtual = 0;
        }
    }

    public void EscolherGirl()
    {
        if (Object.HasInputAuthority)
        {
            skinAtual = 1;
        }
    }
}

