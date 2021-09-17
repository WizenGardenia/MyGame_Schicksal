using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class IsBattleEnd : Conditional
{
    private bool BattleEnd;
    public override TaskStatus OnUpdate()
    {
        BattleEnd = GetComponent<EnemyEsengut>().IsBattleEnd();
        if (BattleEnd)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
