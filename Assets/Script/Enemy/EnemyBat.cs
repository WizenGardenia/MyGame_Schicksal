using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{



    //�����漰�ƶ���AI�Ĵ���������Ż�Ϊ��Ϊ��
    public float speed;
    public float startWaitTime;
    private float waitTime;//�ȴ�ʱ��
    public Transform movePos;//��һ��Ҫ�ƶ�����λ��
    //��������������ֱ�������º����ϣ����ڶ���һ�����Χ�ľ���
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        //��ʼ���ȴ�ʱ�������λ�ò���
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        canGetForce = true;
        flashcolor = Color.red;
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        //������ƶ�����
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f) 
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //��ȡ���λ��
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
