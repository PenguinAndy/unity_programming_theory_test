using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent m_Agent;
    protected float m_Speed = 3.0f;
    protected int m_Sleep = 2;

    private Vector3 nextPosition;
    private float moveRange = 22.0f;
    private bool isStop = true;
    private GameManager gameManager;

    public int score = 0;


    protected virtual void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = m_Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected virtual void Start()
    {
        nextPosition = transform.position;
    }

    protected virtual void Update()
    {
        if (!gameManager.isGameOver)
        {
            float distance = Vector3.Distance(nextPosition, transform.position);
            if (distance < 1.0f)
            {
                if (isStop)
                {
                    StartCoroutine("ContinuteWalk");
                    isStop = false;
                }
                else
                {
                    if (m_Agent.isStopped == false)
                    {
                        m_Agent.isStopped = true;
                    }
                }

            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("wall");

            isStop = true;
            m_Agent.isStopped = true;
            StartCoroutine("ContinuteWalk");
        }
    }


    // random position
    private Vector3 RandomPosition()
    {
        float x = Random.Range(-moveRange, moveRange);
        float z = Random.Range(-moveRange, moveRange);
        Vector3 position = new Vector3(x , gameObject.transform.position.y , z);
        return position;
    }

    // strat walk
    private void StartWalk()
    {
        if (m_Agent.isStopped)
        {
            isStop = true;
            m_Agent.isStopped = false;
        }

        nextPosition = RandomPosition();

        m_Agent.SetDestination(nextPosition);
        
    }

    private IEnumerator ContinuteWalk()
    {
        yield return new WaitForSeconds(m_Sleep);
        StartWalk();
    }

}
