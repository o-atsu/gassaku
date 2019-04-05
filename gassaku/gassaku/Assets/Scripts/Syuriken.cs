using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syuriken : MonoBehaviour {

    public GameObject enemy;
    Rigidbody2D rb2d;
    public NinjaMove parent;

    IEnumerator Threw()
    {
        rb2d.AddForce(Vector2.right * parent.toright * 24.0f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable () {
        this.transform.localPosition = new Vector2(-5.5f, 0);
        StartCoroutine("Threw");
	}
	

}
