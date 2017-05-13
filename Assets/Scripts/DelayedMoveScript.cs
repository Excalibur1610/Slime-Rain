using UnityEngine;

public class DelayedMoveScript : MonoBehaviour
{
    public Vector3 Direction;
    private int count;
    public int minCount;

    // Use this for initialization
    void Start () {
        count = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (count >= minCount)
            transform.Translate(Direction * Time.deltaTime);
        count++;
    }
}
