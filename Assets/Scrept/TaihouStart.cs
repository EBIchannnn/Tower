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
        TaihouDIctionary = new Dictionary<int, GameObject>();//”z—ñ‚ğ¶¬
    }
    public void createTaihou()//‘å–C‚ğ¶¬‚·‚éŠÖ”
    {
        price = FindObjectOfType<Price>();//Price‚Ìî•ñ‚ğæ“¾
        if (ID==1||price.price<100)//‘å–C‚Ìˆ—‚Å‚ ‚èAŠ‹à‚ª100–¢–‚¾‚Á‚½‚ç
        {
            return;//‰½‚à‚µ‚È‚¢
        }
        GameObject gameObject = Instantiate(taihou, transform.position, transform.rotation);//‘å–C‚ğ¶¬
        TaihouController controller = gameObject.GetComponent<TaihouController>();//TaihouController‚Ìî•ñ‚ğæ“¾
        controller.dmg = 1;//ƒ_ƒ[ƒWî•ñ‚ğ“n‚·
        TaihouID=taihouID.ToString();//‘å–C‚Ì–¼‘O‚ğ¶¬
        gameObject.name = TaihouID;//–¼‘O‚ğİ’è
        TaihouDIctionary.Add(taihouID, gameObject);//”z—ñ‚ÉŠi”[
        //ID=1;//‘å–C‚Ìˆ—‚ÉˆÚ‚é
        taihouID++;//ID‚ğŸ‚ÉˆÚ‚·
        price.ReducePrice(100);//Š‹à‚ğ100Œ¸‚ç‚·
    }
}
