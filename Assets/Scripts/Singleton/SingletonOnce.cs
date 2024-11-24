using UnityEngine;

public class SingletonOnce<T> : MonoBehaviour where T : Component
{
	protected static T instance;

	public static T Instance => instance;

	protected virtual void Awake()
	{
		if ((Object)instance == (Object)null)
		{
			instance = (this as T);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		if (instance == this)
		{
			instance = (T)null;
		}
	}
}
