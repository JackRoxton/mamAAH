using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_StandyState : MumFSM_BastState
{
    public GameObject door;

    public override void OnStart(Mum_script mum)
    {
        mum.GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
    }

    public override void Update(Mum_script mum)
    {
        if (Vector3.Distance(mum.transform.position, door.transform.position) > 1)
        {
            // Move
        }
    }
}
