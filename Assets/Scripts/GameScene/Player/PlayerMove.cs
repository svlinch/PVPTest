using UnityEngine;

namespace GameScene
{
    public class PlayerMove
    {
        private Transform _transform;
        private Rigidbody _rigidbody;
        private float _speed;
        private float _force;

        private Vector3 _change;

        //задержка между рывками
        private const float Cooldown = 2f;
        private float _cooldown;

        private bool _chargePressed;

        public void Initialize(Transform transform, float speed, float force)
        {
            _transform = transform;
            _speed = speed;
            _force = force;
            _rigidbody = _transform.GetComponent<Rigidbody>();
        }

        public bool HandleUpdate()
        {
            CheckoutInputs();
            return _cooldown > (Cooldown - 1f);
        }

        public void HandleFixedUpdate()
        {
            _rigidbody.velocity += _rigidbody.rotation * _change * Time.fixedDeltaTime * _speed;

            if (_chargePressed && _cooldown <= 0f)
            {
                _rigidbody.AddRelativeForce(_change * _force, ForceMode.Impulse);
                _cooldown = Cooldown;
            }
        }

        private void CheckoutInputs()
        {
            var _horizontal = Input.GetAxis("Horizontal");
            var _vertical = Input.GetAxis("Vertical");
            if (_cooldown > 0f)
            {
                _cooldown -= Time.deltaTime;
                MainCanvas.Instance.CheckoutSliderValue(Cooldown, _cooldown);
            }

            _change = new Vector3(_horizontal, 0f, _vertical);
            _change = Vector3.ClampMagnitude(_change, 1f);

            _chargePressed = Input.GetMouseButton(0);

        }
    }
}