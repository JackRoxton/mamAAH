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

    float NightTimer = 120;

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

    public float GetTime()
    {
        return NightTimer;
    }

    void Update()
    {
        NightTimer -= Time.deltaTime;
        if(NightTimer <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOver();
    }

}
