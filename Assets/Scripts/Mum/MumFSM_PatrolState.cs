using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumFSM_PatrolState : MumFSM_BastState
{
    public GameObject hideLeft;
    public GameObject hideRight;
    public GameObject door;

    private GameObject moveTo;


    public override void OnStart(Mum_script mum)
    {
        ChangeDestination();
    }

    public override void Update(Mum_script mum)
    {
        Debug.Log("patrolling");
        Vector2 move = moveTo.transform.position - mum.transform.position;
        Vector2 normalizedMove = move.normalized * mum.speed * Time.deltaTime;
        mum.transform.position = new Vector3(
            mum.transform.position.x + normalizedMove.x,
            mum.transform.position.y + normalizedMove.y, 0);
        if (move.magnitude < .1f) ChangeDestination();
    }

    private void ChangeDestination()
    {
        moveTo = moveTo == hideLeft ? hideRight : hideLeft;
    }
}
