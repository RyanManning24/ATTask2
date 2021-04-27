using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public float shootTime = 2f;

    public LayerMask targetMask;
    public LayerMask obsticleMask;

    public Gun gunScript;
    public GameObject gunEnd;

    public bool startCo = true;

    private void Start()
    {

        StartCoroutine(FindVisibleTargets());
      
    }

    void LateUpdate()
    {
        //FindVisibleTargets();

    }



    IEnumerator FindVisibleTargets()
    {
        //this does work but its applying damage more than once a frame
        while(startCo)
        {
            Collider[] targetsInViewRadius = Physics.OverlapSphere(gunEnd.transform.position, viewRadius, targetMask);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform targets = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (targets.position - gunEnd.transform.position).normalized;
                if (Vector3.Angle(gunEnd.transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(gunEnd.transform.position, targets.position);
                    RaycastHit hit;

                    if (!Physics.Raycast(gunEnd.transform.position, dirToTarget, distanceToTarget, obsticleMask))
                    {
                        if (Physics.Raycast(gunEnd.transform.position, dirToTarget, out hit, distanceToTarget))
                        {

                            Target enemy = hit.transform.GetComponent<Target>();
                            if (enemy != null)
                            {
                                //Look at enemy 
                                transform.LookAt(targets.position, Vector3.up);
                                //Shoot
                                gunScript.Shoot(enemy);
                                yield return new WaitForSecondsRealtime(2f);
                            }
                        }
                    }
                }
            }
            yield return null;
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
