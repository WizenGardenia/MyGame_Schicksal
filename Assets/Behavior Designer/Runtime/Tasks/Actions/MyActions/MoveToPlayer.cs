using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    //当无法追击角色时返回success，正在追击返回running
    public class MoveToPlayer : Action
    {
        public SharedTransform[] Targets;
        public SharedFloat speed;
        public SharedFloat viewDistance = 3;
        public SharedFloat maxTrackDistance = 6;



        private float minDistance;
        private Transform closestTarget;
        private Rigidbody2D rib2d;
        public override void OnStart()
        {
            minDistance = viewDistance.Value;
            rib2d = GetComponent<Rigidbody2D>();
            
        }
        public override TaskStatus OnUpdate()
        {
            if (Targets == null)
                return TaskStatus.Failure;
            foreach (var target in Targets)
            {
                float distance = (target.Value.position - transform.position).magnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target.Value;
                }               
            }
            if (closestTarget == null)
                return TaskStatus.Success;
            
            Vector2 movement = closestTarget.position - transform.position;
            
            if (movement.magnitude > 0.1f&& movement.magnitude < maxTrackDistance.Value)
            {
                movement.Normalize();
                rib2d.velocity = movement * speed.Value;
                
                return TaskStatus.Running;
            }
            else
            {
                rib2d.velocity = new Vector2(0, 0);
                return TaskStatus.Success;
            }
        }
    }

}
