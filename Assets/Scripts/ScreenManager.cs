using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour{
    private static int scene;
    public int scen;
    private int counter;
    public Object slimeButton1;
    public Object slimeButton3;
    public Object slimeButton2;
    public Object target1;
    public Object target2;
    public Object target3;
    public GameObject playButton;
    public GameObject scoresButton;
    public GameObject exitButton;
    public GameObject greenSlime;
    public GameObject orangeSlime;
    public GameObject redSlime;
    public Transform parent;
    public GameObject bullet;
    public GameObject againButton;
    public GameObject quitButton;
    private bool play;
    private float height;
    private float width;
    private bool targetsSet;
    private float c1;
    private float c2;
    private float c3;
    private Vector3 start1;
    private Vector3 start2;
    private Vector3 start3;
    private Vector3 end1;
    private Vector3 end2;
    private Vector3 end3;
    private static bool submit, spawnSubUI;

    void Start()
    {
        scene = scen;
        counter = 0;
        play = true;
        targetsSet = false;
        if (scene == 1)
        {
            Screen.SetResolution(800, 600, true);
            submit = false;
            spawnSubUI = false;
        }
        if (scene == 0 || scene == 2)
        {
            Screen.SetResolution(600, 400, false);
        }
        height = Camera.main.orthographicSize * 2f;
        width = height * Screen.width / Screen.height;
        if (scene == 0)
        {
            float d1, d2, d3;
            start1 = new Vector3((-1f) * (2f / 4.5f) * (width / 2f), (3.7f / 6.5f) * (height / 2f), -2);
            start2 = new Vector3((2f / 4.5f) * (width / 2f), (2.7f / 6.5f) * (height / 2f), -3);
            start3 = new Vector3(0, (1f / 6.5f) * (height / 2f), -2.5f);
            end1 = new Vector3((-6 / 4.5f) * (width / 2f), (17 / 6.5f) * (height / 2f), -2);
            end2 = new Vector3((-5 / 4.5f) * (width / 2f), (19 / 6.5f) * (height / 2f), -2.5f);
            end3 = new Vector3((-4 / 4.5f) * (width / 2f), (21 / 6.5f) * (height / 2f), -3);
            d1 = Vector3.Magnitude(start1 - end1);
            d2 = Vector3.Magnitude(start2 - end2);
            d3 = Vector3.Magnitude(start3 - end3);
            c1 = d1 / (4 * Time.deltaTime);
            c2 = d2 / (4 * Time.deltaTime);
            c3 = d3 / (3.5f * Time.deltaTime);
            Debug.Log("start1: " + start1);
            Debug.Log("start2: " + start2);
            Debug.Log("start3: " + start3);
            Debug.Log("end1: " + end1);
            Debug.Log("end2: " + end2);
            Debug.Log("end3: " + end3);
            Debug.Log("count1: " + c1);
            Debug.Log("count2: " + c2);
            Debug.Log("count3: " + c3);
        }
    }

    void Update()
    {
        if (play)
        {
            switch (scene)
            {
                case 0:
                    if (!targetsSet)
                    {
                        Spawner.Spawn(target1, start1);
                        Spawner.Spawn(target2, start2);
                        Spawner.Spawn(target3, start3);
                        targetsSet = true;
                    }
                    if (counter == -1)
                    {
                        Destroy(target1);
                        Destroy(target2);
                        Destroy(target3);
                        Destroy(slimeButton1);
                        Destroy(slimeButton2);
                        Destroy(slimeButton3);
                        Destroy(playButton);
                        Destroy(scoresButton);
                        Destroy(exitButton);
                        targetsSet = false;
                        counter = 0;
                        SceneManager.LoadScene("MainScreen");
                    }
                    else if (counter == 860)
                    {
                        Spawner.Spawn(slimeButton1, end1);
                        Spawner.Spawn(slimeButton3, end3);
                        Spawner.Spawn(slimeButton2, end2);
                    }
                    else if (counter == 900 + (int)c1)
                    {
                        Spawner.Spawn(playButton, parent);
                    }
                    else if (counter == 890 + (int) c2)
                    {
                        Spawner.Spawn(scoresButton, parent);
                    }
                    else if (counter == 910 + (int) c3)
                    {
                        Spawner.Spawn(exitButton, parent);
                    }
                    else if (counter == 1000000000)
                    {
                        counter = -2;
                    }
                    counter++;
                    break;
                case 1:
                    if (GameManager.CheckGame())
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            Vector3 pos = Input.mousePosition;
                            pos = new Vector3((4.5f * ((pos.x / Screen.width) - .5f) * 1.9f), (6.5f * ((pos.y / Screen.height) - .5f) + 3.12f), -10);
                            Spawner.Spawn(bullet, new Vector2(pos.x, pos.y));
                            //Debug.Log("Bullet @ " + GameObject.FindGameObjectWithTag("bullet").transform.position);
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
                        counter = -1;
                        if (counter < 0)
                        {
                            Spawner.Spawn(againButton, parent);
                            Spawner.Spawn(quitButton, parent);
                            counter = 0;
                        }
                    }
                    break;
                case 2:
                    counter = 0;
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
