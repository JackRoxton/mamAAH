﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_StandbyState : FSM_BaseState
{
    public GameObject door;
    private float timer;

    public override void OnStart(Mum_script mum)
    {
        mum.canHear = true;
        timer = 5.0f;
        mum.GetComponent<SpriteRenderer>().sprite = mum.weirdSprite;
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
            if (timer < 0) mum.ChangeState(MumState.Patrol);
            if (GameManager.Instance.GetConsoleState()) mum.ChangeState(MumState.Watch);
        }
    }

    public void Watch(Mum_script mum)
    {
        if (!mum.canSee)
            mum.ChangeState(MumState.Watch);
    }
}
