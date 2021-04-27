using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Ping pingScript;
    public NavMeshAgent navMesh1;
    public NavMeshAgent navMesh2;
    public NavMeshAgent navMesh3;
    public NavMeshAgent navMesh4;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pingScript.pingCreated && pingScript.squadNum == 1)
        {
            Move1();
        }
        if(pingScript.pingCreated && pingScript.squadNum == 2)
        {
            Move2();
        }
        if (pingScript.pingCreated && pingScript.squadNum == 3)
        {
            Move3();
        }
        if (pingScript.pingCreated && pingScript.squadNum == 4)
        {
            Move4();
        }
    }

    public void Move1()
    {
        navMesh1.SetDestination(pingScript.getHitPoint());
        pingScript.pingCreated = false;
        pingScript.squadNum = 0;

    }
    private void Move2()
    {
        navMesh2.SetDestination(pingScript.getHitPoint());
        pingScript.pingCreated = false;
        pingScript.squadNum = 0;
    }
    private void Move3()
    {
        navMesh3.SetDestination(pingScript.getHitPoint());
        pingScript.pingCreated = false;
        pingScript.squadNum = 0;
    }
    private void Move4()
    {
        navMesh4.SetDestination(pingScript.getHitPoint());
        pingScript.pingCreated = false;
        pingScript.squadNum = 0;
    }

}
