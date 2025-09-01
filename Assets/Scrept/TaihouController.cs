using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouController : MonoBehaviour
{
    private Vector3 touchStartPos;//クリックした場所を格納するベクトル
    private Vector3 taihouStartPos;//大砲の位置を格納するベクトル
    public float sensitivity = 1f;//大砲の移動フレームを格納する変数
    private TaihouStart taihouStart = FindObjectOfType<TaihouStart>();
    private TaihouStart2 taihouStart2;//TaihouStart2を格納する変数
    private GameObject taihouObject;//大砲を格納する変数
    private EnemyStart enemyStart;//Enemyを格納する変数
    public int dmg;
    private void Start()
    {
        taihouStart=FindObjectOfType<TaihouStart>();//TaihouStartの情報を取得
        enemyStart = FindObjectOfType<EnemyStart>();//EnemtStartの情報を取得
        taihouStart2=FindObjectOfType<TaihouStart2>();//TaihouStart2の情報を取得
    }
    public void createTaihou()
    {
        if (Input.GetMouseButtonDown(0))//左クリックされたら
        {
            taihouStart.createTaihou();
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//クリックした場所を取得
            taihouStartPos = transform.position;//大砲の場所を取得
        }
        else if (Input.GetMouseButton(0))//左クリックを長押しされたら
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得
            Vector3 moveAmount = currentPos - touchStartPos;//大砲の位置との差を計算
            taihouObject.transform.position = taihouStartPos + moveAmount * sensitivity;//大砲の位置をマウスに合わせて移動
        }

    }
}
