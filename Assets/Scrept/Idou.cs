using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idou : MonoBehaviour
{
    public float speed;//�e�̃X�s�[�h���i�[����ϐ�
    public int damage;//�e�̃_���[�W���i�[����ϐ�
    private EnemyStart enemyStart;//EnemyStart���i�[����ϐ�
    public GameObject Helthbar;//�̗̓o�[���i�[����ϐ�
    private void Start()
    {
        enemyStart = FindObjectOfType<EnemyStart>();//EnemyStart�̏����擾
    }
    void Update()
    {//�e���ړ�����
        transform.Translate(speed * Time.deltaTime * Vector3.up);//�e���ړ�������
        if (transform.position.y > 5.5 || transform.position.y < -3.5 || transform.position.x > 3.5 || transform.position.x < -3.5)//�e����ʊO�ɍs��������s
        {
            Destroy(gameObject);//�e���폜
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//�e�������ɓ�����������s
    {
        if (collision.tag == "Enemy")//�����������̂�Enemy����������s
        {
            Enemy enemy = collision.GetComponent<Enemy>();//��������Enemy�̏����擾
            EnemyHP enemyHP = collision.GetComponent<EnemyHP>();//��������EnemyHP�̏����擾
            EnemyHPBar enemyHPBar = enemyHP.newBar.GetComponent<EnemyHPBar>();//��������EnemyHP�ō��ꂽEnemyHPBar�̏����擾
            enemy.hp -= damage;//hp�����炷
            enemyHP.reduceHP(enemyHPBar.hpBarImage);//HPBAR�����炷
            if (enemy.hp <= 0)//hp��0�ɂȂ�������s
            {
                enemyStart.RemoveObject(collision.gameObject);//���������G���폜
            }
            Destroy(gameObject);//�e���폜
        }
    }
}
