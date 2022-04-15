using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp;
    public int stamina;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        stamina = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stamina--;
        }
    }
}
