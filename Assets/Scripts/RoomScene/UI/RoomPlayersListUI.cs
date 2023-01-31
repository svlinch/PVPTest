using System.Collections.Generic;
using UnityEngine;

namespace RoomScene
{
    public class RoomPlayersListUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;
        [SerializeField]
        private RectTransform _transform;

        private List<RoomPlayerUI> _playersList = new List<RoomPlayerUI>();
        private int _currentPlayersCount;

        public void AddPlayer(int index)
        {
            _currentPlayersCount++;
            CheckoutPlayersCount();

            _playersList[_currentPlayersCount - 1].CheckoutPlayer(index);
        }

        public void CheckoutPlayer(int indexInList, int correctIndex)
        {
            if (_playersList.Count > indexInList)
            {
                _playersList[indexInList].CheckoutPlayer(correctIndex);
            }
        }

        private void CheckoutPlayersCount()
        {
            if (_currentPlayersCount > _playersList.Count)
            {
                var newPlayer = Instantiate(_playerPrefab, _transform).GetComponent<RoomPlayerUI>();
                _playersList.Add(newPlayer);
            }
        }

        public void RemovePlayer()
        {
            _playersList[_playersList.Count - 1].Reset();
            _currentPlayersCount--;
        }
    }
}