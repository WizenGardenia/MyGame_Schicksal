using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{
    public float Speed;
    public float radius;

    //private Transform playerTransform;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        //playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canGetForce = true;
        flashcolor = Color.red;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        //���Ż�Ϊ��Ϊ��
        //if (playerTransform != null)
        //{
        //    float distance = (transform.position - playerTransform.position).sqrMagnitude;//������������
        //    if (distance < radius)
        //    {
        //        transform.position = Vector2.MoveTowards(transform.position, 
        //                                                 playerTransform.position, 
        //                                                 Speed * Time.deltaTime);
        //    }
        //}
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
