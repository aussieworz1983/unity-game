using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartManager : MonoBehaviour
{
    public Canvas canvas;
   
    // Start is called before the first frame update
    void Start()
    {
        OptionsUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKey("q"))
        {
            Application.Quit();
        }
        if (Input.GetKey("o"))
        {
            GameOptions();
        }
    }
    public void GameOptions() {
        OptionsUI(true);
    }
    public void OptionsUI(bool options) {
        if (options == true)
        {
            canvas.gameObject.SetActiveRecursively(true);
        }
        else if (options == false)
        {
            foreach (Text tx in canvas.GetComponentsInChildren<Text>())
            {
                if (tx.name == "DifficultyOption" || tx.name == "DifficultyOption (1)" || tx.name == "DifficultyOption (2)" || tx.name == "DifficultyOption (3)" || tx.name == "Cheats" || tx.name == "Cheats (1)")
                {

                    tx.gameObject.SetActive(false);
                }
            }

        }
    }
}
