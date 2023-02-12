using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public Ingredient_Info ingredient;
    public Transform spawnPoint;

    void Update()
    {
        ValidateGrill();
    }

    private void ValidateGrill()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (ingredient != null)
            {
                if (ingredient.grillResult != null)
                {
                    // destroy ingredient istance, not the prefab
                    Instantiate(ingredient.grillResult, spawnPoint.position, Quaternion.identity);
                    Debug.Log("Grilled");
                }
                else
                    Debug.Log("You can't grill");
            }
            else
                Debug.Log("No food to grill");
        }        
    }
}
