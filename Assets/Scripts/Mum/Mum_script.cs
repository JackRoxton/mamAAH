using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mum_script : MonoBehaviour
{
    [SerializeField] private GameObject hideLeft;
    [SerializeField] private GameObject hideRight;
    [SerializeField] private GameObject door;

    // AI
    private MumFSM_BastState AIstate;
    private MumFSM_PatrolState patrolState = new MumFSM_PatrolState();
    private MumFSM_WatchState checkState = new MumFSM_WatchState();
    private MumFSM_StandbyState standbyState = new MumFSM_StandbyState();
    public int speed = 100;

    private Coroutine checkCoroutine;
    public bool canHear;
    public bool canSee;

    private void Start()
    {
        patrolState.hideLeft = hideLeft;
        patrolState.hideRight = hideRight;
        patrolState.door = door;
        standbyState.door = door;
        ChangeState(MumState.Patrol);
    }

    private void Update()
    {
        AIstate.Update(this);
        Debug.Log("canSee : " + canSee);
    }

    public void ChangeState(MumState newState)
    {
        switch (newState)    
        {
            case MumState.Patrol:
                AIstate = patrolState;
                checkCoroutine = StartCoroutine(Check());
                break;
            case MumState.Standby:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = standbyState;
                break;
            case MumState.Watch:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = checkState;
                break;
        }
        AIstate.OnStart(this);
    }

    public void ComingToWatchYou()
    {
        StopCoroutine(checkCoroutine);
        patrolState.MoveToDoor();
    }
    // Coming, watch you
    IEnumerator Check()
    {
        yield return new WaitForSeconds(12);
        GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
        patrolState.MoveToDoor();
    }
    
    public void ConsoleMakeNoise()
    {
        if (!canHear) return;
        if (AIstate == standbyState) ChangeState(MumState.Watch);
        else ChangeState(MumState.Standby);
    }

    public void LightIsLit()
    {
        if (!canSee) return;
        ComingToWatchYou();
    }
}