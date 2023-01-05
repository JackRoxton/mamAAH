using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite Closed = null, Opened = null;

    //état de la porte false à fermé
    public bool doorState = false;


    public void Open()
    {
        this.GetComponent<SpriteRenderer>().sprite = Opened;
        doorState = true;
    }

    public void Close()
    {
        this.GetComponent<SpriteRenderer>().sprite = Closed;
        doorState = false;
    }
}
