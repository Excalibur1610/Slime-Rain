using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private Vector3 target;
    public float speed;

    void Start()
    {
        float dist = 600;
        int index = 0;
        int targetI = 0;
        var slimes = GameObject.FindGameObjectsWithTag("slime");
        if (slimes.GetLength(0) > 0)
        {
            foreach (GameObject s in slimes)
            {
                if (Vector3.Magnitude((s.transform.position-transform.position)) < dist)
                {
                    targetI = index;
                }
                index++;
            }
            GameObject tar = (GameObject) slimes.GetValue(targetI);
            target = tar.transform.position;
        }
        else
        {
            target = new Vector3(transform.position.x, transform.position.y, 100);
        }
        //Debug.Log("Target: " + target);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
