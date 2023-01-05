using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Button LightButton = null;
    [SerializeField]
    Button DSButton = null;

    private static UIManager instance;
    public static UIManager Instance
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

    private void Start()
    {
        LightButton.onClick.AddListener(SwitchLight);
        DSButton.onClick.AddListener(SwitchConsole);
    }

    void SwitchLight()
    {
        GameManager.Instance.SwitchLight();
    }

    void SwitchConsole()
    {
        GameManager.Instance.SwitchConsole();
    }
}
