using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
namespace BehaviorDesigner.Runtime.Tasks
{
    public class CanSeePlayer : Conditional
    {
        public SharedTransform[] Targets;
        public SharedFloat fieldOfViewAngle = 90;
        public SharedFloat viewDistance = 3;
        
        
        

        
        
        public override TaskStatus OnUpdate()
        {
            if (Targets == null)
                return TaskStatus.Failure;
            foreach(var target in Targets)
            {
                float distance = (target.Value.position - transform.position).magnitude;
                float angle = Vector2.Angle(transform.forward, target.Value.position - transform.position);
                if (distance < viewDistance.Value && angle < fieldOfViewAngle.Value * 0.5f)
                {
                    return TaskStatus.Success;
                    
                }
            }
            return TaskStatus.Failure;
        }

        
    }


}


