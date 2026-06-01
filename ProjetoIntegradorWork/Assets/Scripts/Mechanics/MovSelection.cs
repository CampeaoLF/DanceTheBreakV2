
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MovSelection : MonoBehaviour
{
    public Button[] simpleMov = new Button[10];
    public Button [] normalMov;
    public Button [] specialMov;
    public int moveCount = 0;
    public TextMeshProUGUI contador;

    public Button [] selectedMov;
    void selectMov()
    {
        
    }

    public void OnClick()
    {
        if (Input.touchCount == 1)
        {
            // Corrigido: Inicialização correta da lista de botões
            List<Button> simpleMovList = new List<Button> { simpleMov[0], simpleMov[1], simpleMov[2] };

            //int index = simpleMovList.IndexOf(simpleMov[0]);

            //Debug.Log("Botão selecionado: " + simpleMovList[index].name);
            moveCount++;
            contador.text = moveCount.ToString();

            int index = simpleMovList.IndexOf(simpleMov[0]);

            Debug.Log("Botão selecionado: " + simpleMovList[index].name);
        }
    }
}
