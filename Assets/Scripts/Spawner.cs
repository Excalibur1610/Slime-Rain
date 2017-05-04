using UnityEngine;

public class Spawner : MonoBehaviour {

    public static void Spawn(Object thing, Vector3 pos, bool bullet)
    {
        if (bullet)
        {
            Vector3 up = new Vector3();
            Vector3 forward = new Vector3();
            up.x = pos.y - 3;
            up.y = pos.x;
            up.z = 0;
            forward = pos - Camera.main.transform.position;
            forward.x *= 1.56f; //rescale fixes most of margin of error in pixels-world units
            forward.y *= 1.6f;  //rescale fixes most of margin of error in pixels-world units
            Instantiate(thing, Camera.main.transform.position, Quaternion.LookRotation(forward.normalized, up.normalized));
        }
        else
        {

            Instantiate(thing, pos, Quaternion.identity);
        }
    }

    public static void Spawn(Object thing, Transform parent)
    {
        Instantiate(thing, parent, false);
    }

    public static void Spawn(GameObject thing, Vector2 pos)
    {
        Instantiate(thing, new Vector3(pos.x, pos.y, thing.transform.position.z), thing.transform.rotation);
    }
}
