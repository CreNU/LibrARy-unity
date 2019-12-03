namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    // Uses 4 frame corner objects to visualize an AugmentedImage.
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        public AugmentedImage Image;
        public GameObject WayPoint;
        public GameObject Lib;
        public GameObject Center;
        public static float BooksDistance;
        public static int WayPointNum;

        float RotationY;
        float WayPointX;
        int Left = 1;
        public float x, y, z;
        float Blockz = 0.45f, Blockx = 0.2535f, Blocky = 0.9314f;
        public int IntRow, IntCol, IntDir;
        float CWPRx;
        int SelectedNum;



        // The Unity Update method.
        public void Update()
        {
            Center.transform.position = Camera.current.transform.position;
            GameObject Location = Lib.transform.GetChild(0).gameObject;
            GameObject ChildWayPoint1 = WayPoint.transform.GetChild(0).gameObject;
            GameObject ChildWayPoint2 = WayPoint.transform.GetChild(1).gameObject;

            SelectedNum = BooksAR.GetSelectNum();
            IntRow = GetBookInfo.BooksRow[SelectedNum];
            IntCol = GetBookInfo.BooksCol[SelectedNum];
            IntDir = GetBookInfo.BooksDir[SelectedNum];

            int ColMinus = IntCol - 1;

            if (IntRow == 4)
            {
                y = (float)ColMinus * -0.91f;
                z = 0;
            }
            else if (IntRow < 4)
            {
                y = (float)ColMinus * -0.91f;
                if (IntRow == 3)
                {
                    z = 1 * -0.35f;
                }
                else if (IntRow == 2)
                {
                    z = 2 * -0.35f;
                }
                else
                {
                    z = 3 * -0.35f;
                }
            }
            else
            {
                y = (float)ColMinus * -0.91f;
                z = (float)(IntRow - 4) * 0.35f;
            }

            if (IntDir == Left)
            {
                RotationY = 0f;
                WayPointX = -0.9f;
            }
            else
            {
                RotationY = 180f;
                WayPointX = 0.9f;
            }

            Lib.transform.localPosition = new Vector3(0f, 0f, 0f);
            Location.transform.localPosition = new Vector3(x, y, z);
            ChildWayPoint2.transform.localPosition = new Vector3(x + WayPointX, y - 0.367f, z);
            if (ChildWayPoint2.activeSelf == false)
            {
                BooksDistance = Vector3.Distance(ChildWayPoint1.transform.position, ChildWayPoint2.transform.position)
                    + Vector3.Distance(Camera.current.transform.position, ChildWayPoint1.transform.position);
                WayPointNum = 1;
            }
            else if(ChildWayPoint2.activeSelf == true)
            {
                BooksDistance = Vector3.Distance(Camera.current.transform.position, ChildWayPoint2.transform.position);
                WayPointNum = 2;
            }else if(ChildWayPoint2.activeSelf == false && ChildWayPoint2.activeSelf == false)
            {
                WayPointNum = 0;
            }
        }
    }
}
