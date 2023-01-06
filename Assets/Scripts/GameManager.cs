using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public LightBulb Light;
    [SerializeField]
    public Console Console;
    [SerializeField]
    Mum_script mum;
    [SerializeField]
    Monster_script monster;

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
        monster.UpdateLight(Light.lightState);
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

    public void MumIsComing()
    {
        monster.MumIsComing(true);
    }

    public void MumIsGone()
    {
        monster.MumIsComing(false);
        monster.UpdateLight(GetLightState());
    }

    public void MumIsWatching()
    {
        if (monster.advance > 2)
        {
            Debug.Log("VICTORY");
            GameWon();
            //VICTORY
        }
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
        Time.timeScale = 1;
    }

    //retour au  menu
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        NightTimer -= Time.deltaTime;
        if(NightTimer <= 0)
        {
            GameWon();
        }
    }

    //fin de jeu
    public void GameOverMonster()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOver();
    }

    public void GameOverMother(Mum_script mum)
    {
        mum.SetSprite(mum.madSprite);
        Time.timeScale = 0;
        UIManager.Instance.GameOver();
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameWon();
    }

}
