using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsengutArrow : EnemySkill
{
    // Start is called before the first frame update
    private Rigidbody2D arrowRb;
    private float Angle;


    new void Start()
    {
        base.Start();
        arrowRb = GetComponent<Rigidbody2D>();
        Angle = Random.Range(0, 180);
        gameObject.transform.Rotate(0, 0, Angle, Space.Self);
        Invoke("GetVelocity", 0.3f);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
                

            }
        }

        else if (other.gameObject.CompareTag("Ground"))
        {

            arrowRb.velocity = new Vector2(0, 0);
            anim.SetTrigger("disappear");
        }

    }

    void GetVelocity()
    {
        
        if (arrowRb != null)
        {
            Debug.Log(Angle);
            float newAngle = (Angle * (Mathf.PI)) / 180;
            arrowRb.velocity = new Vector2(-Mathf.Cos(newAngle) * speed, -Mathf.Sin(newAngle) * speed);
            Debug.Log(arrowRb.velocity);

        }
        
    }
}
