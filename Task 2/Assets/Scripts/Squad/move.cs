using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move : MonoBehaviour
{
    public Transform camPos;

    public NavMeshAgent soilder1;
    public NavMeshAgent soilder2;
    public NavMeshAgent soilder3;
    public NavMeshAgent soilder4;


    public void MoveAI()
    {
        RaycastHit hit;

        if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        {
            //move to place 
            soilder1.SetDestination(hit.point);
            
        }
    }

    public void MoveAI2()
    {
        RaycastHit hit;

        if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        {
            //move to place 
            soilder2.SetDestination(hit.point);
            
        }
    }

    public void MoveAI3()
    {
        RaycastHit hit;

        if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        {
            //move to place 
            soilder3.SetDestination(hit.point);
        }
    }

    public void MoveAI4()
    {
        RaycastHit hit;

        if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        {
            //move to place 
            soilder4.SetDestination(hit.point);
        }
    }




}



