using UnityEngine;

public abstract class Singleton<T>: MonoBehaviour where T:Component
{
    public static T Instance;
    protected virtual void Awake()
    {
        Instance = this as T;
    }
}
