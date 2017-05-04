using UnityEngine;

public class RotateScript : MonoBehaviour {
    public Vector3 axis, point;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(point, axis, speed * Time.deltaTime);
	}
}
