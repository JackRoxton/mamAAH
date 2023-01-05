using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_PatrolState : FSM_BaseState
{
    public GameObject hideLeft;
    public GameObject hideRight;
    public GameObject door;

    private GameObject moveTo;
    private Coroutine checkCoroutine;
    private float timer;


    public override void OnStart(Mum_script mum)
    {
        mum.GetComponent<SpriteRenderer>().color = Color.green;
        mum.canHear = true;
        mum.canSee = true;
        ChangeDestination();
    }

    public override void Update(Mum_script mum)
    {
        // Wait between each round trips
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                mum.canHear = true;
                mum.canSee = true;
                if (GameManager.Instance.GetConsoleState()) mum.ChangeState(MumState.Standby);
            }
            return;
        } // return

        // Move into the destination
        Vector2 move = moveTo.transform.position - mum.transform.position;
        Vector2 normalizedMove = move.normalized * mum.speed * Time.deltaTime;
        mum.transform.position = new Vector3(
            mum.transform.position.x + normalizedMove.x,
            mum.transform.position.y + normalizedMove.y, 1);
        
        // When behind the door
        if (move.magnitude < .1f)
            if (moveTo == door)
                mum.ChangeState(MumState.Watch);
            else
            {
                timer = 2.0f;
                mum.canHear = false;
                mum.canSee = false;
                ChangeDestination();
            }
    }

    private void ChangeDestination()
    {
        moveTo = moveTo == hideLeft ? hideRight : hideLeft;
    }
    public void MoveToDoor()
    {
        moveTo = door;
    }
}
