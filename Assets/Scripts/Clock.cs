using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    GameObject shortArm;
    [SerializeField]
    GameObject longArm;

    float timer = 120;
    float shortArmRotation = 0;
    float longArmRotation = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        RotateArms();
    }

    void RotateArms()
    {
        shortArmRotation -= Time.deltaTime;
        longArmRotation -= Time.deltaTime * 60;

        shortArm.transform.rotation = Quaternion.Euler(0, 0, shortArmRotation);
        longArm.transform.rotation = Quaternion.Euler(0, 0, longArmRotation);
    }
}
