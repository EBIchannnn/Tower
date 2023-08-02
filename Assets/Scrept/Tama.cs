using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{
    public GameObject tama;//�e���i�[����ϐ�
    public GameObject teki;//�G���i�[����ϐ�
    public float timeOut;//�����Ԋu���i�[����ϐ�
    private float timeElapsed;//�o�ߎ��Ԃ��i�[����ϐ�
    private EnemyStart enemyStart;//EnemyStart���i�[����ϐ�

    void Update()
    {
        enemyStart = FindObjectOfType<EnemyStart>();//EnemyStart�̏����擾
        if (enemyStart.Go == 1)//�X�^�[�g�{�^���������ꂽ����s
        {
            timeElapsed += Time.deltaTime;//�o�ߎ��Ԃ𑪒�
            if (timeElapsed >= timeOut)//�o�ߎ��Ԃ�timeOut�ɒB��������s
            {
                GameObject gameObject = Instantiate(tama, transform.position, transform.rotation);//�e�𐶐�
                TaihouController taihouController = GetComponent<TaihouController>();//taihouController�̏����擾
                Idou idou = gameObject.GetComponent<Idou>();//Idou�̏����擾
                idou.damage = taihouController.dmg;//�_���[�W����Idou�ɓ`����
                timeElapsed = 0.0f;//�o�ߎ��ԃ��Z�b�g
            }
        }
    }
}
