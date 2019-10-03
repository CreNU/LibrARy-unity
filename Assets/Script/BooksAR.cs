using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class BooksAR : MonoBehaviour
{
    public Text row;
    public Text col;
    public Text dir;
    public Text sucess;
    public Text title;
    public GameObject popUP;
    public static int SelectNum;
    string ObName;
    string withoutNumbers;
    int nTmp;


    GameObject BackPanel = popUP.transform.GetChild(0).gameObject;
    GameObject ArButton = BackPanel.transform.GetChild(0).gameObject;

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
                if (withoutNumbers == "(Clone)")
                {

                    row.text = "row = " + GetBookInfo.row[nTmp].ToString();

                    col.text = "col = " + GetBookInfo.col[nTmp].ToString();
                    dir.text = "dir = " + GetBookInfo.dir[nTmp].ToString();
                    sucess.text = "AR = " + GetBookInfo.success[nTmp].ToString();
                    title.text = "title = " + GetBookInfo.lname[nTmp].ToString();

                    popUP.SetActive(true);
                    if (!GetBookInfo.success[nTmp])
                    {
                        ArButton.SetActive(false);
                    }
                    else
                    {
                        ArButton.SetActive(true);
                    }
                    BtnItemClick.ClickStat = 0;
                }
            }
        }
    }
}
