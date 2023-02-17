using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]
public class PauseClick : MonoBehaviour
{

    public List<GameObject> disableObjects = new List<GameObject>();
    public Camera mainCam;
    private Scene currentScene;
    #region	Pause

    void Update()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 0; // timer =0
            currentScene = SceneManager.GetActiveScene(); // get the active scene as a variable;
            
            for (int i = 0; i < disableObjects.Count; i++)
            {
                disableObjects[i].gameObject.SetActive(true);
               
            }
            mainCam.gameObject.SetActive(false);
        }
    }
    public void PlayGame(int scene)
    {
        Time.timeScale = 1; // reset  time
        mainCam.gameObject.SetActive(true);
        for (int i = 0; i < disableObjects.Count; i++)
        {
            disableObjects[i].gameObject.SetActive(false);
        }
    }
    public void Quit(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;

    }

}
#endregion