using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    delegate void CurrentState();
    CurrentState currentState;

    EnemyAttack enemyAttack;

    private void Start()
    {
        enemyAttack = this.GetComponent<EnemyAttack>();
        currentState = enemyAttack.Attack;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            currentState = enemyAttack.Attack;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
           // currentState = Patrol;
    }
}
