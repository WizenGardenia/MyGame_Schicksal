using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbspeed = 2f;
    private bool inLadder;
    public Collider2D platf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                //���ݶ�������
                inLadder = true;
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[0], platf);
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[1], platf);
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbspeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //���ݶ�������
                inLadder = true;
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[0], platf);
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[1], platf);
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climbspeed);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                //����
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[1], platf, false);
                Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[0], platf, false);
                collision.GetComponent<Rigidbody2D>().gravityScale = 1;
                inLadder = false;
            }
            else if (inLadder)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                //������
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        //�ظ�վ������
        inLadder = false;
        Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[1], platf, false);
        Physics2D.IgnoreCollision(collision.GetComponents<Collider2D>()[0], platf, false);
    }
}
