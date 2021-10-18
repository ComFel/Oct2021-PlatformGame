using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Skeleton_Controller : MonoBehaviour
{
    enum State 
    {
        Idle,
        Patrol,
        Attack
    }

    State enemyState;

    private Animator myEnemyAnimator;
    private Transform myEnemyTransform;

    public int enemySpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        enemyState = State.Idle;
        myEnemyAnimator = GetComponent<Animator>();
        myEnemyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case State.Idle:
                inIdle();
                break;
            case State.Patrol:
                Patroling();
                break;
            case State.Attack:
                Attacking();
                break;
        }
    }

    void inIdle()
    {
        myEnemyAnimator.SetInteger("WaitTime", 0);
        Debug.Log("Estado Idle to walk");
        enemyState = State.Patrol;
    }

    void Patroling()
    {
        //myEnemyTransform.position = new Vector2(1, 0) * enemySpeed * Time.deltaTime;
    }

    void Attacking()
    {

    }
}
