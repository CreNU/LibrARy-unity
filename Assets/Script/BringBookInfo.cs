using GoogleARCore.Examples.AugmentedImage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BringBookInfo : MonoBehaviour
{

    public Text BookTitle;
    public Text Distance;
    public Image UpImage;
    public Sprite CheckImage;
    public Sprite RightImage;
    int SelectedNum;
    int DIstanceNum;
    // Start is called before the first frame update
    void Start()
    {
        SelectedNum = BooksAR.GetSelectNum();
        BookTitle.text = GetBookInfo.BooksTitle[SelectedNum].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("main");
            }
        }

        if (AugmentedImageVisualizer.WayPointNum != 0)
        {
            DIstanceNum = (int)AugmentedImageVisualizer.BooksDistance;
            Distance.text = DIstanceNum.ToString() + "m";
        }
        else
        {
            Distance.text = "도착";
        }

        if (AugmentedImageVisualizer.WayPointNum == 1)
        {
            UpImage.sprite = RightImage;
        }else if(AugmentedImageVisualizer.WayPointNum == 2)
        {
            UpImage.sprite = CheckImage;
        }
    }
}
