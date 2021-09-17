using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsengutDart : EnemySkill
{
    public float magnitude;// 力的大小
    public GameObject Explor;
    public float DestoryTime;
    private Rigidbody2D dartRid;   
    private float StartTime;
    private Vector3 startPos;
    private Transform playerTransform;
    

    new void Start()
    {
        base.Start();
        StartTime = Time.time;
        dartRid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    new void Update()
    {
        
        base.Update();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (playerTransform != null)
        {
            
            if (dartRid != null)
            {
                Vector2 direction = playerTransform.position - transform.position;                
                direction.Normalize();               
                dartRid.AddForce(direction * magnitude);
            }
        }

        if(StartTime + DestoryTime < Time.time)
        {
            anim.SetTrigger("explod");
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
                dartRid.velocity = new Vector2(0, 0);
                anim.SetTrigger("explod");

            }
        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            
            dartRid.velocity = new Vector2(0, 0);
            Vector2 explorSet = new Vector2(transform.position.x, transform.position.y + 2);
            Instantiate(Explor, explorSet, transform.rotation);
            anim.SetTrigger("explod");
            
        }

        
    }

    

    

}
