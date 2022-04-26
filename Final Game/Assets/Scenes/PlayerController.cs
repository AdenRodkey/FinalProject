using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Slider hp;
    public Slider stamina;
    public float movespeed;
    public bool IsSprinting;
    public bool IsNotSprinting;
    // Start is called before the first frame update
    void Start()
    {
        hp.value = 100;
        stamina.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (stamina.value >= 0)
                stamina.value--;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }
  
}
