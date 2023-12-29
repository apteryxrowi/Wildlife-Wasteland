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
    public Animation anim;
    public NavMeshAgent agent;
    public GameObject Player;

    // Start is called before the first frame update
    private void Start()
    {
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
                float reachedPositionDistance = 1f;
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
                float attackRange = 2f;
                if (Vector3.Distance(transform.position, Player.transform.position) < attackRange)
                {
                    // Target within attack range
                    if (Time.time > Timer)
                    {
                        state = States.Attack;
                        agent.SetDestination(transform.position);
                        anim.Play("Attack");
                        HealthHUDController.HealthChange(-5);
                        state = States.Chase;
                        float attackRate = 1f;
                        Timer = Time.time + attackRate;
                    }
                }
                float stopChaseDistance = 6f;
                if (Vector3.Distance(transform.position, Player.transform.position) > stopChaseDistance)
                {
                    // Too far, stop chasing
                    state = States.Return;
                }
                break;
            case States.Attack:
            // Dummy state for when the enemy is attacking
                break;
            case States.Return:
            // Return to Starting Position
                agent.SetDestination(startingPosition);
                anim.Play("Walk");
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
        float targetRange = 5f;
        if (Vector3.Distance(transform.position, Player.transform.position) < targetRange)
        {
            // Player within target range
            state = States.Chase;
        }
    }
}
