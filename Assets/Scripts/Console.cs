using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    //état allumé éteint
    public bool state = true;

    [SerializeField]
    Light light = null;

    [SerializeField]
    GameObject sprites;

    Vector3 basePos;
    Vector3 hidePos;

    void Start()
    {
        GameManager.Instance.Console = this;
        basePos = this.transform.position;
        hidePos = new Vector3(basePos.x, basePos.y - 5);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.SwitchConsole();
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
            state = false;
            //light.gameObject.SetActive(false);
            sprites.transform.position = hidePos;
        }
        else
        {
            state = true;
            //light.gameObject.SetActive(true);
            sprites.transform.position = basePos;
        }
    }

}
