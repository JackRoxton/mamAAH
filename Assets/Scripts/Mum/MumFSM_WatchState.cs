﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_WatchState : FSM_BaseState
{
    private float timer = 2.0f;

    public override void OnStart(Mum_script mum)
    {
        timer = 2.0f;
        mum.transform.Translate(-Vector3.forward * 3);
        mum.canSee = true;
        mum.canHear = true;
        GameManager.Instance.MumIsComing();
        GameManager.Instance.MumIsWatching();
        mum.SetSprite(mum.watchSprite);
        mum.flipSprite(false);
        mum.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public override void Update(Mum_script mum)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            mum.ChangeState(MumState.Patrol);
        if (timer < 1.6f)
            if (GameManager.Instance.isVulnerable())
                GameManager.Instance.GameOverMother(mum);
    }
}
