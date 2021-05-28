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
    public GameObject layout;
    public AudioSource song;




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

        if (SceneManager.GetActiveScene().name == "1_nivell")
        {
            song.mute = false;
            layout.gameObject.SetActive(true);
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "2_nivell")
        {
            song.mute = false;
            layout.gameObject.SetActive(true); ;
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "3_nivell")
        {
            song.mute = false;
            layout.gameObject.SetActive(true);
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_5, recipe_6 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "4_nivell")
        {
            song.mute = false;
            layout.gameObject.SetActive(true);
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_7 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else if (SceneManager.GetActiveScene().name == "5_nivell")
        {
            song.mute = false;
            layout.gameObject.SetActive(true);
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6 };
            recipes.Clear();
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add(recipe[Random.Range(0, recipe.Length)].name);
            }

        }

        else
        {
            GameObject[] recipe = new GameObject[] { recipe_1, recipe_2, recipe_3, recipe_4, recipe_5, recipe_6 };
            for (int i = 0; i < 20; ++i)
            {
                recipes.Add("Paella");
            }
        }
    }





    void Update()
    {
    }
}
