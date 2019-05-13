using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public EnemyRangeTracker ERT;
    private void Start()
    {
        ERT = gameObject.GetComponent<EnemyRangeTracker>();
        ERT.activeDeligate += Attack;
    }
    public void Attack()
    {
        Debug.Log("Attack");
    }
}
