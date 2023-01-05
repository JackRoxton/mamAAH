using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MumState
{
    Patrol, 
    Standby,
    Watch
}

public enum MonsterState
{
    Wait, 
    Hide, 
    Climb
}

public abstract class FSM_BaseState
{
    public abstract void Update(Mum_script mum);
    public abstract void OnStart(Mum_script mum);
}
