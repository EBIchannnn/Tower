using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouController : MonoBehaviour
{
    private Vector3 touchStartPos;//�N���b�N�����ꏊ���i�[����x�N�g��
    private Vector3 taihouStartPos;//��C�̈ʒu���i�[����x�N�g��
    public float sensitivity = 1f;//��C�̈ړ��t���[�����i�[����ϐ�
    private TaihouStart taihouStart;//TaihouStart���i�[����ϐ�
    private TaihouStart2 taihouStart2;//TaihouStart2���i�[����ϐ�
    private GameObject taihouObject;//��C���i�[����ϐ�
    private EnemyStart enemyStart;//Enemy���i�[����ϐ�
    public int dmg;
    private void Start()
    {
        taihouStart=FindObjectOfType<TaihouStart>();//TaihouStart�̏����擾
        enemyStart = FindObjectOfType<EnemyStart>();//EnemtStart�̏����擾
        taihouStart2=FindObjectOfType<TaihouStart2>();//TaihouStart2�̏����擾
    }
    void Update()
    {
        if (taihouStart.ID==0&&taihouStart2.ID2==0)//TaihouStart��TaihouStart2��ID���{�^���̏�����������
        {
            return;//�������Ȃ�
        }
        taihouObject = taihouStart.TaihouDIctionary[taihouStart.taihouID-1];//����������C��z�񂩂�擾
        if (Input.GetMouseButtonDown(0))//�}�E�X�ō��N���b�N���ꂽ��
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�N���b�N�����ꏊ���擾
            taihouStartPos =transform.position;//��C�̏ꏊ���擾
        }
        else if (Input.GetMouseButton(0))//���N���b�N�𒷉������ꂽ��
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
            Vector3 moveAmount = currentPos - touchStartPos;//��C�̈ʒu�Ƃ̍����v�Z
            taihouObject.transform.position = taihouStartPos + moveAmount * sensitivity;//��C�̈ʒu���}�E�X�ɍ��킹�Ĉړ�
        }
        if (taihouObject.transform.position.y >= -3&& Input.GetMouseButtonUp(0))//��C��Y����-3�ȏォ�A�}�E�X�N���b�N�������ꂽ��
        {
            taihouStart.ID=0;//ID���{�^���̏����ɕύX
            taihouStart2.ID2=0;//ID2���{�^���̏����ɕύX
            enemyStart.SetTargetObject();//EnemyStart�̊֐����Ă�
        }
    }
}
