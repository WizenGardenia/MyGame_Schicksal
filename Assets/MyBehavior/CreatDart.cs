using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatDart : Action
{
    
    public override void OnStart()
    {
        
    }
    public override TaskStatus OnUpdate()
    {
        
        GetComponent<EsengutSkill>().moveToTarget(new Vector2(100,-10));
        GetComponent<EsengutSkill>().AttackDart();
        return TaskStatus.Success;
    }


}
