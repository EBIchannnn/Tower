using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Price : MonoBehaviour//�X�R�A�₨�����Ǘ�����X�N���v�g
{
    public Text priceText;//��������\�����镶�����i�[����ϐ�
    public int price;//���������i�[����ϐ�
    public Text Scoretext;//�X�R�A�̕������i�[����ϐ�
    public Text Result;//�X�R�A���ʂ̕������i�[����ϐ�
    public int Score;//�X�R�A���i�[����ϐ�
    public void ReducePrice(int taihouprice)//�����������炷�֐�
    {
        price = price - taihouprice;//����������n���ꂽ�l������
        priceText.text=price.ToString();//�v�Z���ꂽ�l�𕶎��Ɋi�[
    }
    public void increasePrice(int a)//�������𑝂₷�֐�
    {
        price = price + a;//�������ɓn���ꂽ�l�𑫂�
        priceText.text = price.ToString();//�v�Z���ʂ𕶎��Ɋi�[
    }
    public void increaseScore(int a)//�X�R�A�𑝂₷�֐�
    {
        Score=Score + a;//�X�R�A�ɓn���ꂽ�l�𑫂�
        Scoretext.text=Score.ToString();//�v�Z���ʂ𕶎��Ɋi�[
        Result.text=Score.ToString();//���ʂ̕����ɂ��i�[
    }
}
