using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;//ゲームオーバーのテキストを格納する変数
    public GameObject game;//ゲームオーバー用のオブジェクトを格納する変数
    public void gameover()//ゲームオーバーにする関数
    {
        GameOverText.SetActive(true);//ゲームオーバー用テキストを見えるようにする
        game.SetActive(true);//ゲームオーバー用のオブジェクトを見えるようにする
        Time.timeScale = 0f;//ゲームを止める
    }
    public void RestartGame()//ゲームをリスタートする関数
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// 現在のシーンをリロードしてゲームを再開する
    }
}
