using UnityEngine;

public class GameData : Singleton<GameData>
{
    public DataTemplate Data { get; private set; }

    protected override void Awake()
    {
        DontDestroyOnLoad(this);
        base.Awake();
    }

    private void Start()
    {
        Data = Resources.Load<DataTemplate>("Template");
    }
}
