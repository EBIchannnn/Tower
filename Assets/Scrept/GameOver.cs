using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;//�Q�[���I�[�o�[�̃e�L�X�g���i�[����ϐ�
    public GameObject game;//�Q�[���I�[�o�[�p�̃I�u�W�F�N�g���i�[����ϐ�
    public void gameover()//�Q�[���I�[�o�[�ɂ���֐�
    {
        GameOverText.SetActive(true);//�Q�[���I�[�o�[�p�e�L�X�g��������悤�ɂ���
        game.SetActive(true);//�Q�[���I�[�o�[�p�̃I�u�W�F�N�g��������悤�ɂ���
        Time.timeScale = 0f;//�Q�[�����~�߂�
    }
    public void RestartGame()//�Q�[�������X�^�[�g����֐�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// ���݂̃V�[���������[�h���ăQ�[�����ĊJ����
    }
}
