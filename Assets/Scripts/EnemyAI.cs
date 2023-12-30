using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Credits to https://www.youtube.com/watch?v=db0KWYaWfeM

public class EnemyAI : MonoBehaviour
{
    private enum States
    {
        Roaming,
        Chase,
        Attack,
        Return,
    }
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private States state;
    private float Timer;
    private float animTimer;
    private GameObject Player;
    public Animation anim;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.Find("Player");
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
        state = States.Roaming;
    }
    // Update is called every frame
    private void Update()
    {
        switch (state) {
            default:
            case States.Roaming:
            // When the enemy is roaming / idle
                agent.SetDestination(roamPosition);
                anim.Play("Walk");
                agent.speed = 1.0f;
                float reachedPositionDistance = 2f;
                if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
                {
                    // Reached Roam Position
                    roamPosition = GetRoamingPosition();
                }
                FindTarget();
                break;
            case States.Chase:
            // When the enemy is chasing the Player
                agent.SetDestination(Player.transform.position);
                anim.Play("Run");
                agent.speed = 2f;
                float attackRange = 4f;
                if (Vector3.Distance(transform.position, Player.transform.position) < attackRange)
                {
                    // Target within attack range
                    if (Time.time > Timer)
                    {
                        Vector3 relativePos = Player.transform.position - transform.position;
                        state = States.Attack;
                        agent.SetDestination(transform.position);
                        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                        anim.Play("Attack");
                        animTimer = Time.time + 2;
                        HealthHUDController.HealthChange(-5);
                        float attackRate = 1f;
                        Timer = Time.time + attackRate;
                    }
                }
                float stopChaseDistance = 8f;
                if (Vector3.Distance(transform.position, Player.transform.position) > stopChaseDistance)
                {
                    // Too far, stop chasing
                    state = States.Return;
                }
                break;
            case States.Attack:
                // When the enemy is attacking
                if (Time.time > animTimer)
                {
                    state = States.Chase;
                }
                break;
            case States.Return:
            // Return to Starting Position
                agent.SetDestination(startingPosition);
                anim.Play("Walk");
                agent.speed = 1f;
                reachedPositionDistance = 1f;
                if (Vector3.Distance(transform.position, startingPosition) < reachedPositionDistance)
                {
                    // Reached Start Position
                    state = States.Roaming;
                }
                break;
        }
    }
    private Vector3 GetRandomDir()
    {
        Vector3 tmp= new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        return tmp;
    }
    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(5f, 12f);
    }
    private void FindTarget()
    {
        float targetRange = 7f;
        if (Vector3.Distance(transform.position, Player.transform.position) < targetRange)
        {
            // Player within target range
            state = States.Chase;
        }
    }
}
