using Fusion;
using UnityEngine;
using TMPro;

public class LobbyManager : NetworkBehaviour
{
    public static LobbyManager Instance;
    [Networked] public int LobbyCount { get; set; }
    [Networked] public  TickTimer startTimer { get; set; }




    public override void Spawned()
    {
        Instance = this;

        
    }

    public override void FixedUpdateNetwork()
    {
        

        if (!HasStateAuthority)
            return;

        

        if (LobbyCount >= 2 && !startTimer.IsRunning)
        {
            
            startTimer = TickTimer.CreateFromSeconds(Runner, 5f);
        }


        if (startTimer.IsRunning)
        {
           
        }

        if (startTimer.Expired(Runner))
        {
            

            Runner.LoadScene(
                LevelManager.selectedMap,
                UnityEngine.SceneManagement.LoadSceneMode.Single
            );
        }
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_EntrouLobby()
    {
        LobbyCount++;


    }
}