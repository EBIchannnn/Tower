using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CursorOverlapDetection : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Camera mainCamera;
    private GameObject taihouObject;//��C���i�[����ϐ�
    private TaihouStart taihouStart;//TaihouStart���i�[����ϐ�
    public float sensitivity = 1f;//��C�̈ړ��t���[�����i�[����ϐ�
    public GameObject taihou;
    private string TaihouID;
    private int taihouID;
    public Dictionary<int, GameObject> TaihouDIctionary;//��C���i�[����z��
    void Start()
    {
        mainCamera = Camera.main;
        taihouStart = FindObjectOfType<TaihouStart>();//TaihouStart�̏����擾
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;//�}�E�X�ʒu�擾
        //mousePosition.z = -mainCamera.transform.position.z;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);//�}�E�X�ʒu��ϊ�
        Collider2D hitCollider = Physics2D.OverlapPoint(worldMousePosition);//�}�E�X�ʒu�ɂ���object���擾

        if (hitCollider != null)//�}�E�X��object�ɏd�Ȃ�����
        {
            if (hitCollider.tag == "a"&&Input.GetMouseButtonDown(0))//object��a�ł��N���b�N���ꂽ��
            {
                taihouStart.createTaihou();//��C�𐶐�
                touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�N���b�N�����ꏊ���擾
            }
            if (hitCollider.tag == "Taihou1" && Input.GetMouseButton(0))//���N���b�N�𒷉������ꂽ��
            {
                taihouObject = hitCollider.gameObject;//�d�Ȃ���object���擾
                Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
                taihouObject.transform.position = worldMousePosition;
                touchStartPos = taihouObject.transform.position; // �^�b�`�̊J�n�ʒu���X�V
                //taihouObject = hitCollider.gameObject;//�d�Ȃ���object���擾
                //Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
                //Vector3 moveAmount = currentPos - touchStartPos;//��C�̈ʒu�Ƃ̍����v�Z
                //taihouObject.transform.position = transform.position + moveAmount * sensitivity;//��C�̈ʒu���}�E�X�ɍ��킹�Ĉړ�
            }
        }
    }
    public void createTaihou()//��C�𐶐�����֐�
    {
        Price price = FindObjectOfType<Price>();//Price�̏����擾
        if (price.price < 100)//��C�̏����ł���A��������100������������
        {
            return;//�������Ȃ�
        }
        GameObject gameObject = Instantiate(taihou, taihouStart.transform.position, taihouStart.transform.rotation);//��C�𐶐�
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouController�̏����擾
        controller.dmg = 1;//�_���[�W����n��
        TaihouID = taihouID.ToString();//��C�̖��O�𐶐�
        gameObject.name = TaihouID;//���O��ݒ�
        TaihouDIctionary.Add(taihouID, gameObject);//�z��Ɋi�[
        taihouID++;//ID�����Ɉڂ�
        price.ReducePrice(100);//��������100���炷
    }

}
