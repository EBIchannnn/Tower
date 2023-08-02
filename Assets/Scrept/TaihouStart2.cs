using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaihouStart2 : MonoBehaviour
{
    public GameObject taihou;//‘å–C‚ğŠi”[‚·‚é•Ï”
    public int ID2 = 0;//‘å–C‚Ìˆ—‚©ƒ{ƒ^ƒ“‚Ìˆ—‚©”»’è‚·‚éˆ×‚ÌID
    public int taihouID;//“G‚ÌID‚ğŠi”[‚·‚é•Ï”
    private string TaihouID;//“G‚Ì–¼‘O‚ğŠi”[‚·‚é•Ï”
    private TaihouStart taihouStart;//TaihouStart‚ğŠi”[‚·‚é•Ï”
    private Price price;//Price‚ğŠi”[‚·‚é•Ï”
    private void Start()
    {
        taihouStart = FindObjectOfType<TaihouStart>();//TaihouStart‚Ìî•ñ‚ğæ“¾
        price=FindObjectOfType<Price>();//Price‚Ìî•ñ‚ğæ“¾
    }
    public void createTaihou()//‘å–C‚ğ¶¬‚·‚éŠÖ”
    {
        if (ID2 == 1 || price.price < 200)//ID‚ª‘å–C‚Ìˆ—A‚Ü‚½‚ÍŠ‹à‚ª200–¢–‚Ìê‡‚ÉÀs
        {
            return;//‰½‚à‚µ‚È‚¢
        }
        taihouID = taihouStart.taihouID;//¶¬‚·‚é‘å–C‚ÌID‚ğTaihouStart‚©‚çæ“¾
        GameObject gameObject = Instantiate(taihou, transform.position, transform.rotation);//‘å–C‚ğ¶¬
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouController‚Ìî•ñ‚ğæ“¾
        controller.dmg = 2;//ƒ_ƒ[ƒWî•ñ‚ğ“n‚·
        TaihouID = taihouID.ToString();//‘å–C‚Ì–¼‘O‚ğ¶¬
        gameObject.name = TaihouID;//–¼‘O‚ğİ’è
        taihouStart.TaihouDIctionary.Add(taihouID, gameObject);//‘å–C‚ğ”z—ñ‚ÉŠi”[
        ID2=1;//ID‚ğ‘å–C‚Ìˆ—‚É•ÏX
        taihouStart.taihouID++;//Ÿ‚Ì‘å–C‚ÌID‚ğİ’è
        price.ReducePrice(200);//Š‹à‚ğ200Œ¸‚ç‚·
    }
}
