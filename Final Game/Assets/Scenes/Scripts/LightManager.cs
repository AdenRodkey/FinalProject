using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private DaynNite Preset;
    private int timeloop;
    //Variables
    [SerializeField, Range(0, 360)] public float TimeOfDay1;
    [SerializeField, Range(0, 360)] public int TimeOfDay;



    private void Start()
    {
        timeloop = 0;
        TimeOfDay1 = 180f;
        TimeOfDay = Mathf.RoundToInt(TimeOfDay1);
    }
    private void Update()
    {
        if (Preset == null)
            return;
        if (Application.isPlaying)
        {
            TimeOfDay1 += Time.deltaTime;
            TimeOfDay1 %= 360;
            TimeOfDay = Mathf.RoundToInt(TimeOfDay1);
            UpdateLighting(TimeOfDay1 / 360f);
            if(TimeOfDay == 0)
            {
                
                timeloop++;
                Debug.Log(timeloop);
            }
        }
        else
        {
            UpdateLighting(TimeOfDay1 / 360f);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }


    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;

        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;

                }
            }
        }

    }
}
