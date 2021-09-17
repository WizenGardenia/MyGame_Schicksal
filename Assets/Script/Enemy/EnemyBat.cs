using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{



    //部分涉及移动的AI的代码后续会优化为行为树
    public float speed;
    public float startWaitTime;
    private float waitTime;//等待时间
    public Transform movePos;//下一次要移动到的位置
    //下面这两个坐标分别代表左下和右上，用于定义一个活动范围的矩形
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        //初始化等待时间参量和位置参量
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        canGetForce = true;
        flashcolor = Color.red;
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        //具体的移动操作
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

    //获取随机位置
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
