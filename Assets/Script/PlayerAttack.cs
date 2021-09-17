using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public int Force;
    //public float time;
    //public float startTime;
    private Animator anim;
    private new PolygonCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();//��ȡTagΪPlayer��GameObject�Ķ���
        anim = GetComponentInParent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();//��ȡ��ײ��
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            
            anim.SetTrigger("Attack");//����Attack�Ǹ������ͱ�����ֱ�Ӵ�������
            //StartCoroutine(StartAttack());//�ⲿ�ִ�������Ż�Ϊ����֡�¼�

        }
    }


    //�ⲿ�ִ�������Ż�Ϊ����֡�¼�,������ʵ�ʵ��Ż������ǲ��ùؼ�֡����
    //IEnumerator StartAttack()
    //{
    //    yield return new WaitForSeconds(startTime);
    //    collider2D.enabled = true;//����ײ������Ϊ����
    //    StartCoroutine(disableHitBox());
    //}
    //IEnumerator disableHitBox()
    //{
    //    yield return new WaitForSeconds(time);
    //    collider2D.enabled = false;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //��ʱ���룬�����Enemy���˳�����
            //other.GetComponent<EnemyBat>().TakeDamage(damage);
            other.GetComponent<Enemy>().TakeDamage(damage);

            //����
            Vector2 Direction = (other.transform.position - transform.position);
            Direction.Normalize();
            other.GetComponent<Enemy>().TakeForce(Direction, Force);
        }
    }



}
