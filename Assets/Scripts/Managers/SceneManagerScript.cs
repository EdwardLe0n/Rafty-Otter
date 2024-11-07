using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public static SceneManagerScript Instance;

    public void Awake()
    {

        // Makes sure there's only on instance of the manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Loads a scene depedent on the value passed in
    /*
     * 0 == main menu
     * 1 == settings
     * 2 == character customization
     * 3 == main game
     * 4 == credits
     */
    public void LoadScene(int val)
    {
        SceneManager.LoadScene(val);
    }

}
