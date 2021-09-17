using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BehaviorDesigner.Runtime.Tasks
{
    public class GetPlayer : Action
    {
        public SharedTransform playerTransform;
        

        
        
        public override void OnStart()
        {
           
        }
        

        
        public override TaskStatus OnUpdate()
        {
            playerTransform.Value = GameObject.FindGameObjectWithTag("Player").transform;
            if (playerTransform.Value == null)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
    }
}

