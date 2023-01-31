using UnityEngine;

namespace RoomScene
{
    public class RoomUI : Singleton<RoomUI>
    {
        [SerializeField]
        private RoomPlayersListUI _roomPlayersListUI;
        public RoomPlayersListUI RoomPlayersListUI { get { return _roomPlayersListUI; } }
    }
}
