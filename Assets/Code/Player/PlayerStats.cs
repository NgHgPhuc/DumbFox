//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//using UnityEngine.UI;

//public class PlayerStats : MonoBehaviour //Stats - Stats Bar 
//{
//    //Attribute in Game Variable - Stats
//    [field: SerializeField] public float Speed { get; set; }
//    [field: SerializeField] public float Jump { get; set; }
//    [field: SerializeField] public float MaxHealth { get; set; }
//    [field: SerializeField] public float MaxEnergy { get; set; }
//    [field: SerializeField] public float Damage { get; set; }

//    float CurrentHealth;

//    //Initial Health Bar
//    [SerializeField] Slider HealthBar;
//    [SerializeField] Gradient gradient;
//    [SerializeField] Image Fill;

//    //Initial Energy Bar
//    [SerializeField] Slider EnergyBar;
//    [SerializeField] Image EnergyFill;



//    void Start()
//    {
//        //First HealthBar's Everything
//        CurrentHealth = MaxHealth;
//        HealthBar.maxValue = MaxHealth;
//        HealthBar.value = MaxHealth;
//        Fill.color = gradient.Evaluate(1f);

//        EnergyBar.maxValue = MaxEnergy;
//        EnergyBar.value = MaxEnergy;


//        //Damage of Player and EnergyBall
//        Damage = 20.0f;
//        //Ball_Energy.SetDamage(Damage);
//    }

//    private void Update()
//    {
//    }

//    public void Heal(float HealingMount)
//    {
//        if (CurrentHealth < MaxHealth)
//        {
//            CurrentHealth += HealingMount;
//        }
//    }

//    public void BeingHit(float damage) 
//    {
//        CurrentHealth -= damage;
//        HealthBar.value = CurrentHealth;
//        if (CurrentHealth <= 0)
//            Destroy(gameObject);
//    }
//}
