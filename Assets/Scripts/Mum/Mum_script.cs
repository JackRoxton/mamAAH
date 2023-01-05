using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mum_script : MonoBehaviour
{
    [SerializeField] private GameObject hideLeft;
    [SerializeField] private GameObject hideRight;
    [SerializeField] private GameObject door;

    public Sprite doorOpen;
    public Sprite doorClosed;
    
    public Sprite mumGood;
    public Sprite mumMad;

    [SerializeField] private AnimationCurve scaleCurve;

    // AI
    private FSM_BaseState AIstate;
    private MumFSM_PatrolState patrolState = new MumFSM_PatrolState();
    private MumFSM_WatchState watchState = new MumFSM_WatchState();
    private MumFSM_StandbyState standbyState = new MumFSM_StandbyState();
    public int speed = 2;

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
        float distanceBtwHides = Vector3.Distance(hideLeft.transform.position, hideRight.transform.position);
        float distanceToRight = Vector3.Distance(transform.position, hideRight.transform.position);
        transform.localScale = Vector3.one * scaleCurve.Evaluate(distanceToRight / distanceBtwHides);
    }

    public void ChangeState(MumState newState)
    {
        if (newState != MumState.Watch)
        {
            GameManager.Instance.MumIsGone();
            door.GetComponent<SpriteRenderer>().sprite = doorClosed;
            GetComponent<SpriteRenderer>().sprite = mumGood;
        }
        switch (newState)    
        {
            case MumState.Patrol:
                AIstate = patrolState;
                checkCoroutine = StartCoroutine(Check());
                GameManager.Instance.MumIsGone();
                speed = 2;
                break;
            case MumState.Standby:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = standbyState;
                break;
            case MumState.Watch:
                if (checkCoroutine != null) StopCoroutine(checkCoroutine);
                AIstate = watchState;
                door.GetComponent<SpriteRenderer>().sprite = doorOpen;
                GetComponent<SpriteRenderer>().sprite = mumMad;
                break;
        }
        AIstate.OnStart(this);
    }

    public void ComingToWatchYou()
    {
        StopCoroutine(checkCoroutine);
        patrolState.MoveToDoor();
        GameManager.Instance.MumIsComing();
        speed = 3;
    }
    
    // Coming, watch you
    IEnumerator Check()
    {
        yield return new WaitForSeconds(12);
        ChangeState(MumState.Standby);
    }
    
    public void ConsoleMakeNoise()
    {
        if (!canHear) return;
        if (AIstate == watchState)  return;
        if (AIstate == standbyState) return;
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