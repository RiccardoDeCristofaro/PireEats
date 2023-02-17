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

    public List<GameObject> inactiveObjects = new List<GameObject>();
    public GameObject canvasToDisable;
    public Scene currentScene;
    #region	Lifecycle

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0; // timer =0
            currentScene = SceneManager.GetActiveScene(); // get the active scene as a variable;


            canvasToDisable.SetActive(false);
            for (int i = 0; i < inactiveObjects.Count; i++)
            {
                inactiveObjects[i].gameObject.SetActive(true);

            }
        }
    }
    public void PlayGame(int scene)
    {
        Time.timeScale = 1; // reset  time


        canvasToDisable.SetActive(true);
        for (int i = 0; i < inactiveObjects.Count; i++)
        {
            inactiveObjects[i].gameObject.SetActive(false);
        }
    }
    public void Quit(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;

    }

    public void ExitApp()
    {
        Application.Quit();
    }
}