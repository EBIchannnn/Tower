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
        createPosition = transform.position;//�����ꏊ��o�^
        timeElapsed += Time.deltaTime;//���Ԃ��v��
        if (timeElapsed >= timeOut&&Go==1)
        {//TimeOut�̒l���Ԍo�߂�������s
            GenereteObgect();
            timeElapsed = 0.0f;//���Ԃ����Z�b�g
        }
    }

    private void GenereteObgect()
    {//Enemy�𐶐�����
        GameObject newObject=Instantiate(teki, createPosition, transform.rotation);//��������
        Enemy enemy=newObject.GetComponent<Enemy>();
        string objectID="Enemy_"+nextObjectID.ToString();//���O�𐶐�
        newObject.name = objectID;//���O��K�p
        enemy.speed = speed;
        enemy.MaxHP = HP;
        objectDictionary.Add(objectID, newObject);//�����ɓo�^
        nextObjectID++;//���̖��O
        if (objectID =="Enemy_1")
        {
            SetTargetObject();//�ŏ��Ɉ�x�����Ăяo��
        }//Debug.Log(sentouID);
    }
    public bool IsEnemyExists()
    {//�擾����objectID��Dictionry�ɑ��݂����ꍇTrue��Ԃ�
        return objectDictionary.ContainsKey(SentouID);
    }
    public void SetTargetObject()
    {
        if(Go==1)
        {
            if (IsEnemyExists())
            {//IsEnemyExists��True�̏ꍇ�̏���
                Tuibi[] tuibis = FindObjectsOfType<Tuibi>();//�S�Ă̑�C�ɏ�����K�p������
                foreach (Tuibi tuibi in tuibis)
                {
                    tuibi.SetTargetObject(SentouID);
                }//SentouID�������Ƃ��ēn��
            }
            else
            {
                sentouID++;//�擪�����炷
                SentouID = "Enemy_" + sentouID.ToString();
                SetTargetObject();
            }
        }
    }
    public void RemoveObject(GameObject gameObject)
    {//�폜����
        Destroy(gameObject);//�����Ƃ��ēn���ꂽEnemy���폜
        objectDictionary.Remove(gameObject.name);//����������폜
        price.increasePrice(20);
        price.increaseScore(score);
        score += 1;
        speed += (float)0.08;
        HP += (float)0.1;
        if (gameObject.name == SentouID)
        {//��ꂽEnemy���擪���ǂ���
            sentouID++;//�擪�����ɂ��炷
            SentouID = "Enemy_" + sentouID.ToString();
            SetTargetObject();
        }
    }
    public void start()
    {
        Go = 1;
        Time.timeScale = 1f;//�Q�[���𓮂���
    }
}
