using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveToCover : MonoBehaviour
{
    private Target targetScript;
    private GameObject[] availableCover;
    private GameObject[] enemies;
    private float[] coverDistanceToPlayer;

    private bool checkHealing = true;

    public AI aiScript;
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        targetScript = gameObject.GetComponent<Target>();

        availableCover = GameObject.FindGameObjectsWithTag("Cover");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoverAlly());
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    IEnumerator CoverAlly()
    {
        //check if health is lower than 25 percent
        //if yes move the npc to cover or "safe" place 
        //once player is healed move him back
        while(checkHealing)
        {
            if (this.gameObject.tag == "Squad")
            {
                //Check if health is low
                if (targetScript.getHealth() < targetScript.GetMaxHealth() / 4)
                {
                    //ping to stop follow
                    aiScript.followOn = false;

                    //move to cover 
                    //loop through and check all the distances from the NPC then chose the shortest one and move to that one
                    FindClosestCover();

                    //wait for health to equal to maxHealth 
                    float oldHealth = targetScript.getHealth();

                    yield return new WaitForSecondsRealtime(6);

                    if (oldHealth >= targetScript.getHealth())
                    {
                        //health isnt healed yet 
                    }
                    else
                    {
                        if (targetScript.getHealth() == targetScript.GetMaxHealth())
                        {
                            //healing is done
                            aiScript.followOn = true;
                        }
                    }
                }
            }
            yield return null;
        }

    }

   void FindClosestCover()
    {
        float distanceToClosestCover = Mathf.Infinity;
        GameObject closestCover = null;
        GameObject[] allCover = GameObject.FindGameObjectsWithTag("Cover");

        foreach(GameObject currentCover in allCover)
        {
            float distanceToCover = (currentCover.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToCover < distanceToClosestCover)
            {
                distanceToClosestCover = distanceToCover;
                closestCover = currentCover;

                navMeshAgent.SetDestination(closestCover.transform.position);
            }
        }
    }

}
