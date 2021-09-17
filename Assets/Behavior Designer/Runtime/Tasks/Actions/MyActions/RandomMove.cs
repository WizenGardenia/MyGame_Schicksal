using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BehaviorDesigner.Runtime.Tasks
{
    public class RandomMove : Action
    {
        public SharedFloat minSpeed=0;
        public SharedFloat maxSpeed=1;
        public SharedFloat moveTime = 1;
        public SharedBool randomMoveTime = false;
        public SharedFloat randomMoveMinTime = 1;
        public SharedFloat randomMoveMaxTime = 1;
        private float Speed;
        private Rigidbody2D rib2d;
        private float moveDuration;        
        private float startTime;        
        private float pauseTime;

        public override void OnStart()
        {
            Speed = Random.Range(minSpeed.Value, maxSpeed.Value);
            rib2d = GetComponent<Rigidbody2D>();
            startTime = Time.time;
            if (randomMoveTime.Value)
            {
                moveDuration = Random.Range(randomMoveMinTime.Value, randomMoveMaxTime.Value);
            }
            else
            {
                moveDuration = moveTime.Value;
            }
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector2 movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            rib2d.velocity = movement * Speed;
        }

        public override TaskStatus OnUpdate()
        {
            
            if (startTime + moveDuration < Time.time)
            {
                rib2d.velocity = new Vector2(0, 0);
                return TaskStatus.Success;
            }
            // Otherwise we are still waiting.
            
            return TaskStatus.Running;
            
        }
                      
        

        
    }
}


