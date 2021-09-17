using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int blinks;//��˸����
    public float time;//��˸ʱ��
    
    
    public float invisibleTime;//�޵�ʱ��

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
            cap.enabled = false;//�رս�����ײ��
            BlinkPlayer(blinks, time);           
            Invoke("invisible", invisibleTime);//�޵�ʱ�������ִ��invisible������ �򿪽�����ײ��
        }
        else
        {
            cap.enabled = false;//�رս�����ײ��������ʱ��Ҫ�ٴο���
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



    //�ⲿ�ִ������Э�̵ķ�ʽʵ�ֽ�ɫ����ʱ��˸�������Ż��ռ�
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

    //�������´򿪽�����ײ��(ʵ���ܻ��޵�)
    void invisible()
    {
        cap.enabled = true;
    }
        

    
    
}
