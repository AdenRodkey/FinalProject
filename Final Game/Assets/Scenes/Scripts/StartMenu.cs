/*Aden Rodkey
 * 4/30/22
 * Start menu script with buttons and isntructions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    //Variables
    public Button play;
    public Button quit;
    public Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        
        instructions.text = "Controls: W to move forward. \n S to move backwards. \n Shift is to sprint \n Stamina is limited, do not waste it. \n Use your mouse to control the camera rotation.";
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Play function for the built in buttons function.
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    //Same thing as above, includes editor or application quit function.
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
