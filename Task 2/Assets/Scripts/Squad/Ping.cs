using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    public Transform camPos;
    public FollowCam followCam;
    public Projectile projectileScript;

    private Vector3 hitPoint;

    public bool pingCreated;

    public int squadNum = 0;

    public MoveTo moveToScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createPing();

    }

    

    void createPing()
    {
        RaycastHit hit;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Physics.Raycast(camPos.position, camPos.forward,out hit, Mathf.Infinity))
            {
                //hitPoint.transform.position = hit.transform.position;
                hitPoint = hit.point;
                pingCreated = true;
                squadNum = 1; 
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
            {
                //hitPoint.transform.position = hit.transform.position;
                hitPoint = hit.point;
                pingCreated = true;
                squadNum = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
            {
                //hitPoint.transform.position = hit.transform.position;
                hitPoint = hit.point;
                pingCreated = true;
                squadNum = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
            {
                //hitPoint.transform.position = hit.transform.position;
                hitPoint = hit.point;
                pingCreated = true;
                squadNum = 4;
            }
        }
    }

    public Vector3 getHitPoint()
    {
        return hitPoint;
    }

    public void ping1()
    {
        RaycastHit hit;

        if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        {
            //hitPoint.transform.position = hit.transform.position;
            hitPoint = hit.point;
            pingCreated = true;
            squadNum = 1;

            Debug.Log(hit.point);

            moveToScript.Move1();
        }
    }


}
