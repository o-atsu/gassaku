using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    public float speed = 2.0f;//横移動のスピード調整
    public float JampVel = 20.0f;//飛ぶ初期速度
    private int Jamptime = 0;//とんだ回数
    public float beat = 3.0f;
    Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たった");
        Jamptime = 0;//ジャンプ更新するかどうか
        Vector2 dir = this.transform.position - collision.transform.position;
        rb2d.AddForce(dir * beat, ForceMode2D.Impulse);//当たると吹っ飛ぶ
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(Vector2.right * speed * Input.GetAxisRaw("Horizontal"), ForceMode2D.Impulse);
        if (Input.GetKeyDown("up") && Jamptime <= 1)//二回までジャンプできる
        {
            rb2d.velocity = new Vector2(0,JampVel);
            this.Jamptime++;
        }
    }
}
