using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouStart : MonoBehaviour
{
    public Dictionary<int, GameObject> TaihouDIctionary;
    public GameObject taihou;
    public int ID = 0;
    public int taihouID = 0;
    private string TaihouID;
    private Price price;
    private void Start()
    {
        TaihouDIctionary = new Dictionary<int, GameObject>();//�z��𐶐�
    }
    public void createTaihou()//��C�𐶐�����֐�
    {
        price = FindObjectOfType<Price>();//Price�̏����擾
        if (ID==1||price.price<100)//��C�̏����ł���A��������100������������
        {
            return;//�������Ȃ�
        }
        GameObject gameObject = Instantiate(taihou, transform.position, transform.rotation);//��C�𐶐�
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouController�̏����擾
        controller.dmg = 1;//�_���[�W����n��
        TaihouID=taihouID.ToString();//��C�̖��O�𐶐�
        gameObject.name = TaihouID;//���O��ݒ�
        TaihouDIctionary.Add(taihouID, gameObject);//�z��Ɋi�[
        //ID=1;//��C�̏����Ɉڂ�
        taihouID++;//ID�����Ɉڂ�
        price.ReducePrice(100);//��������100���炷
    }
}
