using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class BossIdle : Action
{
    private Animator anim;
    public override void OnStart()
    {
        anim = GetComponent<Animator>();
    }
    public override TaskStatus OnUpdate()
    {

        anim.SetBool("Idle", true);
        return TaskStatus.Success;
    }
}
