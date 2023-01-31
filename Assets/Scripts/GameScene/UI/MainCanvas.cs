using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace GameScene
{
    public class MainCanvas : Singleton<MainCanvas>
    {
        [SerializeField]
        private Button _leaveButton;
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private ScoreListUI _scoreListUI;
        public ScoreListUI ScoreListUI { get { return _scoreListUI; } }

        void Start()
        {
            _leaveButton.onClick.AddListener(HandleLeave);
        }

        public void CheckoutSliderValue(float max, float current)
        {
            _slider.value = 1f - current / max;
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
    }
}