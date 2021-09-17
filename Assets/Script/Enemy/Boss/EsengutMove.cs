using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class EsengutMove : Action
{
    public Vector2 movement;

    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {

        GetComponent<EsengutSkill>().moveToTarget(movement);

        return TaskStatus.Success;
    }
}


