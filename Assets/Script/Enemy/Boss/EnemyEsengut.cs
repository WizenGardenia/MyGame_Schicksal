using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEsengut : Enemy
{
    private bool BattleBegin;
    private bool BattleEnd;
    private Animator anim;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        canGetForce=false;
        flashcolor = Color.red;
        BattleBegin = false;
        BattleEnd = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void BossBattleEnd()
    {
        BattleEnd = true;
        
    }

    public void setBattleState(bool state)
    {
        BattleBegin = state;
        Debug.Log("Success");
        anim.SetBool("BattleBegin", true);
        anim.SetBool("Idle", true);
    }

    public bool IsBattle()
    {
        return BattleBegin;
        
    }

    public bool IsBattleEnd()
    {
        return BattleEnd;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
