using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class BooksAR : MonoBehaviour
{
    public Text title;
    public GameObject PopUp;
    public static int SelectNum;
    string ObName;
    string WithoutNumbers;
    int nTmp;

    public static int GetSelectNum()
    {
        return SelectNum;
    }
    public bool IsOkayToPopUp()
    {
        Debug.Log(PopUp.activeSelf + ", " + BtnItemClick.ClickStat + ", " + EventSystem.current.currentSelectedGameObject);
        if (PopUp.activeSelf == true || BtnItemClick.ClickStat != 1 || EventSystem.current.currentSelectedGameObject == null)
        {
            return false;
        }
        return true;
    }
    
    public void Update()
    {
        if (IsOkayToPopUp() == false)
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
        
        title.text = GetBookInfo.BooksTitle[SelectNum].ToString();
        PopUp.SetActive(true);

        if (GetBookInfo.BooksAR[SelectNum] == false)
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
