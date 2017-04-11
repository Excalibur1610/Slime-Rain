using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour {
    public Vector3 Direction;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Direction * Time.deltaTime);
	}
}
