using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_PatrolState : MumFSM_BastState
{
    public GameObject hideLeft;
    public GameObject hideRight;
    public GameObject door;

    private GameObject moveTo;
    private Coroutine checkCoroutine;


    public override void OnStart(Mum_script mum)
    {
        mum.GetComponent<SpriteRenderer>().color = Color.green;
        ChangeDestination();
    }

    public override void Update(Mum_script mum)
    {
        Vector2 move = moveTo.transform.position - mum.transform.position;
        Vector2 normalizedMove = move.normalized * mum.speed * Time.deltaTime;
        mum.transform.position = new Vector3(
            mum.transform.position.x + normalizedMove.x,
            mum.transform.position.y + normalizedMove.y, 0);
        if (move.magnitude < .1f)
            if (moveTo == door)
                mum.ChangeState(MumState.Check);
            else
                ChangeDestination();
    }

    private void ChangeDestination()
    {
        moveTo = moveTo == hideLeft ? hideRight : hideLeft;
    }
    public void CheckDoor()
    {
        moveTo = door;
    }
}
