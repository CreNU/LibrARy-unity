using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class BooksAR : MonoBehaviour
{
    Except Baseball;
    public Text title;
    public GameObject PopUp;
    public static int SelectNum;
    string ObName;
    string WithoutNumbers;
    int nTmp;

    public void Update()
    {

        if (PopUp.activeSelf == true || BtneItemClick.ClickStat != 1 || EventSystem.current.currentSelectedGameObject == false)
        {
            return;
        }

        ObName = EventSystem.current.currentSelectedGameObject.name;
        string strTmp = Regex.Replace(ObName, @"\D", "");
        WithoutNumbers = Regex.Replace(ObName, "[0-9]", "");
        int.TryParse(strTmp, out nTmp);
        Debug.Log("순서 인덱스 + " + nTmp);
        SelectNum = nTmp;
        GameObject BackPanel = PopUp.transform.GetChild(0).gameObject;
        GameObject ArOn = BackPanel.transform.GetChild(2).gameObject;
        GameObject ArOff = BackPanel.transform.GetChild(3).gameObject;
        

        if (WithoutNumbers != "(Clone)")
        {
            return;
        }
        
        title.text = GetBookInfo.BooksTitle[nTmp].ToString();
        PopUp.SetActive(true);

        if (GetBookInfo.BookAR[nTemp] == NULL)
        {
            ArOn.SetActive(false);
            ArOff.SetActive(true);
        }
        else
        {
            ArOn.SetActive(true);
            ArOff.SetActive(false);
        }
        BtnItemClick.ClickStat = 0;
    }
}
