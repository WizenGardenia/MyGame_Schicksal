using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDash : Action
{
    private bool isGround;
    private PolygonCollider2D plg2D;
    public override void OnStart()
    {
        plg2D = GetComponent<PolygonCollider2D>();
        int random = Random.Range(90, 110);
        GetComponent<EsengutSkill>().moveToTarget(new Vector2(random, -9));
        GetComponent<EsengutSkill>().Dash();
    }
    public override TaskStatus OnUpdate()
    {

        
        CheckGround();
        if (isGround) 
        {
            GetComponent<EsengutSkill>().EndDash();
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    void CheckGround()//检测是否是地面
    {
        if (plg2D != null)
        {
            isGround = plg2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        }        
        

    }
}
