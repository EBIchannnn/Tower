using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStart : MonoBehaviour
{
    public GameObject teki;
    Vector3 createPosition;
    public float timeOut;
    private float timeElapsed;
    public Dictionary<string, GameObject> objectDictionary;
    private int nextObjectID = 1;
    private int sentouID = 1;
    private string SentouID="Enemy_"+1.ToString();
    public int Go = 0;
    private Price price;
    public float speed = 1;
    private float HP=4;
    private int score=10;

    private void Start()
    {
        objectDictionary = new Dictionary<string, GameObject>();
        price = FindObjectOfType<Price>();
    }
    void Update()
    {
        createPosition = transform.position;//生成場所を登録
        timeElapsed += Time.deltaTime;//時間を計測
        if (timeElapsed >= timeOut&&Go==1)
        {//TimeOutの値時間経過したら実行
            GenereteObgect();
            timeElapsed = 0.0f;//時間をリセット
        }
    }

    private void GenereteObgect()
    {//Enemyを生成する
        GameObject newObject=Instantiate(teki, createPosition, transform.rotation);//生成処理
        Enemy enemy=newObject.GetComponent<Enemy>();
        string objectID="Enemy_"+nextObjectID.ToString();//名前を生成
        newObject.name = objectID;//名前を適用
        enemy.speed = speed;
        enemy.MaxHP = HP;
        objectDictionary.Add(objectID, newObject);//辞書に登録
        nextObjectID++;//次の名前
        if (objectID =="Enemy_1")
        {
            SetTargetObject();//最初に一度だけ呼び出す
        }//Debug.Log(sentouID);
    }
    public bool IsEnemyExists()
    {//取得したobjectIDがDictionryに存在した場合Trueを返す
        return objectDictionary.ContainsKey(SentouID);
    }
    public void SetTargetObject()
    {
        if(Go==1)
        {
            if (IsEnemyExists())
            {//IsEnemyExistsがTrueの場合の処理
                Tuibi[] tuibis = FindObjectsOfType<Tuibi>();//全ての大砲に処理を適用させる
                foreach (Tuibi tuibi in tuibis)
                {
                    tuibi.SetTargetObject(SentouID);
                }//SentouIDを引数として渡す
            }
            else
            {
                sentouID++;//先頭をずらす
                SentouID = "Enemy_" + sentouID.ToString();
                SetTargetObject();
            }
        }
    }
    public void RemoveObject(GameObject gameObject)
    {//削除処理
        Destroy(gameObject);//引数として渡されたEnemyを削除
        objectDictionary.Remove(gameObject.name);//辞書からも削除
        price.increasePrice(20);
        price.increaseScore(score);
        score += 1;
        speed += (float)0.08;
        HP += (float)0.1;
        if (gameObject.name == SentouID)
        {//壊れたEnemyが先頭かどうか
            sentouID++;//先頭を次にずらす
            SentouID = "Enemy_" + sentouID.ToString();
            SetTargetObject();
        }
    }
    public void start()
    {
        Go = 1;
        Time.timeScale = 1f;//ゲームを動かす
    }
}
