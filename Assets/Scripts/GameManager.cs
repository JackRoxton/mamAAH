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

    public AudioClip MonstDead;
    public AudioClip MomDead;

    float NightTimer = 120;

    bool GameOver = false;

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

    private void Start()
    {
        SwitchConsole();
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
        GameOver = false;
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
        if (GameOver)
        {
            Camera.main.transform.position = new Vector3(0, 1.6f, -10) + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        }
        else
            Camera.main.transform.position = new Vector3(0, 1.6f, - 10);
    }

    //fin de jeu
    public void GameOverMonster()
    {
        if (GameOver) return;
        GameOver = true;
        Time.timeScale = 0;
        UIManager.Instance.GameOverMonster();
        AudioManager.Instance.Play(MonstDead);
    }

    public void GameOverMother(Mum_script mum)
    {
        if (GameOver) return;
        GameOver = true;
        mum.SetSprite(mum.madSprite);
        Time.timeScale = 0;
        UIManager.Instance.GameOverMother();
        AudioManager.Instance.Play(MomDead);
    }

    public void GameWon()
    {
        if (GameOver) return;
        GameOver = true;
        Time.timeScale = 0;
        UIManager.Instance.GameWon();
    }

}
