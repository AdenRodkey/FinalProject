using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        EnemyPlane.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
