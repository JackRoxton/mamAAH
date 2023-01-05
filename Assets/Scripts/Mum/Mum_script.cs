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
    public int speed = 100;

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
                break;
            case MumState.Standby:
                break;
            case MumState.Check:
                break;
        }
        state.OnStart(this);
    }
}