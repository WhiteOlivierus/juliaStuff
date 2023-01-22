using UnityEngine;

public abstract class SingleSceneSingleton<T> : MonoBehaviour where T : SingleSceneSingleton<T>
{
    private static readonly string NO_SINGLE_SCENE_SINGLETON_ERROR_MESSAGE = $"{typeof(T).Name}: "
                                                                                + "SingleSceneSingleton instance is not set! "
                                                                                + "Did you implement the SetSingleton function properly? "
                                                                                + "It is called in Awake()";

    private static bool showedWarning = false;
    private static WaitUntil waitUntil = null;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (!Exists && Application.isPlaying && !showedWarning)
            {
                Debug.LogWarning(NO_SINGLE_SCENE_SINGLETON_ERROR_MESSAGE);
                showedWarning = true;
            }
            return instance;
        }
    }

    public static bool Exists { get; private set; }

    protected abstract void Awake();

    protected void SetInstance(T owner)
    {
        instance = owner;
        Exists = instance != null;
    }

    public static WaitUntil WaitForLoaded()
    {
        if (waitUntil == null)
            waitUntil = new WaitUntil(() => { return Exists; });

        return waitUntil;
    }

    protected virtual void OnDestroy()
    {
        if (instance != this)
            return;

        instance = null;
        Exists = false;
    }
}
