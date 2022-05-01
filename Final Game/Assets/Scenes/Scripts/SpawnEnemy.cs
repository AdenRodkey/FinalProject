/*Aden Rodkey
 * 4/30/22
 * To spawn enemies into the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //Variables, public and private.
    public GameObject enemy;
    public GameObject timeManager;
    private LightManager TimeofDay;
    private GameObject enemyzone;
    private int enemycounter;
    private Transform estTransform;
    private float spawnY;
    private GameObject player;

    public int enemyspawned;

    // Start is called before the first frame update
    void Start()
    {
        //USes enemycounter to track the enemies spawned.
        //Sets timeofday (Scrapped) to try and spawn enemies at night.
        //Gets the player for the enemy transform position.
        //Uses a zone to spawn the nemies. 
        enemycounter = 3;
        TimeofDay = timeManager.GetComponent<LightManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyzone = GameObject.Find("EnemySpawnZone");
        estTransform = enemyzone.transform;
        spawnY = GameObject.Find("Player").transform.position.y;
        
        Debug.Log("Spawned Enemies");
        //Spawn enemies function.
        SpawnEnemies();
    }

    
    //A function to spawn the enemies using a minimum and maximum x and z axis (forward and side to side)
    //Uses an empty game object's bounds to have the actual zone.
    public void SpawnEnemies()
    {

        float minX = estTransform.position.x - estTransform.lossyScale.x / 2f;
        float maxX = estTransform.position.x + estTransform.lossyScale.x / 2f;

        float minZ = estTransform.position.z - estTransform.lossyScale.z / 2f;
        float maxZ = estTransform.position.z + estTransform.lossyScale.z / 2f;



       //Loops through 3 times and spawns that a random range of the min and max values established above.
        for (int i = 0; i < 3; i++)
        {
            float spawnX = Random.Range(minX, maxX);
            float spawnZ = Random.Range(minZ, maxZ);
            float offset = 2f;
            Vector3 spawnPosition = new Vector3(spawnX, spawnY + offset, spawnZ);


            //Creates the enemy clone.
            GameObject newenemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            //Instaniates enemyspawned.
            enemyspawned++;
            Debug.Log(enemyspawned);


        }
        
    }
}
