/*Aden Rodkey
 * 4/30/22
 * Simple preset script with scriptable object acces to be used for the lightmanager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes it a scriptable object.
[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order =1)]
public class DaynNite : ScriptableObject
{
    //Variables
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
   
}
