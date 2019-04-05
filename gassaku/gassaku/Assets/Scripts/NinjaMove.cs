using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour
{

    public float acceleration = 3.0f;//横移動のスピード調整
    public float maxspeed = 10.0f;//横移動のスピード調整
    public float JumpVel = 21.0f;//飛ぶ初期速度
    private int Jumptime = 0;//とんだ回数
    public int toright = 1;
    Rigidbody2D rb2d;
    public BossScene1 bossscene;
    public GameObject syuriken;
    public GameObject enemy;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")//地面についたらジャンプ回数初期化
        {
            Jumptime = 0;
        }
        else
        {
            Vector2 dir = this.transform.position - collision.transform.position;
            rb2d.AddForce(dir * 3.0f, ForceMode2D.Impulse);//当たると吹っ飛ぶ
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bossscene.win == true) return;
        bossscene.lose = true;
    }
    
    void Update()
    {
        if (bossscene.lose)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            return;
        }
        if(this.transform.position.x < enemy.gameObject.transform.position.x)
        {
            toright = 1;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            toright = -1;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(rb2d.velocity.magnitude < maxspeed) {
            rb2d.AddForce(Vector2.right * acceleration * Input.GetAxisRaw("Horizontal"), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("up") && Jumptime <= 1){
            //二回までジャンプできる
            Jumptime++;
            rb2d.velocity = new Vector2(0, JumpVel);
        }
        if (Input.GetKeyDown("down")) syuriken.gameObject.SetActive(true);
    }
}
