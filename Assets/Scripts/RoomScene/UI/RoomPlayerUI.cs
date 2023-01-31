using UnityEngine;
using TMPro;

namespace RoomScene
{
    public class RoomPlayerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textComponent;
        [SerializeField]
        private GameObject _gameObject;

        public void CheckoutPlayer(int index)
        {
            _textComponent.text = string.Format($"Player {index}");
            if (!_gameObject.activeInHierarchy)
            {
                _gameObject.SetActive(true);
            }
        }

        public void Reset()
        {
            if (_gameObject != null)
            {
                _gameObject.SetActive(false);
            }
        }
    }
}