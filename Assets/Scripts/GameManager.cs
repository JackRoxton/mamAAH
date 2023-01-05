using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    LightBulb Light;
    [SerializeField]
    Console Console;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("AudioManager instance not found");

            return instance;
        }
    }
    void Awake()
    {
        if (instance)
            Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void SwitchLight()
    {
        Light.SwitchLight();
    }

    public void SwitchConsole()
    {
        Console.SwitchState();
    }
}
