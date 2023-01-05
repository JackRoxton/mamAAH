using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mum_script : MonoBehaviour
{
    [SerializeField] private GameObject hideLeft;
    [SerializeField] private GameObject hideRight;
    [SerializeField] private GameObject door;

    // AI
    private FSM_BaseState AIstate;
    private MumFSM_PatrolState patrolState = new MumFSM_PatrolState();
    private MumFSM_WatchState watchState = new MumFSM_WatchState();
    private MumFSM_StandbyState standbyState = new MumFSM_StandbyState();
    public int speed = 100;

    private Coroutine checkCoroutine;
    [HideInInspector] public bool canHear;
    [HideInInspector] public bool canSee;

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
    }

    public void ChangeState(MumState newState)
    {
        if (newState != MumState.Watch) GameManager.Instance.MumIsGone();
        switch (newState)    
        {
            case MumState.Patrol:
                AIstate = patrolState;
                checkCoroutine = StartCoroutine(Check());
                GameManager.Instance.MumIsGone();
                break;
            case MumState.Standby:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = standbyState;
                break;
            case MumState.Watch:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = watchState;
                break;
        }
        AIstate.OnStart(this);
    }

    public void ComingToWatchYou()
    {
        StopCoroutine(checkCoroutine);
        patrolState.MoveToDoor();
        GameManager.Instance.MumIsComing();
    }
    
    // Coming, watch you
    IEnumerator Check()
    {
        yield return new WaitForSeconds(12);
        GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
        ChangeState(MumState.Standby);
    }
    
    public void ConsoleMakeNoise()
    {
        if (!canHear || AIstate == watchState) return;
        if (AIstate == standbyState)
        {
            ChangeState(MumState.Watch);
            return;
        }
        if (!patrolState.MovingIntoDoor()) ChangeState(MumState.Standby);
    }

    public void LightIsLit()
    {
        if (!canSee || AIstate == watchState) return;
        if (AIstate == standbyState)
        {
            ChangeState(MumState.Patrol);
            ComingToWatchYou();
            return;
        }
        if (AIstate == patrolState && !patrolState.MovingIntoDoor())
        ComingToWatchYou();
    }
}