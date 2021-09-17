using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float flashTime;
    public GameObject bloodEffect;


    protected Color flashcolor;
    protected bool canGetForce;
    protected SpriteRenderer sr;
    private Color originColor;
    private PlayerHealth playerHealth;
    private Rigidbody2D enemyRib2D;

    public abstract void Die();

    //����������Ҫ�̳й�Start��Update��ΪPublic
    // Start is called before the first frame update
    public void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
        enemyRib2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }

    }

    
    
    //�����ж�
    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);//��ʾ������Ч
        CameraManager.camShake.Shake();//�������       
    }
    //�����ж�
    public void TakeForce(Vector2 Direction, float magnitude)
    {
        
        if (canGetForce == true)
        {
            if (enemyRib2D != null)
            {
                enemyRib2D.AddForce(Direction * magnitude);
            }           
        }
    }

    void FlashColor(float time)
    {
        sr.color = flashcolor;
        Invoke("ResterColor", time);

    }

    void ResterColor()
    {
        sr.color = originColor;
    }


    void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
            
        }
    }

    


}
