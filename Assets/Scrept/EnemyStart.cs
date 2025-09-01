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
        createPosition = transform.position;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut&&Go==1)
        {
            GenereteObgect();
            timeElapsed = 0.0f;
        }
    }

    private void GenereteObgect()
    {
        GameObject newObject=Instantiate(teki, createPosition, transform.rotation);
        Enemy enemy=newObject.GetComponent<Enemy>();
        string objectID="Enemy_"+nextObjectID.ToString();
        newObject.name = objectID;
        enemy.speed = speed;
        enemy.MaxHP = HP;
        objectDictionary.Add(objectID, newObject);
        nextObjectID++;
        if (objectID =="Enemy_1")
        {
            SetTargetObject();
        }
    }
    public bool IsEnemyExists()
    {
        return objectDictionary.ContainsKey(SentouID);
    }
    public void SetTargetObject()
    {
        if(Go==1)
        {
            if (IsEnemyExists())
            {
                Tuibi[] tuibis = FindObjectsOfType<Tuibi>();
                foreach (Tuibi tuibi in tuibis)
                {
                    tuibi.SetTargetObject(SentouID);
                }
            }
            else
            {
                sentouID++;
                SentouID = "Enemy_" + sentouID.ToString();
                SetTargetObject();
            }
        }
    }
    public void RemoveObject(GameObject gameObject)
    {
        Destroy(gameObject);
        objectDictionary.Remove(gameObject.name);/0폜
        price.increasePrice(20);
        price.increaseScore(score);
        score += 1;
        speed += (float)0.08;
        HP += (float)0.1;
        if (gameObject.name == SentouID)
        {
            sentouID++;
            SentouID = "Enemy_" + sentouID.ToString();
            SetTargetObject();
        }
    }
    public void start()
    {
        Go = 1;
        Time.timeScale = 1f;
    }
}
