using UnityEngine;
using TMPro;

public class WinCanvas : Singleton<WinCanvas>
{
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private TextMeshProUGUI _playerText;

    public void SetState(bool state, int index = 0)
    {
        if (state)
        {
            _playerText.text = string.Format($"Player {index} is a winner");
        }
        _canvas.enabled = state;
    }
}
