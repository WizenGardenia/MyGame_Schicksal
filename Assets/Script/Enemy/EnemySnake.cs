using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : Enemy
{
    // Start is called before the first frame update
    public float waitTime;
    public float speed;
    public Transform[] movePos ;

    private int i = 0;
    private bool MovingRight = true;
    private float wait;
    new void Start()
    {
        base.Start();
        wait = waitTime;
        canGetForce = true;
        flashcolor = Color.red;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.position =
            Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                if (MovingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    MovingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    MovingRight = true;
                }
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }

                waitTime = wait;
            }
        }

    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
