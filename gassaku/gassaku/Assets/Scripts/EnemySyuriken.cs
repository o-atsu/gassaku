using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySyuriken : MonoBehaviour {

    //0.5f内で消す
    public GameObject enemy;
    Rigidbody2D rb2d;
    public Boss3 parent;

    IEnumerator Threw()
    {
        rb2d.AddForce(Vector2.right * parent.toright * 30.0f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.8f);
        this.gameObject.SetActive(false);
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        this.transform.localPosition = new Vector2(-3.0f, 0);
        StartCoroutine("Threw");
    }
}
