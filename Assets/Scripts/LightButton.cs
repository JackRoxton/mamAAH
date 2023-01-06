using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    public GameObject back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        back.SetActive(true);
    }
    private void OnMouseExit()
    {
        back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        GameManager.Instance.SwitchLight();
    }
}
