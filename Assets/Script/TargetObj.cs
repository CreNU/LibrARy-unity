using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public const float BlockHeight = 0.45f;
    public const float BlockWidth = 0.908f;//요건 y성분
    public const float BlockDepth = 0.143f;//요건 x성분
    public const float Pivotx = 0;
    public const float Pivoty = -0.464f;
    public const float Pivotz = -1.44f;
    public const int Left = 1;
    public const int Right = 2;
    //지금까지 상수였구연

    public GameObject TargetObj;
    public Text TextRow, TextCol, TextDir;//DB에서 받아온 값
    public int IntRow, IntCol, IntDir;
    public float x, y, z;
    
    // Start is called before the first frame update
    void Start()
    {
        IntRow = GetBookInfo.BooksRow[BooksAR.SelectNum];
        IntCol = GetBookInfo.BooksCol[BooksAR.SelectNum];
        IntDir = GetBookInfo.BooksDir[BooksAR.SelectNum];

        if (IntDir == Left)
        {
            x = Pivotx - BlockDepth;
        }
        else
        {
            x = Pivotx + BlockDepth;
        }
        y = Pivoty + (IntCol - 1) * BlockWidth;
        z = Pivotz + (IntRow - 1) * BlockHeight;
        TargetObj.transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        TargetObj.SetActive(true);
    }
}
