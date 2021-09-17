using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToExplor : Action
{
    private Transform playerTransform;
    public override void OnStart()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public override TaskStatus OnUpdate()
    {
        if (playerTransform.position.x < 100)
        {
            GetComponent<EsengutSkill>().moveToTarget(new Vector2(playerTransform.position.x + 5,
                                                                  -15));
        }
        else
        {
            GetComponent<EsengutSkill>().moveToTarget(new Vector2(playerTransform.position.x - 5,
                                                                  -15));
        }
        GetComponent<EsengutSkill>().MoveAndExplor(new Vector2(transform.position.x,transform.position.y+1.5f));
        return TaskStatus.Success;
    }

}
