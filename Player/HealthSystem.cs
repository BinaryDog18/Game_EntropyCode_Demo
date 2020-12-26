using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

     private int health;
    [SerializeField] private int healthMax = 1000;
    //[SerializeField] private int healingPerMinute = 0;

    [SerializeField] private bool isVulnerable = false;
    [SerializeField] private bool isEnemy = true;
    [SerializeField] private float armor = 0.2f;    //  Armor in %

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    void Update()
    {
        //Debug.Log(health);
    }

    //  in case of shot
    void OnCollisionEnter(Collision colision)
    {

        if (!isVulnerable) return;

        BalasScript bullet = colision.gameObject.GetComponent<BalasScript>();

        if (bullet == null) return;


        NewDamage(bullet.damage * -(armor - 1), bullet.ammunition_bugged);

    }

    //  Subtrack or add the damage to the life bar. if it is heaing, must be negative
    public void NewDamage(float damage, bool isBugged = false)
    {
        int newHealth = health - (int)damage;

        if (newHealth <= 0) IsDead();
        else if (newHealth > healthMax && !isBugged) health = healthMax;

        health = newHealth;
    }

    void IsDead()
    {
        if(isEnemy) Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    
}
