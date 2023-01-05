using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_StandbyState : MumFSM_BastState
{
    public GameObject door;
    private float timer;

    public override void OnStart(Mum_script mum)
    {
        mum.canHear = true;
        timer = 5.0f;
        mum.GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
    }

    public override void Update(Mum_script mum)
    {
        if (Vector3.Distance(mum.transform.position, door.transform.position) > .1f)
        {
            // Move
            mum.transform.position = Vector3.MoveTowards(mum.transform.position, door.transform.position, mum.speed * Time.deltaTime);
        }
        else
        {
            mum.canSee = false;
            timer -= Time.deltaTime;
            if (GameManager.Instance.GetConsoleState()) mum.ChangeState(MumState.Watch);
        }
    }

    public void Watch(Mum_script mum)
    {
        mum.ChangeState(MumState.Watch);
    }
}
