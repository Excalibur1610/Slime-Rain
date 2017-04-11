using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour {
    public Material initial, final;
    public Renderer ob;
	
	// Update is called once per frame
	void Update () {
        float t = GameManager.endCounter / 500f;
        ob.material.Lerp(initial, final, t);
	}
}
