using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReceiptController : MonoBehaviour
{
    List<string> recipes = new List<string>();
    public GameObject recipe_1;
    public GameObject recipe_2;
    public GameObject recipe_3;
    public GameObject recipe_4;
    public GameObject recipe_5;
    public GameObject recipe_6;
    public GameObject recipe_7;
    void Start()
    {
       // GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6, recipe_7 };
        if (SceneManager.GetActiveScene().name == "1_nivell") 
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2 };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }
           
        }

        else if (SceneManager.GetActiveScene().name == "2_nivell")
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "3_nivell")
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_5, recipe_6, };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "4_nivell")
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_7 };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "5_nivell")
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6 };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

    }

 
    void Update()
    {
        
    }
}
