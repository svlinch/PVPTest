using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class ScoreListUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _scoreElementPrefab;
        private List<ScoreElementUI> _scoreList = new List<ScoreElementUI>();

        public void AddPlayer(int index)
        {
            var newElement = Instantiate(_scoreElementPrefab, transform).GetComponent<ScoreElementUI>();
            newElement.Initialize(index);
            _scoreList.Add(newElement);
        }

        public void RemovePlayer(int index)
        {
            _scoreList[index].Reset();
        }

        public void CheckoutPlayer(int index, int newScore)
        {
            _scoreList[index].Checkout(newScore);
        }
    }
}