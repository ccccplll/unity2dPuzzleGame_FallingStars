using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    //public float player_status = 0;//玩家世界状态，0为现实世界，1为里世界
    //public float black_hole_num = 1;//剩余黑洞子弹数量
    //public float white_hole_num = 1;//剩余白洞子弹数量
    //public float change_wait_time = 3;//切换世界状态冷却时间
                                              //
    [Header("移动参数")]
    //设定角色的移动速度
    public float speed = 3f;

    [Header("跳跃参数")]
    //声明一个跳跃的力
    public float jumpForce = 6.3f;
    //当长按按键时加成的跳跃的力
    public float jumpHoldFroce = 1.9f;
    //长按跳跃按键可以按多长时间
    public float jumpHoldDuration = 0.1f;

    //记录跳跃的时间
    float jumpTime;

    [Header("状态")]
    //游戏角色是否站在地上的状态
    public bool isOnGround;
    //游戏角色是否处于跳跃的状态
    public bool isJump;

    [Header("环境检测")]
    //用来判断哪一个是地面的图层
    public LayerMask groundLayer;

    //按键的设置
    bool jumpPressed;//单次跳跃
    bool jumpHeld;//长按跳跃

    //

    public bool live = true;//判断是否死亡以便播放死亡动画

    /*天赋树功能参数
     *     public float rage = 1f;//等级
     *     public float capility_point = 10;//总技能点
     *     */

    /*private Rigidbody2D rb;
    //获得角色碰撞器，游戏需要所以特别使用方形的collider
    private BoxCollider2D coll;
    private Animator myAni;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
    }

    void GroundMovement()//水平移动函数
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * speed, rb.velocity.y);
        rb.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (moveDir > 0)
        {
            myAni.SetBool("run_left", false);
            myAni.SetBool("run_right", true);
        }
        else if (moveDir < 0)
        {
            myAni.SetBool("run_right", false);
            myAni.SetBool("run_left", true);
        }
        else
        {
            myAni.SetBool("run_right", false);
            myAni.SetBool("run_left", false);
        }
    }


    private void FixedUpdate()
    {
        //先调用物理环境判断游戏角色是否在地面上
        PhysicsCheck();
        //在游戏角色跳跃之前调用游戏角色移动的函数，此脚本函数在游戏角色移动的脚本查看
        GroundMovement();
        //调用游戏角色跳跃的函数
        MidAirMovement();
    }

    //物理环境判断的函数
    void PhysicsCheck()
    {
        //判断游戏角色是否处于isOnGround状态
        if (coll.IsTouchingLayers(groundLayer))
            isOnGround = true;
        else isOnGround = false;
    }

    //跳跃有关的函数
    void MidAirMovement()
    {
        //1.判断角色在地面的同时按下了jump，并且角色不处于跳跃状态
        if (jumpPressed && isOnGround && !isJump)
        {
            //2.跳跃的状态变成true，是否处于地面上变成false
            isOnGround = false;
            isJump = true;
            //计算跳跃的时间
            jumpTime = Time.time + jumpHoldDuration;
            //2.添加跳跃的力使角色跳跃起来
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        //3.判断如果现在是跳跃的状态
        else if (isJump)
        {
            //4.持续按住跳跃
            if (jumpHeld)
                //5.添加持续跳跃的力
                rb.AddForce(new Vector2(0f, jumpHoldFroce), ForceMode2D.Impulse);
            //判断如果跳跃时间小于真实的时间
            if (jumpTime < Time.time)
                isJump = false;
        }
    }*/
     private Rigidbody2D rb;
    public float moveSpeed = 3f; // 移动速度
    public float jumpForce = 7.7f; // 跳跃力
    // 地面检测
    public Transform groundCheck;
    private bool isjump = false;
    private Animator myAni;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float lasty;
    public GameObject maincode;

    bool isfall=false;
    void Start()
    {
        myAni = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lasty = transform.position.y;
    }

    void Update()
    {
        float nowy = transform.position.y;
        float jugey = nowy - lasty;
        // 地面检测
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded)
        {
            myAni.SetBool("isfall", false);
            if (isfall)
            {
                playersoundmanager.instance.fallAudio();
            }

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                myAni.SetBool("isjump", true);
                playersoundmanager.instance.JumpAudio();
            }
            else
            {

                myAni.SetBool("isjump", false);

            }

        }
        else
        {
            if (!isjump)
            {
                myAni.SetBool("isfall", true);
            }
            else
            {
                if(jugey < 0)
                {
                    myAni.SetBool("isfall", true);
                    isfall = true;
                    myAni.SetBool("isjump", false);
                }
            }
        }

        float dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (dirX == 0)
        {
            myAni.SetBool("iswalk", false);
        }
        else if(dirX >0)
        {
            myAni.SetBool("iswalk", true);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            myAni.SetBool("iswalk", true);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
       /* if (dirX > 0)
        {
            myAni.SetBool("run_left", false);
            myAni.SetBool("run_right", true);
        }
        else if (dirX < 0)
        {
            myAni.SetBool("run_right", false);
            myAni.SetBool("run_left", true);
        }
        else
        {
            myAni.SetBool("run_right", false);
            myAni.SetBool("run_left", false);
        }*/
    }

    public void dead()
    {
        MainLogic M = maincode.GetComponent<MainLogic>();
        playersoundmanager.instance.deadAudio();
        M.restart();
    }

}
