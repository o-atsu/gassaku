using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liner : MonoBehaviour {
    public float time = 2.0f;//横移動のスピード調整
    private float starttime=0.0f;
    private Vector2 vsrc;
    public Vector2 vtar;
    // Use this for initialization
    void Start () {
        if (time <= 0)
        {
            transform.position = vtar;
            enabled = false;
            return;
        }
        starttime = Time.timeSinceLevelLoad;
        vsrc = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        var diff = Time.timeSinceLevelLoad - starttime;
        if (diff > time)
        {
            transform.position = vtar;
            enabled = false;
        }

        transform.position = Vector2.Lerp(vsrc, vtar, diff / time);
    }
}
