using UnityEngine;
using TMPro;

namespace GameScene
{
    public class ScoreElementUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;
        [SerializeField]
        private TextMeshProUGUI _playerText;

        public void Initialize(int playerIndex)
        {
            _playerText.text = string.Format(format: $"Player {playerIndex}:");
            Checkout(0);
        }

        public void Checkout(int newScore)
        {
            _scoreText.text = newScore.ToString();
        }

        public void Reset()
        {
            gameObject.SetActive(false);
        }
    }
}