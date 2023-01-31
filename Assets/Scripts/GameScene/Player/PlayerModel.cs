using UnityEngine;
using Mirror;

namespace GameScene
{
    public class PlayerModel : NetworkBehaviour
    {
        [SerializeField]
        private Material _normalMat;
        [SerializeField]
        private Material _changedMat;
        [SerializeField]
        private Renderer _renderer;

        [SyncVar(hook = nameof(HandleChangeCharged))]
        public bool Charged;

        private float _counter;

        public void SetCharged()
        {
            Charged = true;
            _counter = GameData.Instance.Data.ImmuneTime;
        }

        public void Reset()
        {
            _renderer.material = _normalMat;
            _counter = 0f;
            Charged = false;
        }

        public void Update()
        {
            if (isServer)
            {
                if (_counter > 0f && Charged)
                {
                    _counter -= Time.deltaTime;
                }
                else
                {
                    Charged = false;
                }
            }
        }

        private void HandleChangeCharged(bool old, bool correct)
        {
            _renderer.material = correct ? _changedMat : _normalMat;
        }
    }
}