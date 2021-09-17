using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour   //�����˺�ʵ�֣�����Ϊ��������������Enemy�ཨ������
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

    void OnTriggerEnter2D(Collider2D other) //������Ѫ
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
