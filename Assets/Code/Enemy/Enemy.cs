using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float MaxHeath;
    float CurrentHealth;
    public float Damage;
    public GameObject EnemyDeathFx;
    public GameObject Star;

    SpriteRenderer sr;
    float StartTimeColoring;
    float ChangeColorTime;

    public Canvas EnemyHealthBar;
    GameObject EnemyHealthBarClone;
    Slider HealthBar;

    float NextDameCollision;

    void Start()
    {
        CurrentHealth = MaxHeath;
        sr = gameObject.GetComponent<SpriteRenderer>();

        EnemyHealthBarClone = Instantiate(EnemyHealthBar.gameObject, transform.position + new Vector3(-0.1f, 0.8f, 0f), transform.rotation);
        EnemyHealthBarClone.transform.localScale = transform.localScale / 300;

        HealthBar = EnemyHealthBarClone.transform.Find("Health").GetComponent<Slider>();
        HealthBar.maxValue = MaxHeath;
        HealthBar.value = MaxHeath;
    }

    // Update is called once per frame
    void Update()
    {
        SetColor();//change color when get hit

        EnemyHealthBarClone.transform.position = transform.position + new Vector3(-0.1f, 0.8f, 0f);

        HealthBar.value = CurrentHealth;

    }
    public void BeingHit(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
        HealthBar.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            Destroy(EnemyHealthBarClone.gameObject);
            Destroy(gameObject);
            Instantiate(EnemyDeathFx, transform.position, transform.rotation);
            Instantiate(Star, transform.position, transform.rotation);

        }
    }
    public bool BeingHitToDie(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
        if (CurrentHealth <= 0)
        {
            Destroy(EnemyHealthBarClone.gameObject);
            Destroy(gameObject);
            Instantiate(EnemyDeathFx, transform.position, transform.rotation);
            Instantiate(Star, transform.position, transform.rotation);
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            NextDameCollision = Time.time + 1f;
            Player Fox = collision.gameObject.GetComponent<Player>();
            Fox.BeingHit(Damage);

            //BeingPushBack(Fox);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if(Time.time > NextDameCollision)
            {
                NextDameCollision = Time.time + 1f;
                Player Fox = collision.gameObject.GetComponent<Player>();
                Fox.BeingHit(Damage);

                //BeingPushBack(Fox);
            }
    }

    void BeingPushBack(Player Fox)
    {
        Rigidbody2D playerRigid = Fox.gameObject.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(-10, 0).normalized;
        playerRigid.velocity = Vector2.zero;
        playerRigid.AddForce(force, ForceMode2D.Impulse);
    }

    public void SetColorInTime(Color RGB,float ChangeColorTime)
    {
        this.ChangeColorTime = ChangeColorTime;
        this.StartTimeColoring = Time.time;

        sr.color = RGB;
        
    }

    void SetColor()
    {
        if (Time.time > StartTimeColoring + ChangeColorTime)
            sr.color = Color.white;
    }

    public bool CurrentAndMax(float Divide) //active when current health <= max health/x
    {
        if (CurrentHealth <= MaxHeath / Divide)
            return true;
        return false;
    }
    public void Heal(float mount)
    {
        CurrentHealth += mount;
        if (CurrentHealth > MaxHeath)
            CurrentHealth = MaxHeath;
    }

    public void AddDamge(float mount)
    {
        Damage += mount;
    }


    public GameObject enemyHealthBar()
    {
        return EnemyHealthBarClone;
    }

    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }
}
