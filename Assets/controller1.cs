using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CursorOverlapDetection : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Camera mainCamera;
    private GameObject taihouObject;//大砲を格納する変数
    private TaihouStart taihouStart;//TaihouStartを格納する変数
    public float sensitivity = 1f;//大砲の移動フレームを格納する変数
    public GameObject taihou;
    private string TaihouID;
    private int taihouID;
    public Dictionary<int, GameObject> TaihouDIctionary;//大砲を格納する配列
    void Start()
    {
        mainCamera = Camera.main;
        taihouStart = FindObjectOfType<TaihouStart>();//TaihouStartの情報を取得
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;//マウス位置取得
        //mousePosition.z = -mainCamera.transform.position.z;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);//マウス位置を変換
        Collider2D hitCollider = Physics2D.OverlapPoint(worldMousePosition);//マウス位置にあるobjectを取得

        if (hitCollider != null)//マウスがobjectに重なったら
        {
            if (hitCollider.tag == "a"&&Input.GetMouseButtonDown(0))//objectがaでかつクリックされたら
            {
                taihouStart.createTaihou();//大砲を生成
                touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//クリックした場所を取得
            }
            if (hitCollider.tag == "Taihou1" && Input.GetMouseButton(0))//左クリックを長押しされたら
            {
                taihouObject = hitCollider.gameObject;//重なったobjectを取得
                Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得
                taihouObject.transform.position = worldMousePosition;
                touchStartPos = taihouObject.transform.position; // タッチの開始位置を更新
                //taihouObject = hitCollider.gameObject;//重なったobjectを取得
                //Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得
                //Vector3 moveAmount = currentPos - touchStartPos;//大砲の位置との差を計算
                //taihouObject.transform.position = transform.position + moveAmount * sensitivity;//大砲の位置をマウスに合わせて移動
            }
        }
    }
    public void createTaihou()//大砲を生成する関数
    {
        Price price = FindObjectOfType<Price>();//Priceの情報を取得
        if (price.price < 100)//大砲の処理であり、所持金が100未満だったら
        {
            return;//何もしない
        }
        GameObject gameObject = Instantiate(taihou, taihouStart.transform.position, taihouStart.transform.rotation);//大砲を生成
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouControllerの情報を取得
        controller.dmg = 1;//ダメージ情報を渡す
        TaihouID = taihouID.ToString();//大砲の名前を生成
        gameObject.name = TaihouID;//名前を設定
        TaihouDIctionary.Add(taihouID, gameObject);//配列に格納
        taihouID++;//IDを次に移す
        price.ReducePrice(100);//所持金を100減らす
    }

}
