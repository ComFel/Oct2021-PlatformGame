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
    //private Transform myEnemyTransform;
    private SpriteRenderer myEnemySprite;
    public bool enemyIsGoingRight = false;
    public float mRaycastingDistance = 1f;

    public int enemySpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        enemyState = State.Idle;
        myEnemyAnimator = gameObject.GetComponent<Animator>();
        //myEnemyTransform = gameObject.GetComponent<Transform>();
        myEnemySprite = gameObject.GetComponent<SpriteRenderer>();
        myEnemySprite.flipX = enemyIsGoingRight;
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
        Vector3 directeionTranslation = enemyIsGoingRight ? -transform.right : transform.right;
        directeionTranslation *= Time.deltaTime * enemySpeed;

        transform.Translate(directeionTranslation);
        
        CheckForWalls();
    }

    /*
     * Reference code from internet, for explanation follow the link below
     * https://www.noveltech.dev/simple-patrolling-monster-unity/
     */
    private void CheckForWalls()
    {
        
        Vector3 raycastDirection = enemyIsGoingRight ? Vector3.right : Vector3.left;

        // Raycasting takes as parameters a Vector3 which is the point of origin, another Vector3 which gives the direction, and finally a float for the maximum distance of the raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        // if we hit something, check its tag and act accordingly
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Terrain")
            {
                enemyIsGoingRight = !enemyIsGoingRight;
                myEnemySprite.flipX = enemyIsGoingRight;

            }
            if (hit.transform.tag == "Player")
            {
                enemyState = State.Attack;
                Debug.Log("PLAYER FOUND");
            }
        }
    }

    void Attacking()
    {
        myEnemyAnimator.SetBool("PlayerOnSight", true);
        //ToDo-> Check to flip srpite
        //ToDo-> Damage and Health
    }
}
