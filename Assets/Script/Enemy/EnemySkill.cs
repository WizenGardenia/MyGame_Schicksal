using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySkill : MonoBehaviour
{
    public int damage;
    public int speed;
    protected Animator anim;
    protected PlayerHealth playerHealth;
    protected void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {

    }

    protected void DestroySkill()
    {
        Destroy(gameObject);
    }
}
