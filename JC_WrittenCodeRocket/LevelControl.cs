using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    // Based on script: https://youtu.be/26d1uZ7yrfY?t=61
    // Edits done on the script.

    public string leScene;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Loading level with build index
            SceneManager.LoadScene(leScene);

            //Loading level with scene name
            //SceneManager.LoadScene("Level2");

            //Restart lvl
            //SceneManagar.LoadScene(SceneManager)
        }
    }
}
