using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private GameObject hpBar;//HPバーを格納する変数
    [SerializeField] private Transform barPos;//HPバーの場所を格納する変数
    private Vector3 createposition;//HPバーを生成する場所を格納する変数
    private float MaxHP;//MaxHPを格納する変数
    private Enemy enemy;//Enemyを格納する変数
    public float imanoHP;//HPを格納する変数
    public GameObject newBar;//HPバーを格納する変数
    void Start()
    {
        CreateHealthBar();//関数を呼ぶ
        enemy = GetComponent<Enemy>();//Enemyの情報を取得
        MaxHP = enemy.MaxHP;//MaxHPを取得
    }

    private void CreateHealthBar()//HPBarを生成する関数
    {
        createposition=barPos.position;//アタッチされているEnemyの位置情報を取得
        createposition.y += 0.3f;//位置を調整
        newBar = Instantiate(hpBar, createposition, Quaternion.identity);//HPバーを生成
        newBar.transform.SetParent(transform);//HPBarをEnemyの子オブジェクトに設定
    }
    public void reduceHP(Image image)//HPBarを減らす関数
    {
        imanoHP = enemy.hp;//HPを取得
        image.fillAmount = Mathf.Lerp(image.fillAmount, imanoHP/MaxHP, Time.deltaTime*40f);//imageの表示割合を変える
    }
}
