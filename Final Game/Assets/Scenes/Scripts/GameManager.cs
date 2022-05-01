/*Aden Rodkey
 * 4/30/22
 * Simple gamemanager script, largely unused.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    public GameObject EnemyPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets the meshrenderer for the navmesh to false so that you don't see it over the procedural generation.
        EnemyPlane.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
