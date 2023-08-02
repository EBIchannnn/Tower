using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private GameObject hpBar;//HP�o�[���i�[����ϐ�
    [SerializeField] private Transform barPos;//HP�o�[�̏ꏊ���i�[����ϐ�
    private Vector3 createposition;//HP�o�[�𐶐�����ꏊ���i�[����ϐ�
    private float MaxHP;//MaxHP���i�[����ϐ�
    private Enemy enemy;//Enemy���i�[����ϐ�
    public float imanoHP;//HP���i�[����ϐ�
    public GameObject newBar;//HP�o�[���i�[����ϐ�
    void Start()
    {
        CreateHealthBar();//�֐����Ă�
        enemy = GetComponent<Enemy>();//Enemy�̏����擾
        MaxHP = enemy.MaxHP;//MaxHP���擾
    }

    private void CreateHealthBar()//HPBar�𐶐�����֐�
    {
        createposition=barPos.position;//�A�^�b�`����Ă���Enemy�̈ʒu�����擾
        createposition.y += 0.3f;//�ʒu�𒲐�
        newBar = Instantiate(hpBar, createposition, Quaternion.identity);//HP�o�[�𐶐�
        newBar.transform.SetParent(transform);//HPBar��Enemy�̎q�I�u�W�F�N�g�ɐݒ�
    }
    public void reduceHP(Image image)//HPBar�����炷�֐�
    {
        imanoHP = enemy.hp;//HP���擾
        image.fillAmount = Mathf.Lerp(image.fillAmount, imanoHP/MaxHP, Time.deltaTime*40f);//image�̕\��������ς���
    }
}
