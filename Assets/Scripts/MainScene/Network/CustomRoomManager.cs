using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

namespace Mirror
{
    public class CustomRoomManager : NetworkRoomManager
    {
        private List<PlayerController> _gameScenePlayers = new List<PlayerController>();

        private Action RoundFinished;
        private Action RoundReset;

        public void SubscribeFinish(Action callback)
        {
            RoundFinished += callback;
        }

        public void UnsubscribeFinish(Action callback)
        {
            RoundFinished -= callback;
        }

        public void SubscribeReset(Action callback)
        {
            RoundReset += callback;
        }

        public void UnsubscribeReset(Action callback)
        {
            RoundReset -= callback;
        }

        public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnectionToClient conn, GameObject roomPlayer, GameObject gamePlayer)
        {
            var playerController = gamePlayer.GetComponent<PlayerController>();
            _gameScenePlayers.Add(playerController);

            var scoreHolder = gamePlayer.GetComponent<PlayerScoreHolder>();
            scoreHolder.Index = roomPlayer.GetComponent<CustomRoomPlayer>().index;
            return true;
        }

        public void FullReset()
        {
            StartCoroutine(ResetDelay());
        }

        private IEnumerator ResetDelay()
        {
            RoundFinished?.Invoke();

            yield return new WaitForSeconds(5f);
            foreach (var player in _gameScenePlayers)
            {
                if (player != null)
                {
                    player.GetComponent<PlayerScoreHolder>().Score = 0;
                }
            }

            RoundReset?.Invoke();
        }
    }
}