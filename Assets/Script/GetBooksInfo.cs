using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetBooksInfo : MonoBehaviour
{
    public Text title;
    public Text row;
    public Text col;
    public Text dir;

    void Start()
    {
        title.text = GetBookInfo.BooksTitle[BooksAR.SelectNum].ToString();
        row.text = GetBookInfo.BooksRow[BooksAR.SelectNum].ToString();
        col.text = GetBookInfo.BooksCol[BooksAR.SelectNum].ToString();
        dir.text = GetBookInfo.BooksDir[BooksAR.SelectNum].ToString();
    }


}
