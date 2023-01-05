using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_CheckState : MumFSM_BastState
{
    private float timer = 2.0f;

    public override void OnStart(Mum_script mum)
    {
        timer = 2.0f;
        mum.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public override void Update(Mum_script mum)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            mum.ChangeState(MumState.Patrol);    
    }
}
