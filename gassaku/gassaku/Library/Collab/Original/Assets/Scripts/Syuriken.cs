using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syuriken : MonoBehaviour {

    public GameObject enemy;
    Rigidbody2D rb2d;
    private int isright = 1;

    IEnumerator Threw()
    {
        rb2d.AddForce(Vector2.right * isright * 24.0f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void OnEnable () {
        if (this.transform.parent.position.x > enemy.gameObject.transform.position.x) isright = -1;
        else isright = 1;
        this.transform.localPosition = new Vector2(isright * 5.5f, 0);
        StartCoroutine("Threw");
	}
	

}
