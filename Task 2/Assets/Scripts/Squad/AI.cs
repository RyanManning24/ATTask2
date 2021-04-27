using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public GameObject player;
    public GameObject[] baseTarget1 = new GameObject[4];
    public GameObject[] baseTarget2 = new GameObject[4];

    public NavMeshAgent[] navMesh = new NavMeshAgent[4];

    public float squadSize = 4;

    public bool followOn = true;
    private bool formation1 = true;
    private bool formation2 = false;
    

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void LateUpdate()
    {  
        if(followOn && formation1 && !formation2)
        {
            allFollowAroundPlayerForm1();
        }
        else if(followOn && !formation1 && formation2)
        {
            Formation2();
        }

    }

    private void Update()
    {
        FollowToggle();
    }

    void allFollowAroundPlayerForm1()
    {

        for(int i = 0; i <= squadSize - 1; i++)
        {
            navMesh[i].SetDestination(baseTarget1[i].transform.position);
        }

        

    }

    void Formation2()
    {
        for (int i = 0; i <= squadSize - 1; i++)
        {
            navMesh[i].SetDestination(baseTarget2[i].transform.position);
        }
    }

    public void Formation1On()
    {
        formation2 = false;
        formation1 = true;
    }   

    public void Formation2On()
    {
        formation1 = false;
        formation2 = true;
    }

    public void FollowToggle()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            followOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            followOn = false;
        }
    }
}
