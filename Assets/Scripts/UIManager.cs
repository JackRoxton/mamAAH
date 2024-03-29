﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //si l'uimanager commence au menu principal (debug)
    public bool startInMenu = false;

    [SerializeField]
    GameObject MainMenuPanel = null,
        CreditsPanel = null,
        GamePanel = null,
        GameOverPanel = null,
        WinPanel = null,
        MotherPanel = null,
        MonsterPanel = null,
        TutoPanel = null;

    [SerializeField]
    Button PlayButton = null,
        CreditsButton = null,
        CreditsBackButton = null,
        LightButton = null,
        DSButton = null,
        GameOverButton = null,
        QuitButton = null,
        TutoButton = null,
        TutoBackButton = null;


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

        if (startInMenu)
        {
            GamePanel.SetActive(false);
        }
        else
        {
            MainMenuPanel.SetActive(false);
        }
        CreditsPanel.SetActive(false);
        TutoPanel.SetActive(false);
    }

    private void Start()
    {
        LightButton.onClick.AddListener(SwitchLight);
        DSButton.onClick.AddListener(SwitchConsole);
        GameOverButton.onClick.AddListener(BackToMenu);
        PlayButton.onClick.AddListener(Play);
        CreditsButton.onClick.AddListener(Credits);
        CreditsBackButton.onClick.AddListener(CreditsBack);
        QuitButton.onClick.AddListener(Quit);
        TutoButton.onClick.AddListener(Tuto);
        TutoBackButton.onClick.AddListener(TutoBack);

        GameOverPanel.SetActive(false);
        
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
        WinPanel.SetActive(false);
        MotherPanel.SetActive(false);
        MonsterPanel.SetActive(false);
        GameManager.Instance.BackToMenu();
    }

    //lancer la partie
    void Play()
    {
        MainMenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.Instance.Play();
    }

    void Tuto()
    {
        TutoPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    void TutoBack()
    {
        TutoPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //voir les crédits
    void Credits()
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    //enlever les crédits
    void CreditsBack()
    {
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    //mauvaise fin de jeu
    public void GameOver()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void GameOverMonster()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        MonsterPanel.SetActive(true);
    }

    public void GameOverMother()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        MotherPanel.SetActive(true);
    }

    //fin où on a survécu à la nuit
    public void GameWon()
    {
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        WinPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
