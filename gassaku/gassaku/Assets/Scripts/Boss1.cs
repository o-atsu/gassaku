using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    public float acceleration = 0.4f;//横移動のスピード調整
    public float attackspeed = 3.0f;//攻撃スピード調整
    public BossScene1 bossscene;
    public GameObject ninja;
    Rigidbody2D rb2d;
    private int toright = 1;

    IEnumerator Attack()
    {
        if (bossscene.win) yield break;
        yield return new WaitForSeconds(Random.value * 3.0f);
        rb2d.AddForce((this.transform.position - ninja.transform.position) * attackspeed);
        yield return StartCoroutine("Attack");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (bossscene.lose == true) return;
        bossscene.win = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")//地面につく
        {
            return;
        }
        Vector2 dir = this.transform.position - collision.transform.position;
        rb2d.AddForce(dir * 6.0f, ForceMode2D.Impulse);//当たると吹っ飛ぶ
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("Attack");
    }
    private void Update()
    {
        if (bossscene.win)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            return;
        }

        if (ninja.transform.position.x > this.transform.position.x)
        {
            toright = 1;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            toright = -1;
        }
        rb2d.AddForce(Vector2.right * acceleration * toright, ForceMode2D.Impulse);

        
    }
}
