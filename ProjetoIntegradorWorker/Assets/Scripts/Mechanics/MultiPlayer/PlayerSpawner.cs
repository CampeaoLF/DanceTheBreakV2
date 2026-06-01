using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] public NetworkObject playerPrefab;
    [SerializeField] private NetworkObject bGirlPrefab;
    [SerializeField] private ButtonScript buttonScript;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            var networkObject = Runner.Spawn(playerPrefab, Vector2.zero, Quaternion.identity, player); // prefab escolhido, position 0,0,0 , rotação padrão e autoridade de Input

            Runner.SetPlayerObject(player, networkObject);

            if (buttonScript != null)
            {
                buttonScript.player = networkObject;
            }
            buttonScript = FindFirstObjectByType<ButtonScript>();

        }
        if (player == Runner.LocalPlayer)
        {
            var networkObject = Runner.Spawn(bGirlPrefab, Vector2.zero, Quaternion.identity, player); // prefab escolhido, position 0,0,0 , rotação padrão e autoridade de Input

            Runner.SetPlayerObject(player, networkObject);

            if (buttonScript != null)
            {
                buttonScript.player = networkObject;
            }
            buttonScript = FindFirstObjectByType<ButtonScript>();

        }

    }

}
