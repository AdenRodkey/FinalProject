/*Aden Rodkey
 * 4/30/22
 * Script to manage a directional light for a day night cycle sequence.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Executing always.
[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    //Variables to be used for the day night cycle and timeloop counter.
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private DaynNite Preset;
    public int timeloop;
    //Variables
    [SerializeField, Range(0, 360)] public float TimeOfDay1;
    [SerializeField, Range(0, 360)] public int TimeOfDay;


    //Simple start that sets variables.
    private void Start()
    {
        timeloop = 0;
        TimeOfDay1 = 180f;
        TimeOfDay = Mathf.RoundToInt(TimeOfDay1);
    }
    private void Update()
    {
        //Check statement for the light preset.
        if (Preset == null)
            return;
        //If the built app is playing, or editor, start cycling through timeofday1 and iancrementing it with time.deltatime.
        // Then using modulus by 360 for a proper cycle of 360 seconds.
        //Used timeofday with round to int to get a better value for usage in another script. (Scrapped)
        if (Application.isPlaying)
        {
            TimeOfDay1 += Time.deltaTime;
            TimeOfDay1 %= 360;
            TimeOfDay = Mathf.RoundToInt(TimeOfDay1);
            UpdateLighting(TimeOfDay1 / 360f);
            //Checks if the timeofday becomes 0, meaning one full loop or 3 minutes after start.
            //If it does, load the scene and destroy the player, while locking the cursor to confined.
            if(TimeOfDay == 0)
            {

                SceneManager.LoadScene(3);
                Destroy(PlayerController.player);
                //Locks cursor state to the game window.
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else
        {
            UpdateLighting(TimeOfDay1 / 360f);
        }
    }
    //Method to update the light using a float.
    //Uses render settings along with the DayNNite variables and sets them in coherence with timeperfect.
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        //Checks if the directionallight exists, if it does, sets its color and transform's rotation to a quaternion.
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    //Validate function to check if objects exist.
    //If the first doesn't, return and break out.
    //If the sun doesn't exist, set the directionallight to the sun to proceed down.
    //Else sift through the Light array with Light type.
    //If the Lighttype is directional, set it to the light and return to break out.
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
