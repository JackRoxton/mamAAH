using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MumState
{
    Patrol, 
    Standby,
    Check
}

public abstract class MumFSM_BastState
{
    public abstract void Update(Mum_script mum);
    public abstract void OnStart(Mum_script mum);
}
