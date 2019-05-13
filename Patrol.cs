using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    int i = 0;
    [SerializeField] List<Transform> Waypoints = new List<Transform>();
    public EnemyRangeTracker ERT;
    private void Start()
    {
        ERT = gameObject.GetComponent<EnemyRangeTracker>();
        ERT.inActiveDeligate += Patroling;
    }
    //private void Update()
    //{
    //    Patroling();
    //}

    void Patroling()
    {
        

        print(i);
        Vector3 target = Waypoints[i].position - transform.position;
       transform.Translate(target.normalized * 2 *Time.deltaTime );

        if (Vector3.Distance(transform.position, Waypoints[i].position) <= 1 )
        {
           
            if (i == Waypoints.Count - 1)
            {
                i =  0;
            }
            else
            {
                i++;
            }
            

        }
            
            
            
    }
        

}    

