using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    [SerializeField]
    Vector2 minPos, maxPos;

    Vector2 center;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Input.mousePosition;
        Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
        Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
        this.transform.position = targetPos - center;
    }
}
