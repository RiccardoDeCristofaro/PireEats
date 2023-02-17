using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class MoveToNextScene : MonoBehaviour
{
    #region	Public variables
    #endregion
    #region	Private variables
    #endregion
    #region	Lifecycle

    #endregion
    #region	Public methods
    // load scene of index "sceneId"
    public void MovingToNextScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void Quit()
    {
        // exit app;
        Application.Quit();
    }

    #endregion
    #region	Private methods
    #endregion
}
