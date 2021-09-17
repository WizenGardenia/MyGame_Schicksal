using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int blinks;//闪烁次数
    public float time;//闪烁时间
    
    
    public float invisibleTime;//无敌时间

    private Renderer myRender;
    private Animator playerAnim;
    private CapsuleCollider2D cap;

    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        playerAnim = GetComponent<Animator>();
        cap = GetComponent<CapsuleCollider2D>();
        Debug.Log(health);
        maxHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health > 0)
        {           
            cap.enabled = false;//关闭胶囊碰撞器
            BlinkPlayer(blinks, time);           
            Invoke("invisible", invisibleTime);//无敌时间过后再执行invisible函数， 打开胶囊碰撞器
        }
        else
        {
            cap.enabled = false;//关闭胶囊碰撞器，重生时需要再次开启
            playerAnim.SetTrigger("Die");
            GameObject.Find("Player(Clone)").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("PlayerAttack(Clone)").GetComponent<PlayerAttack>().enabled = false;
            GameObject.Find("PlayerAttack").GetComponent<PlayerAttack>().enabled = false;


        }
        
        
    }

    public void RegenPlayer(int Regen)
    {
        
        if (health + Regen <= maxHealth)
        {
            health += Regen;
        }
        else
        {
            health = maxHealth;
        }
        
    }



    //这部分代码采用协程的方式实现角色受伤时闪烁，存在优化空间
    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }

    //用来重新打开胶囊碰撞器(实现受击无敌)
    void invisible()
    {
        cap.enabled = true;
    }
        

    
    
}
