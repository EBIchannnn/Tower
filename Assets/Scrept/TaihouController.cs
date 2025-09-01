using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouController : MonoBehaviour
{
    private Vector3 touchStartPos;//�N���b�N�����ꏊ���i�[����x�N�g��
    private Vector3 taihouStartPos;//��C�̈ʒu���i�[����x�N�g��
    public float sensitivity = 1f;//��C�̈ړ��t���[�����i�[����ϐ�
    private TaihouStart taihouStart = FindObjectOfType<TaihouStart>();
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
    public void createTaihou()
    {
        if (Input.GetMouseButtonDown(0))//���N���b�N���ꂽ��
        {
            taihouStart.createTaihou();
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�N���b�N�����ꏊ���擾
            taihouStartPos = transform.position;//��C�̏ꏊ���擾
        }
        else if (Input.GetMouseButton(0))//���N���b�N�𒷉������ꂽ��
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
            Vector3 moveAmount = currentPos - touchStartPos;//��C�̈ʒu�Ƃ̍����v�Z
            taihouObject.transform.position = taihouStartPos + moveAmount * sensitivity;//��C�̈ʒu���}�E�X�ɍ��킹�Ĉړ�
        }

    }
}
