using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Recipe_Info : MonoBehaviour
{
    public Nationality nationality;
    public List<Ingredient_Info> ingredients = new List<Ingredient_Info>();
}
public enum Nationality
{
    English,
    Spanish,
    Italian
}

