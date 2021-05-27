using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReceiptController : MonoBehaviour
{
    static List<string> recipes = new List<string>();
    public GameObject recipe_1;
    public GameObject recipe_2;
    public GameObject recipe_3;
    public GameObject recipe_4;
    public GameObject recipe_5;
    public GameObject recipe_6;
    public GameObject recipe_7;



    static public int scene_actual = -1;
    static private int scene_anterior = 0;




    public static List<string> get_recipes()
    {
        return recipes;
    }

    public static void set_recipes(List<string> rece)
    {
        recipes = rece;
    }

    void Start()
    {
        GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6 };
        for (int i = 0; i < 20; ++i)
        {
            recipes.Add("Paella");
        }
    }

    public static int change_scene(int i)
    {
            return scene_actual = i;
        
        
    }




    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        // GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6, recipe_7 };
        // Debug.Log(scene_actual);
        if (scene_actual == 1 && scene_actual != scene_anterior)
        {

            //layout.gameObject.SetActive(true);
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (scene_actual == 2 && scene_actual != scene_anterior)
        {
            //Debug.Log("2n level");
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (scene_actual == 3 && scene_actual != scene_anterior)
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_5, recipe_6 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (scene_actual == 4 && scene_actual != scene_anterior)
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_7 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (scene_actual == 5 && scene_actual != scene_anterior)
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        scene_anterior = scene_actual;
    }
}
