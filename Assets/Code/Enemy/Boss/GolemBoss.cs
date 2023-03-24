using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBoss : MonoBehaviour
{
    Animator animator;
    float NextRan;
    int Ran;
    public GameObject ArmProjectile;
    public GameObject Laser;
    public GameObject player;

    Vector3 First;
    Vector3 To;

    float Armor;
    void Start()
    {
        animator = GetComponent<Animator>();
        To = transform.position;
        NextRan = Time.time + 1;
        First = To;
    }
    void Update()
    {
        RandomAction();
        transform.position = Vector3.MoveTowards(transform.position, To, Time.deltaTime * 10);
        GolemDeath();

        if (player.transform.position.x < transform.position.x)
        {
            FlipBody(-1);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            FlipBody(1);
        }
    }

    void GolemIdle()
    {
        animator.Play("Golem Idle");
    }
    void GolemGlowing()
    {
        animator.Play("Golem Glowing");
    }
    void GolemAttack()
    {
        animator.Play("Golem Attack");
        ArmProjectile.GetComponent<ArmProjectile>().Flip = transform.localScale.x; 
        Instantiate(ArmProjectile, transform.position, transform.rotation);
    }
    void GolemImmune()
    {
        animator.Play("Golem Immune");
        To = player.transform.position + new Vector3(0,0.8f,0);
    }
    void GolemMelee()
    {
            animator.Play("Golem melee");
    }
    void GolemLaser()
    {
        float flip = transform.localScale.x / Math.Abs(transform.localScale.x);
        animator.Play("Golem Laser");
        Laser.GetComponent<Laser>().FlipBody(flip);
        Instantiate(Laser, To + new Vector3(flip * 7,0.5f,0), transform.rotation);
    }
    void GolemArmor()
    {
        animator.Play("Golem Armor");
    }
    void GolemDeath()
    {
        //if(gameObject.GetComponent<Enemy>().GetCurrentHealth()<=0)
        //{
        //    animator.Play("Golem Death");
        //    Destroy(gameObject, 2);
        //}
    }
    void RandomAction()
    {
        if(Time.time > NextRan + 4)
        {
            To = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            First = transform.position;
            Ran = UnityEngine.Random.Range(3, 7);
            NextRan = Time.time;
            switch (Ran)
            {
                case 3:
                    Debug.Log("GolemAttack");
                    GolemAttack();
                    break;
                case 4:
                    Debug.Log("GolemImmune");
                    GolemImmune();
                    break;
                case 5:
                    Debug.Log("GolemMelee");
                    GolemMelee();
                    break;
                case 6:
                    Debug.Log("GolemLaser");
                    GolemLaser();
                    break;
                case 7:
                    Debug.Log("GolemArmor");
                    GolemArmor();
                    break;

                default:
                    break;
            }
            return;
        }
        if(Time.time > NextRan + 2.5)
        {
            GolemGlowing();
            To = First;
            return;
        }
        if (Time.time > NextRan + 2)
        {
            GolemIdle();
            To = First;
            return;
        }
        if (Time.time > NextRan)
        {
        }
    }

    void AnimatorState(string state)
    {
        animator.Play(state);
    }

    void FlipBody(float side)
    {
        Vector3 scale = transform.localScale;
        scale.x = Math.Abs(scale.x) * side;
        transform.localScale = scale;
    }
}
