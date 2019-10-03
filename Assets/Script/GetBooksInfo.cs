using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetBooksInfo : MonoBehaviour
{
    float Blockz = 0.45f;
    float Blockx = 0.2535f;
    float Blocky = 0.9314f;
    int Left = 1;
    int Right = 2;
    public Text PosText;
    //지금까지 상수였구연

    public GameObject TargetObj;
    public int IntRow, IntCol, IntDir;
    public float x, y, z;
    
    // Start is called before the first frame update
    void Start()
    {

        GameObject TargetObjChild = TargetObj.transform.GetChild(3).gameObject;

        IntRow = GetBookInfo.BooksRow[BooksAR.SelectNum];
        IntCol = GetBookInfo.BooksCol[BooksAR.SelectNum];
        IntDir = GetBookInfo.BooksDir[BooksAR.SelectNum];

        if (IntCol == 4)
        {
            y = (float)IntRow * -0.91f; //col 깊이
            z = 0; //row 높이
        }
        else if (IntCol < 4)
        {
            y = (float)IntRow * -0.91f; //col 깊이
            if (IntRow == 3)
            {
                z = 1 * -0.45f;//row 높이
            }
            else if (IntRow == 2)
            {
                z = 2 * -0.45f;//row 높이
            }
            else
            {
                z = 3 * -0.45f;//row 높이
            }
        }
        else
        {
            y = (float)IntRow * -0.91f; //col 깊이
            z = (float)(IntRow - 4) * 0.45f;//row 높이
        }

        if (IntDir == Left)
        {
        }
        else
        {
            TargetObjChild.transform.eulerAngles = new Vector3(TargetObj.transform.eulerAngles.x, TargetObj.transform.eulerAngles.y + 180f, TargetObj.transform.eulerAngles.z);
        }


        TargetObjChild.transform.position = new Vector3(x, y, z);

        PosText.text = "row = " + IntRow.ToString() + " col = " + IntCol.ToString() + " Dir = " + IntDir.ToString() +  " x = " + x.ToString() + " y = " + y.ToString() + " z = " + z.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
