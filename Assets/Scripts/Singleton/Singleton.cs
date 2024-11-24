public class Singleton<T> where T : new()
{
	protected static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new T();
			}
			return instance;
		}
	}

	public static void Release()
	{
		instance = default(T);
	}
}
