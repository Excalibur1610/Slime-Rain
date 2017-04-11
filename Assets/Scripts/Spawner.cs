using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static void Spawn(Object thing, Vector3 pos)
    {
        Instantiate(thing, pos, Quaternion.identity);
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
