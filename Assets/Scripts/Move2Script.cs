using UnityEngine;

public class Move2Script : MonoBehaviour {
    public GameObject target;
    public float speed;
	
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
