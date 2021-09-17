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

    

    void Run()//实现跑步
    {
        float moveDir = Input.GetAxis("Horizontal");//获取移动，因为是2D横版游戏所以获取水平轴，返回值在-1到1之间
        Vector2 playerVel = new Vector2(moveDir * runSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;//Matchf.Epsilon是一个很小的值，当速度大于这个值时触发动画
        playerAnim.SetBool("Run", playerHasXAxisSpeed);//有速度给Run变量赋值1，无速度赋值0   
        
    }
    void Jump()//实现跳跃
    {
        if (Input.GetButtonDown("Jump"))//具体的键位映射在Edit-ProjectSettings-InputManager菜单中可以查看和调整，在Edit-ProjectSettings-Physics中可以调节重力参数
        {
            if (isGround)
            {

                playerAnim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                playerRigidbody.velocity = Vector2.up * jumpVel;
                jumpNum = jumpNum - 1;
                
            }            
            else if (jumpNum>0)//二段跳
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
    //该部分代码移至PlayerAttack.cs中实现
    //void attack()
    //{
    //    if(input.getbuttondown("attack"))
    //    {
    //        playeranim.settrigger("attack");//这里attack是个触发型变量，直接触发即可

    //    }
    //}

    void Flip()//根据移动方向翻转精灵（可以节约美术资源）
    {
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;//同样判断有速度的时候才会翻转精灵
        if(playerHasXAxisSpeed)
        {
            if (playerRigidbody.velocity.x > 0.1f)//不采用0作为判断依据是防止当速度很小的时候动画连续左右翻转
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);//参数为0表示不需要翻转
            }
            if (playerRigidbody.velocity.x < -0.1f)//不采用0作为判断依据是防止当速度很小的时候动画连续左右翻转
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);//表示需要翻转的时候精灵左右翻转（修改第一个参量为180可以做到上下翻转）
            }
        }
    }

    void CheckGround()//检测是否是地面
    {
        isGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));//检测玩家的BoxCollider2D是否和Ground层碰撞(Ground层已经定义)
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
