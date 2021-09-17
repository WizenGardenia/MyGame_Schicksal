using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnim;
    private BoxCollider2D playerFeet;
    private bool isGround;
    private int maxJumpNum;
    private int jumpNum;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
        maxJumpNum = 2;
        


    }

    // Update is called once per frame
    void Update()
    {

        Run();
        Jump();
        SwitchAnimation();
        Flip();
        //attack();
        CheckGround();
        
    }

    

    void Run()//ʵ���ܲ�
    {
        float moveDir = Input.GetAxis("Horizontal");//��ȡ�ƶ�����Ϊ��2D�����Ϸ���Ի�ȡˮƽ�ᣬ����ֵ��-1��1֮��
        Vector2 playerVel = new Vector2(moveDir * runSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;//Matchf.Epsilon��һ����С��ֵ�����ٶȴ������ֵʱ��������
        playerAnim.SetBool("Run", playerHasXAxisSpeed);//���ٶȸ�Run������ֵ1�����ٶȸ�ֵ0   
        
    }
    void Jump()//ʵ����Ծ
    {
        if (Input.GetButtonDown("Jump"))//����ļ�λӳ����Edit-ProjectSettings-InputManager�˵��п��Բ鿴�͵�������Edit-ProjectSettings-Physics�п��Ե�����������
        {
            if (isGround)
            {

                playerAnim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                playerRigidbody.velocity = Vector2.up * jumpVel;
                jumpNum = jumpNum - 1;
                
            }            
            else if (jumpNum>0)//������
            {
                if (jumpNum == maxJumpNum)
                    jumpNum--;
                playerAnim.SetBool("Jump", true);
                playerAnim.SetBool("Fall", false);
                Vector2 jumpVel = new Vector2(0.0f, doubleJumpSpeed);
                playerRigidbody.velocity = Vector2.up * jumpVel;
                jumpNum = jumpNum - 1;
            }
            
        }
    }
    //�ò��ִ�������PlayerAttack.cs��ʵ��
    //void attack()
    //{
    //    if(input.getbuttondown("attack"))
    //    {
    //        playeranim.settrigger("attack");//����attack�Ǹ������ͱ�����ֱ�Ӵ�������

    //    }
    //}

    void Flip()//�����ƶ�����ת���飨���Խ�Լ������Դ��
    {
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;//ͬ���ж����ٶȵ�ʱ��Żᷭת����
        if(playerHasXAxisSpeed)
        {
            if (playerRigidbody.velocity.x > 0.1f)//������0��Ϊ�ж������Ƿ�ֹ���ٶȺ�С��ʱ�򶯻��������ҷ�ת
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);//����Ϊ0��ʾ����Ҫ��ת
            }
            if (playerRigidbody.velocity.x < -0.1f)//������0��Ϊ�ж������Ƿ�ֹ���ٶȺ�С��ʱ�򶯻��������ҷ�ת
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);//��ʾ��Ҫ��ת��ʱ�������ҷ�ת���޸ĵ�һ������Ϊ180�����������·�ת��
            }
        }
    }

    void CheckGround()//����Ƿ��ǵ���
    {
        isGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));//�����ҵ�BoxCollider2D�Ƿ��Ground����ײ(Ground���Ѿ�����)
        if (isGround)
        {
            jumpNum = maxJumpNum;
        }
        
    }

    void SwitchAnimation()
    {
        playerAnim.SetBool("Idle", false);
        if (playerAnim.GetBool("Jump"))
        {
            if (playerRigidbody.velocity.y < 0.0f)
            {
                playerAnim.SetBool("Jump", false);
                playerAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            playerAnim.SetBool("Fall", false);
            playerAnim.SetBool("Idle", true);
        }
    }

    
    
}
