using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed;

    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 tar = new Vector3();
        tar = transform.forward;
        tar *= 20;
        transform.position = Vector3.MoveTowards(transform.position, tar, step);
    }
}
