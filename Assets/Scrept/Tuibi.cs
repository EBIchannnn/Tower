using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuibi : MonoBehaviour
{
    public string targetObjectID;
    private EnemyStart enemyStart;
    private void Start()
    {
        enemyStart = FindObjectOfType<EnemyStart>();
    }
    void Update()
    {
        UpdateTargetObject();
    }
    private void UpdateTargetObject()
    {//大砲の向きを変える処理
        if (string.IsNullOrEmpty(targetObjectID))
        {
            return;
        }
        GameObject gameObject = enemyStart.objectDictionary[targetObjectID];//標的のobjectをdictionaryから取得
        Vector3 objectPosition = gameObject.transform.position;//objectの位置情報を取得
        Vector3 direction = objectPosition - transform.position;//大砲の位置との差を求める
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);//Enemyの方を向く
    }
    public void SetTargetObject(string objectID)
    {//標的にしたいEnemyの名前を取得
        targetObjectID = objectID;
    }
}
