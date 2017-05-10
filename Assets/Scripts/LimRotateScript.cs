using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimRotateScript : MonoBehaviour {
    public Vector3 axis;
    public float speed;
    public GameObject target;
    private bool stop;

    void Start()
    {
        stop = false;
    }
    
    void Update()
    {
        if (transform.position.Equals(target.transform.position) && !stop)
        {
            stop = true;
        }
        if (!(stop && transform.rotation.Equals(Quaternion.identity)))
        {
            transform.RotateAround(transform.position, axis, speed * Time.deltaTime);
        }
        if (stop && Quaternion.Dot(transform.rotation, Quaternion.identity) >= 0.9999f)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
