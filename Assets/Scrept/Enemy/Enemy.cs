using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;//hp���i�[����ϐ�
    public float MaxHP=4;//maxhp���i�[����ϐ�
    public float speed=1;//�X�s�[�h���i�[����ϐ�
    private Vector3 up= Vector3.up;//�ړ��������i�[����x�N�g��
    private Vector3 down= Vector3.down;//"
    private Vector3 right= Vector3.right;//"
    //private EnemyStart enemyStart;//EnemyStart���i�[����ϐ�
    private GameOver gameOver;//gameover���i�[����ϐ�
    public Boolean onof=false;
    private void Start()
    {
        //enemyStart = FindObjectOfType<EnemyStart>();//enemyStart�̏����擾
        gameOver = FindObjectOfType<GameOver>();//gameover�̏����擾
        hp = MaxHP;//hp��maxhp���i�[
    }
    void Update()
    {//�G���ړ������鏈��
        tekinoidou();
    }
    void tekinoidou()//�G�̈ړ����Ǘ�����֐�
    {//���W���烋�[�g���v�Z
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
        if (transform.position.y >= 6)//�G��y���W��6�𒴂�������s
        {
            //enemyStart.RemoveObject(gameObject);//�G���폜
            gameOver.gameover();//�Q�[���I�[�o�[�ɂ���
        }
    }
}
