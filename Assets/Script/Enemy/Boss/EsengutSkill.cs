using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsengutSkill : MonoBehaviour
{
    private Vector2 BossPosition;
    
    private PolygonCollider2D DashEnd;
    private Animator anim;
    private Rigidbody2D rgb2D;

    public GameObject Arrow;
    public GameObject Explor;
    public GameObject Dart;
    public int DashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        DashEnd = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        rgb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }


    public void moveToTarget(Vector2 target)
    {
        transform.position = target;
    }

    public void AttackDart()
    {
        anim.SetTrigger("Attack"); 
        Invoke("CreatDart", 0.3f);
    }
    public void CreatDart()
    {   
        
        BossPosition = transform.position;        
        Vector2 Dart1Pos = BossPosition + new Vector2(2f, 0);
        Vector2 Dart2Pos = BossPosition + new Vector2(-2f, 0);
        Vector2 Dart3Pos = BossPosition + new Vector2(0, 3);
        Instantiate(Dart, Dart1Pos, transform.rotation);
        Instantiate(Dart, Dart2Pos, transform.rotation);
        Instantiate(Dart, Dart3Pos, transform.rotation);
    }

    public void AttackArrow()
    {
        anim.SetTrigger("Attack");
        Invoke("ShadowArrow", 0.3f);
    }

    public void ShadowArrow()
    {
        BossPosition = transform.position;
        
        Vector2 Arrow1Pos = BossPosition + new Vector2(2f, 0);
        Vector2 Arrow2Pos = BossPosition + new Vector2(-2f, 0);
        Vector2 Arrow3Pos = BossPosition + new Vector2(-1.4f, -1.4f);
        Vector2 Arrow4Pos = BossPosition + new Vector2(1.4f, -1.4f);
        
        Instantiate(Arrow, Arrow1Pos, transform.rotation);
        Instantiate(Arrow, Arrow2Pos, transform.rotation);
        Instantiate(Arrow, Arrow3Pos, transform.rotation);
        Instantiate(Arrow, Arrow4Pos, transform.rotation);
        
    }

    public void Explode(Vector2 target)
    {
        Instantiate(Explor, target, transform.rotation);
    }

    public void MoveAndExplor(Vector2 target)
    {
        anim.SetTrigger("Burst");
        anim.SetBool("Idle", false);
        Explode(target);
    }

    public void Dash()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("PreDash",true);
    }

    public void SprintToPlayers()
    {
        anim.SetBool("PreDash", false);
        anim.SetBool("Dash", true);
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 movement = playerTransform.position - transform.position;
        movement.Normalize();

        rgb2D.velocity = movement * DashSpeed;
        
    }

    public void EndDash()
    {
        rgb2D.velocity = new Vector2(0, 0);
        anim.SetBool("Dash", false);
        anim.SetTrigger("EndDash");
        Instantiate(Explor, new Vector2(transform.position.x, transform.position.y + 1.5f), transform.rotation);
    }


    void Flip()//根据移动方向翻转精灵（可以节约美术资源）
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rgb2D.velocity.x) > Mathf.Epsilon;//同样判断有速度的时候才会翻转精灵
        if (playerHasXAxisSpeed)
        {
            if (rgb2D.velocity.x < 0.1f)//不采用0作为判断依据是防止当速度很小的时候动画连续左右翻转
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);//参数为0表示不需要翻转
            }
            if (rgb2D.velocity.x > -0.1f)//不采用0作为判断依据是防止当速度很小的时候动画连续左右翻转
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);//表示需要翻转的时候精灵左右翻转（修改第一个参量为180可以做到上下翻转）
            }
        }
    }
}
