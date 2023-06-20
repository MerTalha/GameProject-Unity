using UnityEngine;

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T:MonoBehaviour
{
    //Oyuna ba�land��� zaman tek bir Player game objesinin olmas�n� sa�layan kod
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
