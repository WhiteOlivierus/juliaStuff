using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static readonly string TWO_SINGLETONS_ERROR = $"{typeof(T).Name}: "
                                                          + "Something went really wrong - there should never be more than 1 singleton! "
                                                          + "Reopening the scene might fix it.";

    private static readonly string SINGLETON_NAME = "(singleton) " + typeof(T).ToString();

    private static bool applicationIsQuitting = false;
    public static bool Exists { get; private set; }
    private static object lockObject = new object();
    private static WaitUntil waitUntil = null;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
                return null;

            if (!Exists)
                return Init();

            lock (lockObject)
                return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private static T Init()
    {
        if (applicationIsQuitting)
            return null;

        lock (lockObject)
        {
            if (instance != null)
            {
                Exists = true;
                return instance;
            }

            instance = (T)FindObjectOfType(typeof(T));

            if (FindObjectsOfType(typeof(T)).Length > 1)
            {
                Debug.LogError(TWO_SINGLETONS_ERROR);
                return instance;
            }

            if (instance == null)
            {
                GameObject singleton = new GameObject { name = SINGLETON_NAME };

                instance = singleton.AddComponent<T>();

                DontDestroyOnLoad(singleton);
            }

            Exists = true;

            return instance;
        }
    }

    public static WaitUntil WaitForLoaded()
    {
        if (waitUntil == null)
            waitUntil = new WaitUntil(() => { return Exists; });

        return waitUntil;
    }

    protected virtual void OnDestroy()
    {
        applicationIsQuitting = true;
        Exists = false;
    }
}
