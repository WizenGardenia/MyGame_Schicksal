using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public int Force;
    //public float time;
    //public float startTime;
    private Animator anim;
    private new PolygonCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();//获取Tag为Player的GameObject的动画
        anim = GetComponentInParent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();//获取碰撞箱
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            
            anim.SetTrigger("Attack");//这里Attack是个触发型变量，直接触发即可
            //StartCoroutine(StartAttack());//这部分代码可以优化为动画帧事件

        }
    }


    //这部分代码可以优化为动画帧事件,代码中实际的优化方法是采用关键帧处理
    //IEnumerator StartAttack()
    //{
    //    yield return new WaitForSeconds(startTime);
    //    collider2D.enabled = true;//将碰撞框设置为可用
    //    StartCoroutine(disableHitBox());
    //}
    //IEnumerator disableHitBox()
    //{
    //    yield return new WaitForSeconds(time);
    //    collider2D.enabled = false;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //临时代码，后面给Enemy建了抽象父类
            //other.GetComponent<EnemyBat>().TakeDamage(damage);
            other.GetComponent<Enemy>().TakeDamage(damage);

            //击退
            Vector2 Direction = (other.transform.position - transform.position);
            Direction.Normalize();
            other.GetComponent<Enemy>().TakeForce(Direction, Force);
        }
    }



}
