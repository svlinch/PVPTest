using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DataTemlate")]
public class DataTemplate : ScriptableObject
{
    [SerializeField]
    private float _impuls;
    public float Impuls { get { return _impuls; } }

    [SerializeField]
    private float _immuneTime;
    public float ImmuneTime { get { return _immuneTime; } }

    [SerializeField]
    private int _hitsToWin;
    public int HitsToWin { get { return _hitsToWin; } }

    [SerializeField]
    private float _resetDelay;
    public float ResetDelay { get { return _resetDelay; } }
}
