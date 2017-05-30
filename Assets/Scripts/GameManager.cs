using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static float score;
    public static int endCounter;
    //private int highScore;
    private const int END_GAME = 200;
    public Text scoreText;
    private static bool stageAdvanced;

	// Use this for initialization
	void Start () {
        score = 0;
        endCounter = 0;
        stageAdvanced = false;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + score;
        if (!CheckGame())
        {
            scoreText.text += "  GAME OVER";
            var slime = GameObject.FindGameObjectsWithTag("slime");
            foreach (GameObject s in slime)
            {
                Destroy(s);
            }
        }
	}

    public static bool CheckGame()
    {
        if (endCounter >= END_GAME)
        {
            if (!stageAdvanced)
            {
                if (ScreenManager.scoretrack.HighScore(GameManager.score))
                {
                    ScreenManager.gameStage = 1;
                }
                else
                {
                    ScreenManager.gameStage = 3;
                }
                stageAdvanced = true;
            }
            return false;
        }
        return true;
    }
}
