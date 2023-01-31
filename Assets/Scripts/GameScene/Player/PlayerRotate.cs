using UnityEngine;

namespace GameScene
{
    public class PlayerRotate
    {
        private Transform _transform;
        private readonly Vector2 _restrictY = new Vector2(-40f, 0f);

        private float _turnX;
        private float _turnY;

        public void Initialize(Transform transform)
        {
            _transform = transform;
        }

        public void HandleUpdate()
        {
            _turnX += Input.GetAxis("Mouse X");
            _turnY += Input.GetAxis("Mouse Y");
            _turnY = CheckRestricts(_turnY, _restrictY);

            _transform.localRotation = Quaternion.Euler(-_turnY, _turnX, 0f);
        }

        private float CheckRestricts(float turn, Vector2 restrict)
        {
            if (Mathf.Abs(turn) > 360f)
            {
                turn -= 360f * Mathf.Sign(turn);
            }
            return Mathf.Clamp(turn, restrict.x, restrict.y);
        }
    }
}