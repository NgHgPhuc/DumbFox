//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

//public class PlayerMoving : MonoBehaviour //moving, animation, collision
//{
//    //Physics variable
//    Rigidbody2D Body;
//    bool OnGround;

//    //Animation variables
//    Animator Anim;
//    bool Right; // turn right?
//    bool IsRun; // Is Run?
//    bool IsJump; // Is Jump
//    bool IsFire; // Is Fire?
//    bool IsFall; // Is Fall?
//    bool IsClimb; //Climbing
//    public TrailRenderer tr;

//    //Moving Variables
//    bool CanDash;

//    //Player Stats
//    PlayerStats playerStats;

//    void Start()
//    {
//        //Rigid and Animator Variable
//        Body = GetComponent<Rigidbody2D>();
//        Anim = GetComponent<Animator>();

//        //First Animation's status 
//        IsRun = false;
//        Right = true;
//        IsJump = false;
//        IsFall = false;
//        IsFire = false;

//        //First Collision
//        OnGround = true;

//        //First Moving variables
//        CanDash = true;

//        playerStats = gameObject.GetComponent<PlayerStats>();
//    }

//    private void Update()
//    {
//        PlayerAnimation(); //change animation

//        PlayerRun();

//        if (Input.GetKeyDown(KeyCode.Z))//Dash - z
//        {
//            if (CanDash)
//            {
//                CanDash = false;
//                if (Right)
//                    Body.AddForce(new Vector2(playerStats.Speed * 1.5f, 0), ForceMode2D.Impulse);
//                else
//                    Body.AddForce(new Vector2(-playerStats.Speed * 1.5f, 0), ForceMode2D.Impulse);
//                tr.emitting = true;
//            }

//        }

//        if (Input.GetKeyUp(KeyCode.Z))//UnDash - release z
//        {
//            Body.velocity = new Vector2(0, 0);
//            tr.emitting = false;
//            CanDash = true;
//        }
//    }

//    void FixedUpdate()
//    {

//        PlayerFall(); //Check fall

//        PlayerJump(); //Player Jump - GetKey X
//    }

//    void PlayerAnimation()
//    {
//        //Animation - Run
//        if (IsRun && !IsFire && !IsJump && !IsFall) //Run and Not Fire = running
//            Anim.Play("Player Running"); //Animation Player Running is stared

//        //Animation - Fire
//        if ((Time.time > NextTime - 0.7f) && !IsJump && !IsFall)
//            IsFire = false;
//        else if (Time.time > NextTime - 0.9f)
//            IsFire = false;
//        if (IsFire)
//            Anim.Play("Player Fire");

//        //Animation - Jump
//        if (IsJump && !IsFire && !IsClimb)
//        {
//            Anim.Play("Player Jumping");
//        }


//        //Animation - Fall
//        if (IsFall && !IsFire && !IsClimb)
//        {
//            Anim.Play("Player Falling");
//        }


//        if (!(IsRun || IsJump || IsFall || IsFire || IsClimb))
//        {
//            Anim.Play("Player Idle");
//        }

//        if (IsClimb)
//        {
//            Anim.Play("Player Climbing");
//            //IsFall = false;
//        }


//    }

//    void PlayerFall()
//    {
//        if (Body.velocity.y < -0.01)//is falling
//        {
//            IsFall = true;
//            IsJump = false;
//            OnGround = false;
//        }
//    }

//    void PlayerJump()
//    {
//        if(Input.GetKey(KeyCode.X))
//            if (OnGround)
//            {
//                Body.velocity = new Vector2(Body.velocity.x, playerStats.Jump);

//                IsJump = true;
//                IsFire = false;
//                OnGround = false;
//            }
//    }

//    void PlayerRun()
//    {
//        float Move = Input.GetAxis("Horizontal"); // Move increase a little from 0, 0.1,.. to 1 or -1
//        FLipBody(Move);

//        if (CanDash)
//        {
//            Body.velocity = new Vector2(Move * playerStats.Speed, Body.velocity.y);// + EtnVelocity;
//            if (Move == 0) IsRun = false;
//            else IsRun = true;
//        }
//    }

//    void FLipBody(float Move) // Flip body
//    {
//        if (Right && Move < 0)
//        {
//            Right = false;
//            Vector3 scale = transform.localScale;
//            scale.x *= -1;
//            transform.localScale = scale;
//        }

//        else if (!Right && Move > 0)
//        {
//            Right = true;
//            Vector3 scale = transform.localScale;
//            scale.x *= -1;
//            transform.localScale = scale;
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Layer6: Ground
//        {
//            IsJump = false;
//            IsFall = false;
//            OnGround = true;
//        }
//    }
//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Layer6: Ground
//        {
//            IsJump = false;
//            IsFall = false;
//            OnGround = true;
//        }
//        if (collision.CompareTag("Ladder"))
//        {

//            float Vertical = Input.GetAxis("Vertical");
//            Body.velocity = new Vector2(Body.velocity.x, 2 * Vertical);
//            if (Vertical != 0)
//            {
//                Body.gravityScale = 0f;
//                IsClimb = true;
//            }

//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Ladder"))
//        {
//            Body.gravityScale = 1f;
//            IsClimb = false;
//        }
//    }

//    public void PlayerMoveTo(Transform end)
//    {
//        while (transform.position != end.position)
//        {
//            GetComponent<BoxCollider2D>().isTrigger = true;
//            transform.position = Vector3.MoveTowards(transform.position, end.position, 10 * Time.deltaTime);
//        }
//        GetComponent<BoxCollider2D>().isTrigger = false;
//    }

//    public Rigidbody2D body()
//    {
//        return Body;
//    }

//    public bool right()
//    {
//        return Right;
//    }
//}
