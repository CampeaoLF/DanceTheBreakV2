
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static string selectedMap;
    public ChooseAnim chooseAnim;

    public void SelectMap(string mapName)
    {
        selectedMap = mapName;

        
        chooseAnim.levelSelect.SetActive(false);
        chooseAnim.lobbyP.SetActive(true);
    }

    public void GoToLobby()
    {
        if (string.IsNullOrEmpty(selectedMap))
        {
            
            return;
            
        }
       


    }
}
