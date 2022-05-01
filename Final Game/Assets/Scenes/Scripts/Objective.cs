/*Aden Rodkey
 * 4/30/22
 * Simple objective coroutine script.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public Text objectivetext;
    // Start is called before the first frame update
    void Start()
    {
        //Sets text and starts coroutine.
        objectivetext.text = "Objective: Survive the day and night. \n Kill the enemies by running into them if you want.";
        StartCoroutine(Objectivetimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Coroutine for the objective text to fade and be set to alpha 1. (So you don't see it after reading it.)
    IEnumerator Objectivetimer()
    {
       
        Color alpha = objectivetext.color;
        yield return new WaitForSeconds(7.5f);
        for (float i = 1; i >= 0; i -= 0.01f)
        {
            alpha.a = i;
            objectivetext.color = alpha;
            
        }
       

    }
}
