using Fusion;
using UnityEngine;

public class LobbyManager : NetworkBehaviour
{
    public static LobbyManager Instance;
    [Networked] public int LobbyCount { get; set; }

    [Networked] public bool P1Ready { get; set; }
    [Networked] public bool P2Ready { get; set; }
    //[Networked] public int ReadyCount { get; set; }

    private bool partidaIniciada;

    public override void Spawned()
    {
        Instance = this;
        Debug.Log("LobbyManager Spawnado");
    }

    //[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    //public void RPC_SetReady()
    //{
    //    ReadyCount++;

    //    Debug.Log($"Jogadores prontos: {ReadyCount}");
    //}

    public override void FixedUpdateNetwork()
    {
        if (LobbyCount >= 2)
        {
            Debug.Log("Todos chegaram ao lobby");
        }
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_EntrouLobby()
    {
        LobbyCount++;

        Debug.Log($"Jogadores no lobby: {LobbyCount}");
    }
}