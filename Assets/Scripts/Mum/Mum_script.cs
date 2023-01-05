using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mum_script : MonoBehaviour
{
    [SerializeField] private GameObject hideLeft;
    [SerializeField] private GameObject hideRight;
    [SerializeField] private GameObject door;
    private MumFSM_BastState state;
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
        state.Update(this);
    }

    public void ChangeState(MumState newState)
    {
        switch (newState)    
        {
            case MumState.Patrol:
                state = patrolState;
                checkCoroutine = StartCoroutine(Check());
                break;
            case MumState.Standby:
                break;
            case MumState.Check:
                state = checkState;
                break;
        }
        state.OnStart(this);
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(10);
        GetComponent<SpriteRenderer>().color = new Color(255, 134, 0);
        patrolState.CheckDoor();
    }
}