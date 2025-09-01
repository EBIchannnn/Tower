using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;//hpを格納する変数
    public float MaxHP=4;//maxhpを格納する変数
    public float speed=1;//スピードを格納する変数
    private Vector3 up= Vector3.up;//移動方向を格納するベクトル
    private Vector3 down= Vector3.down;//"
    private Vector3 right= Vector3.right;//"
    //private EnemyStart enemyStart;//EnemyStartを格納する変数
    private GameOver gameOver;//gameoverを格納する変数
    public Boolean onof=false;
    private void Start()
    {
        //enemyStart = FindObjectOfType<EnemyStart>();//enemyStartの情報を取得
        gameOver = FindObjectOfType<GameOver>();//gameoverの情報を取得
        hp = MaxHP;//hpにmaxhpを格納
    }
    void Update()
    {//敵を移動させる処理
        tekinoidou();
    }
    void tekinoidou()//敵の移動を管理する関数
    {//座標からルートを計算
        if (transform.position.y < 3.8 && transform.position.x <= -1.6)
        {
            transform.position += up * speed * Time.deltaTime;
        }
        else if (transform.position.y >= 3.8 && transform.position.x < 0)
        {
            transform.position += right * speed * Time.deltaTime;
        }
        else if (transform.position.x < 1.6 && transform.position.x >= 0 && transform.position.y > -2)
        {
            transform.position += down * speed * Time.deltaTime;
        }
        else if (transform.position.y <= -2 && transform.position.x < 1.6)
        {
            transform.position += right * speed * Time.deltaTime;
        }
        else if (transform.position.y < 6 && transform.position.x >= 1.6)
        {
            transform.position += up * speed * Time.deltaTime;
        }
        if (transform.position.y >= 6)//敵のy座標が6を超えたら実行
        {
            //enemyStart.RemoveObject(gameObject);//敵を削除
            gameOver.gameover();//ゲームオーバーにする
        }
    }
}
