using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Physics variable
    Rigidbody2D Body;
    bool OnGround;

    //Attribute in Game Variable
    public float speed;
    public float jump;
    public float MaxHealth;
    public float MaxEnergy;
    public float CurrentHealth;
    public float Damage;
    bool CanDash=true;

    //Animation variables
    Animator Anim;
    bool Right; // turn right?
    bool IsRun; // Is Run?
    bool IsJump; // Is Jump
    bool IsFire; // Is Fire?
    bool IsFall; // Is Fall?
    bool IsClimb; //Climbing
    public TrailRenderer tr;

    //Initial Fire variables
    public BallEnergy Ball_Energy;
    public float CoolDown;
    float NextTime;

    //Initial Health Bar
    public Slider HealthBar;
    public Gradient gradient;
    public Image Fill;

    //Initial Energy Bar
    public Slider EnergyBar;
    public Image EnergyFill;

    //Inventory Menu
    public RectTransform InventoryMenu;
    bool Active=false;
    //Inventory
    PlayerInventory pi;

    //Skill
    public Transform SkillChoose;
    SkillChosen ss;
    int StarMount;
    //Color effect
    bool CanbeHit=true;
    float BeHitTime;

    public Vector2 EtnVelocity;

    public Canvas PlayerStatBar;
    public Joystick joystick;
    Vector3 Distance;


    void Start()
    {
        //Rigid and Animator Variable
        Body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        OnGround = true;

        //Next time shooting
        NextTime = Time.time;
        
        //First Animation's status 
        IsRun = false;
        Right = true;
        IsJump = false;
        IsFall = false;
        IsFire = false;

        //First HealthBar's Everything
        CurrentHealth = MaxHealth;
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = MaxHealth;
        Fill.color = gradient.Evaluate(1f);

        EnergyBar.maxValue = MaxEnergy;
        EnergyBar.value = MaxEnergy;


        //Damage of Player and EnergyBall
        Damage = 20.0f;
        //Ball_Energy.SetDamage(Damage);

        //pi = GetComponent<PlayerInventory>();

        //pi.AddItemInInventory(new Items { IDItem = 1, NameItem = "Winds", AmountItem = 1 });
        //pi.AddItemInInventory(new Items { IDItem = 1, NameItem = "Winds", AmountItem = 1 });
        //pi.AddItemInInventory(new Items { IDItem = 2, NameItem = "Boots", AmountItem = 1 });
        //pi.AddItemInInventory(new Items { IDItem = 3, NameItem = "Sword", AmountItem = 1 });
        //pi.AddItemInInventory(new Items { IDItem = 4, NameItem = "Skull", AmountItem = 1 });
        //pi.AddItemInInventory(new Items { IDItem = 5, NameItem = "Slime", AmountItem = 1 });

        

        //Skill
        ss = SkillChoose.GetComponent<SkillChosen>();

        Distance = new Vector3(0, 18.4f-16.63f, 0);

        //EtnVelocity = new Vector2(0, 0);


    }

    private void Update()
    {
        PlayerStatBar.transform.position = transform.position + Distance;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Active = !Active;
            InventoryMenu.gameObject.SetActive(Active);//if menu true
            //Time.timeScale = Convert.ToSingle(!Active);
            //Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetKeyDown(KeyCode.Z))//Dash - z
        {
            if(CanDash)
            {
                CanDash = false;
                if(Right)
                    Body.AddForce(new Vector2(speed * 1.5f, 0), ForceMode2D.Impulse);
                else
                    Body.AddForce(new Vector2(-speed * 1.5f, 0), ForceMode2D.Impulse);
                tr.emitting = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.Z))//UnDash - release z
        {
            Body.velocity = new Vector2(0, 0);
            tr.emitting = false;
            CanDash = true;
        }

        if (Input.GetKeyUp(KeyCode.V))//Use skill - v
        {
            ss.UsingSkill();
        }

        if (Input.GetKeyDown(KeyCode.C))//Fire - c
        {
            PlayerFire();
        }

        if (Input.GetKeyUp(KeyCode.Escape))//Use skill - v
        {
            Application.Quit();
        }

        BeingHitEffect(); // change color back after being hit

        PlayerRun();
    }

    void FixedUpdate()
    {
        

        PlayerFall();

        PlayerAnimation();

        if (Input.GetKey(KeyCode.X) || joystick.Vertical > 0.5)//Jump - x
        {
            PlayerJump();
        }

        HealthBar.value = CurrentHealth;
        Fill.color = gradient.Evaluate(HealthBar.normalizedValue);


    }

    void PlayerAnimation()
    {
        //Animation - Run
        if (IsRun && !IsFire && !IsJump && !IsFall) //Run and Not Fire = running
            Anim.Play("Player Running"); //Animation Player Running is stared

        //Animation - Fire
        if ((Time.time > NextTime - 0.7f) && !IsJump && !IsFall)
            IsFire = false;
        else if (Time.time > NextTime - 0.9f)
            IsFire = false;
        if (IsFire)
            Anim.Play("Player Fire");

        //Animation - Jump
        if (IsJump && !IsFire && !IsClimb)
        {
            Anim.Play("Player Jumping");
        }


        //Animation - Fall
        if (IsFall && !IsFire && !IsClimb)
        {
            Anim.Play("Player Falling");
        }

        
        if(!(IsRun || IsJump || IsFall || IsFire || IsClimb))
        {
            Anim.Play("Player Idle");
        }

        if (IsClimb)
        {
            Anim.Play("Player Climbing");
            //IsFall = false;
        }


    }

    void PlayerFall()
    {
        if (Body.velocity.y < -0.01)//is falling
        {
            IsFall = true;
            IsJump = false;
            OnGround = false;
        }
    }

    public void PlayerFire()
    {
        if (Time.time > NextTime)
        {
            NextTime = Time.time + CoolDown;
            IsFire = true;
            FireEnergyBall();
        }
    }

    void PlayerJump()
    {
        if(OnGround)
        {
            Body.velocity = new Vector2(Body.velocity.x, jump);
           
            IsJump = true;
            IsFire = false;
            OnGround = false;
        }

    }

    void PlayerRun()
    {
        float Move = Input.GetAxis("Horizontal") + joystick.Horizontal; // Move increase a little from 0, 0.1,.. to 1 or -1
        FLipBody(Move);

        if (CanDash)
        {
            Body.velocity = new Vector2(Move * speed, Body.velocity.y);// + EtnVelocity;
            if (Move == 0) IsRun = false;
            else IsRun = true;
        }
    }

    void FLipBody(float Move) // Flip body
    {
        if (Right && Move < 0)
        {
            Right = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        else if (!Right && Move > 0)
        {
            Right = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void FireEnergyBall()
    {
        Vector2 FirePosition;
        float angle;
        if (Right)
        {
            FirePosition = Body.position + new Vector2(0.9f, -0.3f);
            angle = 0;
        }
        else
        {
            FirePosition = Body.position + new Vector2(-0.9f, -0.3f);
            angle = -180;
        }

        Instantiate(Ball_Energy, FirePosition, Quaternion.Euler(new Vector3(0, 0, angle)));
    }

    public void BeingHit(float damage) // change color when being hit
    {
        if(CanbeHit)
        {
            BeHitTime = Time.time;
            CurrentHealth -= damage;
            HealthBar.value = CurrentHealth;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255, 120f / 255, 120f / 255);
            CanbeHit = false;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(PlayerStatBar);
                SceneManager.LoadScene(0);
            }
               
        }
    }
    void BeingHitEffect() // change color back
    {
        if (Time.time > BeHitTime + 0.5)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            CanbeHit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Layer6: Ground
        {
            IsJump = false;
            IsFall = false;
            OnGround = true;
        }
        if (collision.gameObject.CompareTag("DeadGround"))
            BeingHit(10000000);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Layer6: Ground
        {
            IsJump = false;
            IsFall = false;
            OnGround = true;
        }
        if (collision.CompareTag("Ladder"))
        {

            float Vertical = Input.GetAxis("Vertical");
            Body.velocity = new Vector2(Body.velocity.x, 2 * Vertical);
            if (Vertical != 0)
            {
                Body.gravityScale = 0f;
                IsClimb = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Body.gravityScale = 1f;
            IsClimb = false;
            
        }
    }

    public void PlayerHeal(float HealingMount)
    {
        CurrentHealth += HealingMount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void PlayerMoveTo(Transform end)
    {
        while (transform.position != end.position)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            transform.position = Vector3.MoveTowards(transform.position, end.position, 10 * Time.deltaTime);
        }
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    public Rigidbody2D GetPlayerRigid()
    {
        return Body;
    }

    public void SetStarMount(int mount)
    {
        StarMount += mount;
    }
    public int GetStarMount()
    {
        return StarMount;
    }
    public void SkillUsing()
    {
        ss.UsingSkill();
    }
    public void DashDown()
    {
        if (CanDash)
        {
            CanDash = false;
            if (Right)
                Body.AddForce(new Vector2(speed * 1.5f, 0), ForceMode2D.Impulse);
            else
                Body.AddForce(new Vector2(-speed * 1.5f, 0), ForceMode2D.Impulse);
            tr.emitting = true;
        }
    }
    public void DashUp()
    {
        Body.velocity = new Vector2(0, 0);
        tr.emitting = false;
        CanDash = true;
    }

    public void MenuOpen()
    {
        Active = !Active;
        InventoryMenu.gameObject.SetActive(Active);
    }
}
