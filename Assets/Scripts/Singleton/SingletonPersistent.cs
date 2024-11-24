using UnityEngine;

public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if ((Object)instance == (Object)null)
            {
                instance = Object.FindObjectOfType<T>();
                if ((Object)instance == (Object)null)
                {
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    gameObject.hideFlags = HideFlags.DontSave;
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if ((Object)instance == (Object)null)
        {
            instance = (this as T);
        }
        else if (instance != this)
        {
            Object.Destroy(base.gameObject);
        }
        Object.DontDestroyOnLoad(base.gameObject);
    }
}
