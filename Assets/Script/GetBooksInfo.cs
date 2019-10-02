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
        title.text = GetBookInfo.lname[BooksAR.SelectNum].ToString();
        row.text = GetBookInfo.row[BooksAR.SelectNum].ToString();
        col.text = GetBookInfo.col[BooksAR.SelectNum].ToString();
        dir.text = GetBookInfo.dir[BooksAR.SelectNum].ToString();
    }


}
