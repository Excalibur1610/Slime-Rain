using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Script : MonoBehaviour {
    public GameObject target;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        //var targetObject = GameObject.Find(target);
        //transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, step);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
