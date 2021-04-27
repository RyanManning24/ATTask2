using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 5.0f;
    public GameObject gunStart;
    public Projectile projectileScript;

    public bool canfire = true;


    //[SerializeField] private Target enemyTarget;


    public void Shoot(Target Enemy)
    {

        //fire projectile
        projectileScript.fireBullet();

        //apply damage
        Enemy.TakeDamage(damage);



    }
}

    


