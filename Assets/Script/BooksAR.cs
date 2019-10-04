using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class BooksAR : MonoBehaviour
{

    public Text title;
    public GameObject popUP;
    public static int SelectNum;
    string ObName;
    string withoutNumbers;
    int nTmp;

    public void Update()
    {
        if (popUP.activeSelf == false && BtnItemClick.ClickStat == 1)
        {
            if (EventSystem.current.currentSelectedGameObject)
            {
                ObName = EventSystem.current.currentSelectedGameObject.name;
                string strTmp = Regex.Replace(ObName, @"\D", "");
                withoutNumbers = Regex.Replace(ObName, "[0-9]", "");
                int.TryParse(strTmp, out nTmp);
                Debug.Log("순서 인덱스 + " + nTmp);
                SelectNum = nTmp;
                GameObject BackPanel = popUP.transform.GetChild(0).gameObject;
                GameObject ArOn = BackPanel.transform.GetChild(2).gameObject;
                GameObject ArOff = BackPanel.transform.GetChild(3).gameObject;

                if (withoutNumbers == "(Clone)")
                {
                    title.text = GetBookInfo.BooksTitle[nTmp].ToString();

                    popUP.SetActive(true);
                    if (!GetBookInfo.BooksAR[nTmp])
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
        }
    }
}
