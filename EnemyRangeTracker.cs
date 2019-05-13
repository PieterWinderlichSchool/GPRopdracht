using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeTracker : MonoBehaviour
{

    [SerializeField]private float _speed;
    private Transform target;
    [SerializeField]private float _range;
   
    public Action activeDeligate;
    public Action inActiveDeligate;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        transform.LookAt(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                Debug.Log(enemy);
            }
            if (distanceToEnemy > _range)
            {
                target = null;
                
            }
        }
        if (nearestEnemy != null && shortestDistance <= _range)
        {

            target = nearestEnemy.transform;
            MoveToEnemy(target.position);
            Debug.Log(target);
        }
        //else if(nearestEnemy == null)
        //{
        //    Debug.Log("Hallo");
        //    inActiveDeligate();
        //}
        if (nearestEnemy != null && shortestDistance == 0)
        {
            activeDeligate();
            Debug.Log("hallo");
        }
    }
    private void MoveToEnemy(Vector3 targetPos)
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,targetPos,step) ;
        Debug.Log("hallo");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
