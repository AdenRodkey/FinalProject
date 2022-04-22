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
        objectivetext.text = "Objective: Survive the day and night.";
        StartCoroutine(Objectivetimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
