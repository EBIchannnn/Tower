using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    public GameObject tama;//’e‚ğŠi”[‚·‚é•Ï”
    public GameObject teki;//“G‚ğŠi”[‚·‚é•Ï”
    public float timeOut;//¶¬ŠÔŠu‚ğŠi”[‚·‚é•Ï”
    private float timeElapsed;//Œo‰ßŠÔ‚ğŠi”[‚·‚é•Ï”
    private EnemyStart enemyStart;//EnemyStart‚ğŠi”[‚·‚é•Ï”

    void Update()
    {
        enemyStart = FindObjectOfType<EnemyStart>();//EnemyStart‚Ìî•ñ‚ğæ“¾
        if (enemyStart.Go == 1)//ƒXƒ^[ƒgƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚çÀs
        {
            timeElapsed += Time.deltaTime;//Œo‰ßŠÔ‚ğ‘ª’è
            if (timeElapsed >= timeOut)//Œo‰ßŠÔ‚ªtimeOut‚É’B‚µ‚½‚çÀs
            {
                GameObject gameObject = Instantiate(tama, transform.position, transform.rotation);//’e‚ğ¶¬
                TaihouController taihouController = GetComponent<TaihouController>();//taihouController‚Ìî•ñ‚ğæ“¾
                Idou idou = gameObject.GetComponent<Idou>();//Idou‚Ìî•ñ‚ğæ“¾
                idou.damage = taihouController.dmg;//ƒ_ƒ[ƒWî•ñ‚ğIdou‚É“`‚¦‚é
                timeElapsed = 0.0f;//Œo‰ßŠÔƒŠƒZƒbƒg
            }
        }
    }
}
