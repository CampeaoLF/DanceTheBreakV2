using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    public void EscolherBoy()
    {
        PlayerData.SkinEscolhida = Skin.bBoy;
        Debug.Log("Boy Selecionado");
    }

    public void EscolherGirl()
    {
        PlayerData.SkinEscolhida = Skin.bGirl;
        Debug.Log("Girl Selecionada");
    }
}
