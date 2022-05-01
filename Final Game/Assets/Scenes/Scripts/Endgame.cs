//Aden Rodkey
//4/30/22
//Endgame menu with buttons to play again or quit.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Endgame : MonoBehaviour
{
    //Variable buttons for the menus.
    public Button play;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Proper play method to use with built in button function to change scenes.
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    //Proper quit method to use with built in button function to change scenes.
    //Even included the if else for the editor is playing.
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
