using UnityEngine;
using UnityEngine.SceneManagement;

public class DoClick2 : MonoBehaviour {
    public string actionName;
    public static bool submitted;

    public void Start()
    {
        submitted = false;
    }

	public void OnClick()
    {
        if (actionName.CompareTo("Play") == 0 || actionName.CompareTo("Again") == 0)
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
            submitted = true;
        }
        else if (actionName.CompareTo("Quit") == 0)
        {
            GameManager.score = 0;
            GameManager.endCounter = 0;
            SceneManager.LoadScene("MainScreen");
        }
    }
}
