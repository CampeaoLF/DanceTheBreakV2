
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.UI;

public class MultiplayerController : MonoBehaviour, INetworkRunnerCallbacks
{

    public InputField nomeSala; // pega do menu
    public Text erro; //pega fo menu
    NetworkRunner runner; // será criado no clique do botão entrar
    public GameObject playerPrefab; //prefab do player
    public Canvas TelaEntrarSala; //menu da tela

    public List<SessionInfo> salasDisponiveis = new List<SessionInfo>();
    public Text ListaLobby;


    public async void EntrarSala()
    {
        if (string.IsNullOrEmpty(nomeSala.text))
        {
            Debug.LogError("O nome da sala não pode ser vazio!");
            erro.text = "O nome da sala não pode ser vazio!";
            return;
        }
        if (runner == null)
        {
            runner = gameObject.AddComponent<NetworkRunner>();
            runner.ProvideInput = true;
        }
        await runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = nomeSala.text,
            Scene = SceneRef.FromIndex(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex),
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
        TelaEntrarSala.gameObject.SetActive(false);
    }

    public async void ListarSalas()
{
    if (runner == null)
    {
        runner = gameObject.AddComponent<NetworkRunner>();
        runner.ProvideInput = true;
    }
    await runner.JoinSessionLobby(SessionLobby.Shared);
}


    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        // Spawna o jogador apenas após a cena estar totalmente carregada e sincronizada
        if (runner.LocalPlayer != PlayerRef.None && runner.GetPlayerObject(runner.LocalPlayer) == null)
        {
            var objetoDaRede = runner.Spawn(playerPrefab,
                new Vector2(0, -1),
                Quaternion.identity,
                runner.LocalPlayer);
            runner.SetPlayerObject(runner.LocalPlayer, objetoDaRede);
        }
    }




    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        salasDisponiveis = sessionList;
        Debug.Log($"Lista de salas atualizada: {salasDisponiveis.Count} salas encontradas");
        foreach (var sessao in salasDisponiveis)
        {
            Debug.Log($"Sala: {sessao.Name} - Jogadores: {sessao.PlayerCount}/{sessao.MaxPlayers}");
            ListaLobby.text += $"Sala: {sessao.Name} - Jogadores: {sessao.PlayerCount}/{sessao.MaxPlayers}\n";
        }
        if (salasDisponiveis.Count == 0)
        {
            Debug.Log("Nenhuma sala disponível no momento.");
            ListaLobby.text = "Nenhuma sala disponível no momento.";

        }
    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }
}
