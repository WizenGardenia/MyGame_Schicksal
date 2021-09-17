using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatArrow : Action
{
    public override void OnStart()
    {

    }
    public override TaskStatus OnUpdate()
    {
        int random = Random.Range(90, 110);
        GetComponent<EsengutSkill>().moveToTarget(new Vector2(random, -9));
        GetComponent<EsengutSkill>().AttackArrow();
        return TaskStatus.Success;
    }
}
