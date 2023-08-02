using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouStart2 : MonoBehaviour
{
    public GameObject taihou;//��C���i�[����ϐ�
    public int ID2 = 0;//��C�̏������{�^���̏��������肷��ׂ�ID
    public int taihouID;//�G��ID���i�[����ϐ�
    private string TaihouID;//�G�̖��O���i�[����ϐ�
    private TaihouStart taihouStart;//TaihouStart���i�[����ϐ�
    private Price price;//Price���i�[����ϐ�
    private void Start()
    {
        taihouStart = FindObjectOfType<TaihouStart>();//TaihouStart�̏����擾
        price=FindObjectOfType<Price>();//Price�̏����擾
    }
    public void createTaihou()//��C�𐶐�����֐�
    {
        if (ID2 == 1 || price.price < 200)//ID����C�̏����A�܂��͏�������200�����̏ꍇ�Ɏ��s
        {
            return;//�������Ȃ�
        }
        taihouID = taihouStart.taihouID;//���������C��ID��TaihouStart����擾
        GameObject gameObject = Instantiate(taihou, transform.position, transform.rotation);//��C�𐶐�
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouController�̏����擾
        controller.dmg = 2;//�_���[�W����n��
        TaihouID = taihouID.ToString();//��C�̖��O�𐶐�
        gameObject.name = TaihouID;//���O��ݒ�
        taihouStart.TaihouDIctionary.Add(taihouID, gameObject);//��C��z��Ɋi�[
        ID2=1;//ID���C�̏����ɕύX
        taihouStart.taihouID++;//���̑�C��ID��ݒ�
        price.ReducePrice(200);//��������200���炷
    }
}
