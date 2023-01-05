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
    [SerializeField]
    Mum_script mum;
    

    float NightTimer = 120;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("GameManager instance not found");

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

    //allumer et éteindre la lumière
    public void SwitchLight()
    {
        Light.SwitchLight();
        if (Light.lightState) mum.LightIsLit();
    }

    //voir si la lumière est allumée
    public bool GetLightState()
    {
        return Light.lightState;
    }

    //allumer et éteindre la console
    public void SwitchConsole()
    {
        Console.SwitchState();
        if (Console.state) mum.ConsoleMakeNoise();
    }

    //voir si la console est allumée
    public bool GetConsoleState()
    {
        return Console.state;
    }

    public bool isVulnerable()
    {
        return GetConsoleState() || GetLightState();
    }

    //voir le timer
    public float GetTime()
    {
        return NightTimer;
    }

    //lancer une partie
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    //retour au  menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        NightTimer -= Time.deltaTime;
        if(NightTimer <= 0)
        {
            GameOver();
        }
    }

    //fin de jeu
    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOver();
    }

}
