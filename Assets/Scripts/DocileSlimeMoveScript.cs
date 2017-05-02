using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocileSlimeMoveScript : MonoBehaviour {
    private Vector3 dir;

    void Start()
    {
        dir = Vector3.down * 12;
    }
    
	void Update () {
        transform.Translate(dir * Time.deltaTime);
        if (transform.position.y <= -15)
        {
            float randx = Random.Range((-1f) * (2.7f / 4.7f) * (ScreenManager.width / 2f), (2.7f / 4.7f) * (ScreenManager.width / 2f));
            float randy = Random.Range((17 / 6.5f) * (ScreenManager.height / 2f), (21 / 6.5f) * (ScreenManager.height / 2f));
            transform.position = new Vector3(randx, randy, transform.position.z);
        }
	}
}
