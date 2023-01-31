using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace RoomScene
{
    public class RoomButtonsUI : MonoBehaviour
    {
        [SerializeField]
        private Button _leaveButton;
        [SerializeField]
        private Button _startButton;

        private void Start()
        {
            if (NetworkServer.active)
            {
                _startButton.interactable = true;
                _startButton.onClick.AddListener(HandleStart);
            }
            else
            {
                _startButton.interactable = false;
            }
            _leaveButton.onClick.AddListener(HandleLeave);
        }

        private void HandleLeave()
        {
            if (NetworkServer.active && NetworkClient.isConnected)
            {
                NetworkManager.singleton.StopHost();
            }
            else
            {
                NetworkManager.singleton.StopClient();
            }
        }

        private void HandleStart()
        {
            var manager = NetworkManager.singleton as NetworkRoomManager;
            manager.ServerChangeScene(manager.GameplayScene);
        }
    }
}