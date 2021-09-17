using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class IsBattleBegin : Conditional
{
    private bool BattleBegin;    
    public override TaskStatus OnUpdate()
    {
        BattleBegin = GetComponent<EnemyEsengut>().IsBattle();
        if (BattleBegin)
        {            
            
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
