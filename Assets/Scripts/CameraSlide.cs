using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    [SerializeField]
    Vector2 minPos, maxPos;

    Vector3 center;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        center = new Vector2(this.GetComponent<Camera>().pixelWidth/2, this.GetComponent<Camera>().pixelHeight/2);
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Input.mousePosition;
        targetPos -= center;
        targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
        targetPos.z = this.transform.position.z;
        targetPos.x = Mathf.Lerp(this.transform.position.x, targetPos.x, 0.05f);
        targetPos.y = Mathf.Lerp(this.transform.position.y, targetPos.y, 0.05f);
        this.transform.position = targetPos;

    }
}
