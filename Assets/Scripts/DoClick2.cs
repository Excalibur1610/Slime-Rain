using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoClick2 : MonoBehaviour {
    public string actionName;
    public Text nameText;

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
            ScreenManager.gameStage = 3;
            ScreenManager.pName = nameText.text;
        }
        else if (actionName.CompareTo("Quit") == 0)
        {
            GameManager.score = 0;
            GameManager.endCounter = 0;
            SceneManager.LoadScene("MainScreen");
        }
    }
}
