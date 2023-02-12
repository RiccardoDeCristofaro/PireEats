using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingTable : MonoBehaviour
{
    public Ingredient_Info ingredient;
    public Transform spawnPoint;

    void Update()
    {
        ValidateCut();
    }

    private void ValidateCut()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (ingredient != null)
            {
                if (ingredient.cutResult != null)
                {
                    // destory ingredient istance, not the prefab
                    Instantiate(ingredient.cutResult, spawnPoint.position, Quaternion.identity);
                    Debug.Log("Cut");
                }
                else
                    Debug.Log("You can't cut");
            }
            else
                Debug.Log("No food to cut");
        }    
    }
}
