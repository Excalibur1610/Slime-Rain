using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSplashScript : MonoBehaviour {
    private int count;
    public int switchCheck;
    public Scene next;

	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= switchCheck)
            SceneManager.LoadScene(next.name);
        count++;
    }
}
