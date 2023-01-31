using UnityEngine;
using Mirror;

namespace GameScene
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField]
        private PlayerScoreHolder _scoreHolder;
        [SerializeField]
        private PlayerModel _playerModel;
        [SerializeField]
        private float _speed;

        [SyncVar]
        public bool Charging;

        private PlayerRotate _playerRotate;
        private PlayerMove _playerMove;
        private bool _canControl;

        public override void OnStartLocalPlayer()
        {
            if (isLocalPlayer)
            {
                _canControl = true;
                _playerRotate = new PlayerRotate();
                _playerRotate.Initialize(transform);
                _playerMove = new PlayerMove();
                _playerMove.Initialize(transform, _speed, GameData.Instance.Data.Impuls);

                var roomManager = NetworkManager.singleton as CustomRoomManager;
                roomManager.SubscribeFinish(BlockPlayer);
                roomManager.SubscribeReset(ResetPlayer);
            }
        }

        private void BlockPlayer()
        {
            _canControl = false;
            Charging = false;
            _playerModel.Reset();
        }

        private void ResetPlayer()
        {
            _scoreHolder.Reset();
            transform.position = (NetworkManager.singleton as NetworkRoomManager).GetStartPosition().position;
            _canControl = true;
        }

        private void Update()
        {
            if (!isLocalPlayer || !_canControl)
            {
                return;
            }

            _playerRotate.HandleUpdate();
            Charging = _playerMove.HandleUpdate();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer || !_canControl)
            {
                return;
            }
            _playerMove.HandleFixedUpdate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (isServer && collision.collider.tag.Equals("Player") && Charging)
            {
                var model = collision.gameObject.GetComponent<PlayerModel>();
                if (model.Charged)
                {
                    return;
                }
                _scoreHolder.PlusScore();
                model.SetCharged();
            }
        }

        private void OnDestroy()
        {
            if (isLocalPlayer)
            {
                var roomManager = NetworkManager.singleton as CustomRoomManager;
                if (!roomManager)
                {
                    return;
                }
                roomManager.UnsubscribeFinish(BlockPlayer);
                roomManager.UnsubscribeReset(ResetPlayer);
            }
        }
    }
}