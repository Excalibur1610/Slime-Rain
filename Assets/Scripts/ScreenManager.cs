using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour{
    private static int scene;
    public int scen;
    private int counter;
    //public GameObject playButton;
    //public GameObject scoresButton;
    //public GameObject exitButton;
    public GameObject greenSlime;
    public GameObject orangeSlime;
    public GameObject redSlime;
    public Transform parent;
    public GameObject bullet;
    public GameObject againButton;
    public GameObject quitButton;
    public GameObject submitButton;
    public GameObject nameTextBox;
    public GameObject docileSlime1;
    public GameObject docileSlime2;
    public GameObject docileSlime3;
    public Text[] rNames;
    public Text[] rScores;
    private bool play;
    public static float height;
    public static float width;
    public static ScoreReaderWriter scoretrack;
    public static string pName;
    public static int gameStage;

    void Start()
    {
        pName = "";
        scene = scen;
        counter = 0;
        play = true;
        if (scene == 1)
        {
            Screen.SetResolution(800, 600, true);
        }
        if (scene == 0 || scene == 2)
        {
            Screen.SetResolution(600, 400, false);
        }
        if (scene == 1 || scene == 2)
        {
            scoretrack = new ScoreReaderWriter();
        }
        height = Camera.main.orthographicSize * 2f;
        width = height * Screen.width / Screen.height;
        if (scene == 2)
        {
            string[] topNames = scoretrack.getNames();
            float[] topScores = scoretrack.getScores();
            for (int i = 0; i < 10; i++)
            {
                rNames[i].text = topNames[i];
                rScores[i].text = "" + topScores[i];
            }
        }
        gameStage = 0;
    }

    void Update()
    {
        if (play)
        {
            switch (scene)
            {
                case 0:
                    if (counter >= 800 && (counter - 800) < 420 && (counter - 800) % 20 == 0)
                    {
                        float rand = Random.Range(1, 75);
                        float randx = Random.Range((-1f) * (2.7f / 4.7f) * (width / 2f), (2.7f / 4.7f) * (width / 2f));
                        float randy = Random.Range((17 / 6.5f) * (height / 2f), (21 / 6.5f) * (height / 2f));
                        if (rand <= 25)
                        {
                            Spawner.Spawn(docileSlime1, new Vector2(randx, randy));
                        }
                        else if (rand <= 50)
                        {
                            Spawner.Spawn(docileSlime2, new Vector2(randx, randy));
                        }
                        else
                        {
                            Spawner.Spawn(docileSlime3, new Vector2(randx, randy));
                        }

                    }
                    if (counter >= 100000000)
                    {
                        var docileSlimes = GameObject.FindGameObjectsWithTag("dSlime");
                        foreach (GameObject d in docileSlimes)
                        {
                            Destroy(d);
                        }
                        counter = 0;
                    }
                    else
                        counter++;
                    //if (counter == 980)
                    //{
                    //    Spawner.Spawn(playButton, parent);
                    //}
                    //else if (counter == 1000)
                    //{
                    //    Spawner.Spawn(scoresButton, parent);
                    //}
                    //else if (counter == 1020)
                    //{
                    //    Spawner.Spawn(exitButton, parent);
                    //}
                    break;
                case 1:
                    if (GameManager.CheckGame())
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            Vector3 pos = Input.mousePosition;
                            pos = new Vector3((4.5f * ((pos.x / Screen.width) - .5f) * 1.9f), (6.5f * ((pos.y / Screen.height) - .5f) + 3.5f), -2.5f);
                            Spawner.Spawn(bullet, pos, true);
                        }
                        if (counter >= 500)
                        {
                            counter = 0;
                        }
                        if (counter <= Mathf.Pow(GameManager.score, (Mathf.PI / counter)))
                        {
                            float rand = Random.Range(GameManager.score * .01f, GameManager.score * 10);
                            float randx = Random.Range((-1f) * (2.7f / 4.7f) * (width / 2f), (2.7f / 4.7f) * (width / 2f));
                            float randy = Random.Range((17 / 6.5f) * (height / 2f), (21 / 6.5f) * (height / 2f));
                            if (rand < 500)
                            {
                                Spawner.Spawn(greenSlime, new Vector2(randx, randy));
                            }
                            else if (rand < 12500)
                            {
                                Spawner.Spawn(orangeSlime, new Vector2(randx, randy));
                            }
                            else
                            {
                                Spawner.Spawn(redSlime, new Vector2(randx, randy));
                            }
                        }
                        counter++;
                    }
                    else
                    {
                        if (gameStage == 1)
                        {
                            Spawner.Spawn(nameTextBox, parent);
                            Spawner.Spawn(submitButton, parent);
                            gameStage = 2;
                        }
                        else if (gameStage == 3)
                        {
                            var buttons = GameObject.FindGameObjectsWithTag("submission");
                            foreach (GameObject b in buttons)
                            {
                                    Destroy(b);
                            }
                            scoretrack.addScore(pName, GameManager.score);
                            gameStage = 4;
                        }
                        else if (gameStage == 4)
                        {
                            Spawner.Spawn(againButton, parent);
                            Spawner.Spawn(quitButton, parent);
                            gameStage = 5;
                        }
                    }
                    break;
                case 2:
                    if (counter < 420 && counter % 20 == 0)
                    {
                        float rand = Random.Range(1, 75);
                        float randx = Random.Range((-1f) * (2.7f / 4.7f) * (width / 2f), (2.7f / 4.7f) * (width / 2f));
                        float randy = Random.Range((17 / 6.5f) * (height / 2f), (21 / 6.5f) * (height / 2f));
                        if (rand <= 25)
                        {
                            Spawner.Spawn(docileSlime1, new Vector2(randx, randy));
                        }
                        else if (rand <= 50)
                        {
                            Spawner.Spawn(docileSlime2, new Vector2(randx, randy));
                        }
                        else
                        {
                            Spawner.Spawn(docileSlime3, new Vector2(randx, randy));
                        }

                    }
                    if (counter >= 100000000)
                    {
                        var docileSlimes = GameObject.FindGameObjectsWithTag("dSlime");
                        foreach (GameObject d in docileSlimes)
                        {
                            Destroy(d);
                        }
                        counter = 0;
                    }
                    else
                        counter++;
                    break;
                case -1:
                    counter = 0;
                    play = false;
                    break;
            }
        }
        else
            Application.Quit();
    }

    public static void Exit()
    {
        scene = -1;
    }
}
