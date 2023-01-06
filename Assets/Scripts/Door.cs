using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite Closed = null, SOpened = null, Opened = null;

    public void Open()
    {
        this.GetComponent<SpriteRenderer>().sprite = Opened;
    }

    public void SOpen()
    {
        this.GetComponent<SpriteRenderer>().sprite = SOpened;
    }

    public void Close()
    {
        this.GetComponent<SpriteRenderer>().sprite = Closed;
    }



}
