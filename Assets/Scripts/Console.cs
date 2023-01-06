using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    //état allumé éteint
    public bool state = false;

    [SerializeField]
    Light light = null;

    void Start()
    {
        GameManager.Instance.Console = this;
    }

    private void OnMouseUp()
    {
        GameManager.Instance.SwitchConsole();
    }

    //allumer et éteindre la lumière
    public void SwitchState()
    {
        if (state)
        {
            //this.GetComponent<SpriteRenderer>().color = Color.black;
            state = false;
            light.gameObject.SetActive(false);
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.white;
            state = true;
            light.gameObject.SetActive(true);
        }
    }

}
