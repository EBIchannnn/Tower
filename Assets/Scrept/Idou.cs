using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idou : MonoBehaviour
{
    public float speed;//’e‚ÌƒXƒs[ƒh‚ğŠi”[‚·‚é•Ï”
    public int damage;//’e‚Ìƒ_ƒ[ƒW‚ğŠi”[‚·‚é•Ï”
    private EnemyStart enemyStart;//EnemyStart‚ğŠi”[‚·‚é•Ï”
    public GameObject Helthbar;//‘Ì—Íƒo[‚ğŠi”[‚·‚é•Ï”
    private void Start()
    {
        enemyStart = FindObjectOfType<EnemyStart>();//EnemyStart‚Ìî•ñ‚ğæ“¾
    }
    void Update()
    {//’e‚ªˆÚ“®‚·‚é
        transform.Translate(speed * Time.deltaTime * Vector3.up);//’e‚ğˆÚ“®‚³‚¹‚é
        if (transform.position.y > 5.5 || transform.position.y < -3.5 || transform.position.x > 3.5 || transform.position.x < -3.5)//’e‚ª‰æ–ÊŠO‚És‚Á‚½‚çÀs
        {
            Destroy(gameObject);//’e‚ğíœ
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//’e‚ª‰½‚©‚É“–‚½‚Á‚½‚çÀs
    {
        if (collision.tag == "Enemy")//“–‚½‚Á‚½‚à‚Ì‚ªEnemy‚¾‚Á‚½‚çÀs
        {
            Enemy enemy = collision.GetComponent<Enemy>();//“–‚½‚Á‚½Enemy‚Ìî•ñ‚ğæ“¾
            EnemyHP enemyHP = collision.GetComponent<EnemyHP>();//“–‚½‚Á‚½EnemyHP‚Ìî•ñ‚ğæ“¾
            EnemyHPBar enemyHPBar = enemyHP.newBar.GetComponent<EnemyHPBar>();//“–‚½‚Á‚½EnemyHP‚Åì‚ç‚ê‚½EnemyHPBar‚Ìî•ñ‚ğæ“¾
            enemy.hp -= damage;//hp‚ğŒ¸‚ç‚·
            enemyHP.reduceHP(enemyHPBar.hpBarImage);//HPBAR‚ğŒ¸‚ç‚·
            if (enemy.hp <= 0)//hp‚ª0‚É‚È‚Á‚½‚çÀs
            {
                enemyStart.RemoveObject(collision.gameObject);//“–‚½‚Á‚½“G‚ğíœ
            }
            Destroy(gameObject);//’e‚ğíœ
        }
    }
}
