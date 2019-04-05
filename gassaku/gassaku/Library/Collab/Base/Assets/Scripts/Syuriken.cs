using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syuriken : MonoBehaviour {

    public GameObject enemy;
    Rigidbody2D rb2d;
    private int isright = 1;

    IEnumerator Threw()
    {
        if (this.transform.position.x > enemy.gameObject.transform.position.x) isright = -1;
        else isright = 1;
        rb2d.AddForce();
        yield return new WaitForSeconds(4.0f);
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        StartCoroutine("Threw");

	}
	

}
