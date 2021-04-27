using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletStart;

    private GameObject InstanceBullet;

    private float bulletForce = 1000.0f;

    public float damage = 10;

    private bool fireOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireBullet()
    {
        //if(fireOnce)
        //{
            fireOnce = false;
            InstanceBullet = Instantiate(bullet, bulletStart.transform.position, new Quaternion(0, 0, 0, 0));

            Rigidbody bulletRB;
            bulletRB = InstanceBullet.GetComponent<Rigidbody>();

            bulletRB.AddForce(transform.forward * bulletForce);


            Destroy(InstanceBullet, 1);
            
        //}
        

        
    }
}
