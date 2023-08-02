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
    {//��C�̌�����ς��鏈��
        if (string.IsNullOrEmpty(targetObjectID))
        {
            return;
        }
        GameObject gameObject = enemyStart.objectDictionary[targetObjectID];//�W�I��object��dictionary����擾
        Vector3 objectPosition = gameObject.transform.position;//object�̈ʒu�����擾
        Vector3 direction = objectPosition - transform.position;//��C�̈ʒu�Ƃ̍������߂�
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);//Enemy�̕�������
    }
    public void SetTargetObject(string objectID)
    {//�W�I�ɂ�����Enemy�̖��O���擾
        targetObjectID = objectID;
    }
}
