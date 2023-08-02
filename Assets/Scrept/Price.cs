using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Price : MonoBehaviour//スコアやお金を管理するスクリプト
{
    public Text priceText;//所持金を表示する文字を格納する変数
    public int price;//所持金を格納する変数
    public Text Scoretext;//スコアの文字を格納する変数
    public Text Result;//スコア結果の文字を格納する変数
    public int Score;//スコアを格納する変数
    public void ReducePrice(int taihouprice)//所持金を減らす関数
    {
        price = price - taihouprice;//所持金から渡された値を引く
        priceText.text=price.ToString();//計算された値を文字に格納
    }
    public void increasePrice(int a)//所持金を増やす関数
    {
        price = price + a;//所持金に渡された値を足す
        priceText.text = price.ToString();//計算結果を文字に格納
    }
    public void increaseScore(int a)//スコアを増やす関数
    {
        Score=Score + a;//スコアに渡された値を足す
        Scoretext.text=Score.ToString();//計算結果を文字に格納
        Result.text=Score.ToString();//結果の文字にも格納
    }
}
