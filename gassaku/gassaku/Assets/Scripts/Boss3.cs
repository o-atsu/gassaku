using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour {

    public float speed;
    public float JumpHeight;
    private int pattern;
    public int toright;
    private int jumptime = 1;
    Vector2 dir;
    public GameObject player;
    public EnemySyuriken syuriken;
    Rigidbody2D rb2d;
    public BossScene1 bossscene;

    IEnumerator Pattern()
    {
        if (bossscene.win) yield break;
        pattern = Random.Range(0, 3);
        pattern %= 3;
       // Debug.Log(pattern);
        if(pattern == 0)//突撃
        {
            rb2d.AddForce(dir * speed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1.4f);
        }
        if(pattern == 1)//手裏剣投げすぐ突撃
        {
            syuriken.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            rb2d.AddForce(dir * speed, ForceMode2D.Impulse);
        }
        if(pattern == 2)//手裏剣3回投げる
        {
            for(int i = 0;i < 3;i++)
            {
                syuriken.gameObject.SetActive(true);
                yield return new WaitForSeconds(1.0f);
            }
        }
        yield return StartCoroutine("Pattern");
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
            jumptime = 0;
            return;
        }
        Vector2 dir = this.transform.position - collision.transform.position;
        rb2d.AddForce(dir * 3.0f, ForceMode2D.Impulse);//当たると吹っ飛ぶ
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("Pattern");
    }
    private void Update()
    {
        dir = player.transform.position - this.transform.position;
        if(player.gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.2f && jumptime == 0)//着地狩り目的ジャンプ
        {
            rb2d.AddForce(new Vector2(toright * 5.0f,JumpHeight), ForceMode2D.Impulse);
            jumptime = 1;
        }
        if (bossscene.win)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            return;
        }

        if (player.transform.position.x > this.transform.position.x) {
            toright = 1;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            toright = -1;
        }
    }
}
