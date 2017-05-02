using UnityEngine;

public class DocileSlimeMoveScript : MonoBehaviour {
    private Vector3 dir;

    void Start()
    {
        dir = Vector3.down * 1.2f;
    }
    
    void Update () {
        transform.Translate(dir * Time.deltaTime);
        if (transform.position.y <= -1.5)
        {
            float randx = Random.Range((-1f) * (2.7f / 4.7f) * (ScreenManager.width / 2f), (2.7f / 4.7f) * (ScreenManager.width / 2f));
            float randy = Random.Range((15 / 6.5f) * (ScreenManager.height / 2f), (19 / 6.5f) * (ScreenManager.height / 2f));
            transform.position = new Vector3(randx, randy, transform.position.z);
        }
    }
}