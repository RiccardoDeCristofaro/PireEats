using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Recipe_List recipe_List;
    public Ingredient_Info ingredient;
    public Transform spawnPoint;

    private List<Ingredient_Info> validateIngredients = new List<Ingredient_Info>();
    private List<Ingredient_Info> ingredients_Clone = new List<Ingredient_Info>();
    private GameObject recipe;
    private Recipe_Info recipe_Info;

    private void Update()
    {
        InsertRecipe();
        GetRecipeInfo();
        ValidateIngredient();
    }

    private void InsertRecipe()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Insert recipe");
            recipe = recipe_List.recipes[0];
        }
    }
    private void GetRecipeInfo()
    {
        // if ther's a completeDish get it's Recipe_Info
        if (recipe_Info == null && recipe != null)
        {
            recipe_Info = recipe.GetComponent<Recipe_Info>();

            foreach(Ingredient_Info ingredient in recipe_Info.ingredients)
            {
                ingredients_Clone.Add(ingredient);
                Debug.Log("Add");
            }
            Debug.Log("Get recipe info");
        }
    }
    private void ValidateIngredient()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // find ingredient in ingredients 
            foreach (Ingredient_Info ingredient in ingredients_Clone)
            {
                if (this.ingredient.id == ingredient.id)
                {
                    // create a second list whit correct ingredients
                    validateIngredients.Add(this.ingredient);
                    ingredients_Clone.Remove(this.ingredient);
                    Debug.Log("The ingredient is correct");
                    ValidateRecipe();
                    return;
                }                   
            }
            // find ingredient in validateIngredients 
            foreach (Ingredient_Info ingredient in validateIngredients)
            {
                if (this.ingredient.id == ingredient.id)
                {
                    Debug.Log("You have already insert this ingredient");
                    return;
                }
            }
            Debug.Log("The ingredient is incorrect");
        }
    }

    // you have to validate the specific ingredient, pop off the verified ones
    private void ValidateRecipe()
    {
        // create complete dish when all ingredients have been validated
        if (ingredients_Clone == null)
        {
            // set complete dish father's son
            Instantiate(recipe, spawnPoint.position, Quaternion.identity);
            Debug.Log("Complete dish creation");
        }
    }
}
