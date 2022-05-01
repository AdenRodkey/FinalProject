/*Aden Rodkey
 * 4/30/22
 * A script to control the enemy.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Variables
    Rigidbody rb;
    NavMeshAgent agent;
    private GameObject player;
    private bool isAttacking;
    public GameObject enemy;
    public int enemyhealth;
    //public GameObject timeManager;
    //private LightManager TimeofDay;
    //private GameObject enemyzone;
    //private int enemycounter;
    //private Transform estTransform;
    //private float spawnY;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the agent.
        agent = enemy.GetComponent<NavMeshAgent>();
        //Sets hp.
        enemyhealth = 100;
        //Establishes player.
        player = GameObject.FindGameObjectWithTag("Player");
      

    }

    // Update is called once per frame
    void Update()
    {
        //Uses floats along with built in navmesh functions and vector3s to establish distance ot palyer.
        float distplayer = agent.pathPending ? Vector3.Distance(transform.position, player.transform.position) : agent.remainingDistance;

        //Esnures the agent is stopped if its too close or too far to stop it from moving.S
        agent.isStopped = distplayer <= 3f || distplayer >= 15f;

        //Look at player and move towards it.
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        agent.SetDestination(player.transform.position);

    }
    
   

        /* public void ChangeState(EnemyState currentstate)
        {
            activeState = currentstate;

            switch(activeState);
            {

            }
        } */
    }
