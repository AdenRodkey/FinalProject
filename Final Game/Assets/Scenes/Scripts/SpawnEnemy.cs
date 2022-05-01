using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
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
        
        enemycounter = 3;
        TimeofDay = timeManager.GetComponent<LightManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyzone = GameObject.Find("EnemySpawnZone");
        estTransform = enemyzone.transform;
        spawnY = GameObject.Find("Player").transform.position.y;
        
        Debug.Log("Spawned Enemies");

        SpawnEnemies();
    }

    
    public void SpawnEnemies()
    {

        float minX = estTransform.position.x - estTransform.lossyScale.x / 2f;
        float maxX = estTransform.position.x + estTransform.lossyScale.x / 2f;

        float minZ = estTransform.position.z - estTransform.lossyScale.z / 2f;
        float maxZ = estTransform.position.z + estTransform.lossyScale.z / 2f;



       
        for (int i = 0; i < 3; i++)
        {
            float spawnX = Random.Range(minX, maxX);
            float spawnZ = Random.Range(minZ, maxZ);
            float offset = 2f;
            Vector3 spawnPosition = new Vector3(spawnX, spawnY + offset, spawnZ);



            GameObject newenemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            enemyspawned++;
            Debug.Log(enemyspawned);


        }
        
    }
}
