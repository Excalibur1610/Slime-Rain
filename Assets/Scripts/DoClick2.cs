using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoClick2 : MonoBehaviour {
    public string actionName;

	public void OnClick()
    {
        if (actionName.CompareTo("Play") == 0)
        {
            GameManager.score = 0;
            GameManager.endCounter = 0;
            SceneManager.LoadScene("GameScreen");
        }
        else if (actionName.CompareTo("Scores") == 0)
        {
            SceneManager.LoadScene("ScoresScreen");
        }
        else if (actionName.CompareTo("Exit") == 0)
        {
            ScreenManager.Exit();
        }
        else if (actionName.CompareTo("Submit") == 0)
        {

            var buttons = GameObject.FindGameObjectsWithTag("submission");
            foreach (GameObject b in buttons)
            {
                if (b != gameObject)
                {
                    Destroy(b);
                }
            }
            Destroy(gameObject);
        }
        else if (actionName.CompareTo("Quit") == 0)
        {
            GameManager.score = 0;
            GameManager.endCounter = 0;
            SceneManager.LoadScene("MainScreen");
        }
        else if (actionName.CompareTo("Again") == 0)
        {
            GameManager.score = 0;
            GameManager.endCounter = 0;
            var buttons = GameObject.FindGameObjectsWithTag("egb");
            foreach (GameObject b in buttons)
            {
                if (b != gameObject)
                {
                    Destroy(b);
                }
            }
            Destroy(gameObject);
        }
    }
}
