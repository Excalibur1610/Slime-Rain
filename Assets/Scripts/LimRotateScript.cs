using UnityEngine;
using UnityEngine.SceneManagement;

public class LimRotateScript : MonoBehaviour {
    public Vector3 axis;
    public float speed;
    public GameObject target;
    private bool stop;
    private int count;

    void Start()
    {
        stop = false;
        count = 0;
    }
    
    void Update()
    {
        if ((Vector3.Dot(transform.position, target.transform.position) >= .6f * Vector3.SqrMagnitude(target.transform.position)) && !stop)
        {
            stop = true;
        }
        if (!(stop && transform.rotation.Equals(Quaternion.identity)))
        {
            transform.RotateAround(transform.position, axis, speed * Time.deltaTime);
        }
        if (stop && Quaternion.Dot(transform.rotation, Quaternion.identity) >= 0.995f)
        {
            transform.rotation = Quaternion.identity;
        }
        if (count >= 725)
        {
            SceneManager.LoadScene("MainScreen");
        }
        count++;
    }
}
