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
    private MumFSM_CheckState checkState = new MumFSM_CheckState();
    public int speed = 100;

    private Coroutine checkCoroutine;

    private void Start()
    {
        patrolState.hideLeft = hideLeft;
        patrolState.hideRight = hideRight;
        patrolState.door = door;
        ChangeState(MumState.Patrol);
    }

    private void Update()
    {
        AIstate.Update(this);
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
                break;
            case MumState.Check:
                AIstate = checkState;
                break;
        }
        AIstate.OnStart(this);
    }

    // Coming, watch you
    IEnumerator Check()
    {
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
        patrolState.CheckDoor();
    }
}