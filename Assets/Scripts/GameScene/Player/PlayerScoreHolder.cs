using Mirror;

namespace GameScene
{
    public class PlayerScoreHolder : NetworkBehaviour
    {
        [SyncVar]
        public int Index;

        [SyncVar(hook = nameof(HandleChangeScore))]
        public int Score;

        public override void OnStartClient()
        {
            MainCanvas.Instance.ScoreListUI.AddPlayer(Index);
        }

        public override void OnStopClient()
        {
            MainCanvas.Instance.ScoreListUI.RemovePlayer(Index);
        }

        public void PlusScore()
        {
            Score++;
        }

        public void Reset()
        {
            WinCanvas.Instance.SetState(false);
        }

        private void HandleChangeScore(int oldScore, int newScore)
        {
            MainCanvas.Instance.ScoreListUI.CheckoutPlayer(Index, newScore);

            if (newScore == GameData.Instance.Data.HitsToWin)
            {
                WinCanvas.Instance.SetState(true, Index);
                (NetworkManager.singleton as CustomRoomManager).FullReset();
            }
        }
    }
}