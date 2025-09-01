using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;//hp‚ğŠi”[‚·‚é•Ï”
    public float MaxHP=4;//maxhp‚ğŠi”[‚·‚é•Ï”
    public float speed=1;//ƒXƒs[ƒh‚ğŠi”[‚·‚é•Ï”
    private Vector3 up= Vector3.up;//ˆÚ“®•ûŒü‚ğŠi”[‚·‚éƒxƒNƒgƒ‹
    private Vector3 down= Vector3.down;//"
    private Vector3 right= Vector3.right;//"
    //private EnemyStart enemyStart;//EnemyStart‚ğŠi”[‚·‚é•Ï”
    private GameOver gameOver;//gameover‚ğŠi”[‚·‚é•Ï”
    public Boolean onof=false;
    private void Start()
    {
        //enemyStart = FindObjectOfType<EnemyStart>();//enemyStart‚Ìî•ñ‚ğæ“¾
        gameOver = FindObjectOfType<GameOver>();//gameover‚Ìî•ñ‚ğæ“¾
        hp = MaxHP;//hp‚Émaxhp‚ğŠi”[
    }
    void Update()
    {//“G‚ğˆÚ“®‚³‚¹‚éˆ—
        tekinoidou();
    }
    void tekinoidou()//“G‚ÌˆÚ“®‚ğŠÇ—‚·‚éŠÖ”
    {//À•W‚©‚çƒ‹[ƒg‚ğŒvZ
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
        if (transform.position.y >= 6)//“G‚ÌyÀ•W‚ª6‚ğ’´‚¦‚½‚çÀs
        {
            //enemyStart.RemoveObject(gameObject);//“G‚ğíœ
            gameOver.gameover();//ƒQ[ƒ€ƒI[ƒo[‚É‚·‚é
        }
    }
}
