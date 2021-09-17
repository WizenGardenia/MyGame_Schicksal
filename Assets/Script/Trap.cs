using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour   //陷阱伤害实现，可视为不受伤无生命的Enemy类建议整合
{
    public int damage;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) //触碰扣血
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
