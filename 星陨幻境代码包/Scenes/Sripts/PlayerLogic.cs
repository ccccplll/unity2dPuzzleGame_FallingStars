using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    //public float player_status = 0;//�������״̬��0Ϊ��ʵ���磬1Ϊ������
    //public float black_hole_num = 1;//ʣ��ڶ��ӵ�����
    //public float white_hole_num = 1;//ʣ��׶��ӵ�����
    //public float change_wait_time = 3;//�л�����״̬��ȴʱ��
                                              //
    [Header("�ƶ�����")]
    //�趨��ɫ���ƶ��ٶ�
    public float speed = 3f;

    [Header("��Ծ����")]
    //����һ����Ծ����
    public float jumpForce = 6.3f;
    //����������ʱ�ӳɵ���Ծ����
    public float jumpHoldFroce = 1.9f;
    //������Ծ�������԰��೤ʱ��
    public float jumpHoldDuration = 0.1f;

    //��¼��Ծ��ʱ��
    float jumpTime;

    [Header("״̬")]
    //��Ϸ��ɫ�Ƿ�վ�ڵ��ϵ�״̬
    public bool isOnGround;
    //��Ϸ��ɫ�Ƿ�����Ծ��״̬
    public bool isJump;

    [Header("�������")]
    //�����ж���һ���ǵ����ͼ��
    public LayerMask groundLayer;

    //����������
    bool jumpPressed;//������Ծ
    bool jumpHeld;//������Ծ

    //

    public bool live = true;//�ж��Ƿ������Ա㲥����������

    /*�츳�����ܲ���
     *     public float rage = 1f;//�ȼ�
     *     public float capility_point = 10;//�ܼ��ܵ�
     *     */

    /*private Rigidbody2D rb;
    //��ý�ɫ��ײ������Ϸ��Ҫ�����ر�ʹ�÷��ε�collider
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

    void GroundMovement()//ˮƽ�ƶ�����
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
        //�ȵ����������ж���Ϸ��ɫ�Ƿ��ڵ�����
        PhysicsCheck();
        //����Ϸ��ɫ��Ծ֮ǰ������Ϸ��ɫ�ƶ��ĺ������˽ű���������Ϸ��ɫ�ƶ��Ľű��鿴
        GroundMovement();
        //������Ϸ��ɫ��Ծ�ĺ���
        MidAirMovement();
    }

    //�������жϵĺ���
    void PhysicsCheck()
    {
        //�ж���Ϸ��ɫ�Ƿ���isOnGround״̬
        if (coll.IsTouchingLayers(groundLayer))
            isOnGround = true;
        else isOnGround = false;
    }

    //��Ծ�йصĺ���
    void MidAirMovement()
    {
        //1.�жϽ�ɫ�ڵ����ͬʱ������jump�����ҽ�ɫ��������Ծ״̬
        if (jumpPressed && isOnGround && !isJump)
        {
            //2.��Ծ��״̬���true���Ƿ��ڵ����ϱ��false
            isOnGround = false;
            isJump = true;
            //������Ծ��ʱ��
            jumpTime = Time.time + jumpHoldDuration;
            //2.�����Ծ����ʹ��ɫ��Ծ����
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        //3.�ж������������Ծ��״̬
        else if (isJump)
        {
            //4.������ס��Ծ
            if (jumpHeld)
                //5.��ӳ�����Ծ����
                rb.AddForce(new Vector2(0f, jumpHoldFroce), ForceMode2D.Impulse);
            //�ж������Ծʱ��С����ʵ��ʱ��
            if (jumpTime < Time.time)
                isJump = false;
        }
    }*/
     private Rigidbody2D rb;
    public float moveSpeed = 3f; // �ƶ��ٶ�
    public float jumpForce = 7.7f; // ��Ծ��
    // ������
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
        // ������
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
