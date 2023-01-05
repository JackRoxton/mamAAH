using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //si l'uimanager commence au menu principal (debug)
    public bool startInMenu = false;

    [SerializeField]
    GameObject MainMenuPanel = null;
    [SerializeField]
    GameObject GamePanel = null;
    [SerializeField]
    GameObject GameOverPanel = null;

    [SerializeField]
    Button PlayButton = null;
    [SerializeField]
    Button LightButton = null;
    [SerializeField]
    Button DSButton = null;
    [SerializeField]
    Button GameOverButton = null;



    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("UIManager instance not found");

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
        LightButton.onClick.AddListener(SwitchLight);
        DSButton.onClick.AddListener(SwitchConsole);
        GameOverButton.onClick.AddListener(BackToMenu);
        PlayButton.onClick.AddListener(Play);

        GameOverPanel.SetActive(false);
        if (startInMenu)
        {
            GamePanel.SetActive(false);
        }
        else
        {
            MainMenuPanel.SetActive(false);
        }
    }

    //allumer et éteindre la lumière
    void SwitchLight()
    {
        GameManager.Instance.SwitchLight();
    }

    // allumer et éteindre la console
    void SwitchConsole()
    {
        GameManager.Instance.SwitchConsole();
    }

    // retour au menu
    void BackToMenu()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //lancer la partie
    void Play()
    {
        GameManager.Instance.Play();
        MainMenuPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    //fin de jeu
    public void GameOver()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
