using RoomScene;

namespace Mirror
{
    public class CustomRoomPlayer : NetworkRoomPlayer
    {
        public override void IndexChanged(int oldIndex, int newIndex) 
        {
            RoomUI.Instance.RoomPlayersListUI.CheckoutPlayer(index, newIndex);
        }

        public override void OnStartClient() 
        {
            RoomUI.Instance.RoomPlayersListUI.AddPlayer(index);
        }

        public override void OnStopClient()
        {
            RoomUI.Instance.RoomPlayersListUI.RemovePlayer();
        }
    }
}