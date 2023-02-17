using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenRecipeBook : MonoBehaviour
{
    public GameObject recipeBook;
    public KeyCode OpenBook = KeyCode.Alpha2;
    public MoveCamera movCam;

    void Update()
    {
        if (Input.GetKeyDown(OpenBook))
        {
            if (!recipeBook.activeSelf)
            {
                recipeBook.SetActive(true);
                movCam.enabled = false;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                recipeBook.SetActive(false);
                movCam.enabled = true;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
