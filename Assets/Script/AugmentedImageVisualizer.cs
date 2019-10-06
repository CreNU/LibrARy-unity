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
        // The AugmentedImage to visualize.
        public AugmentedImage Image;
        float Blockz = 0.45f;
        float Blockx = 0.2535f;
        float Blocky = 0.9314f;
        int Left = 1;
        int Right = 2;
        float RotationY;
        float WayPointX;

        public GameObject Lib;
        public GameObject WayPoint;
        public GameObject Center;
        public int IntRow, IntCol, IntDir;
        public float x, y, z;
        float CWPRx;
        bool ObjectTrue = false;

        // The Unity Update method.
        public void Update()
        {
            Center.transform.position = Camera.current.transform.position;
            GameObject ChildWayPoint= WayPoint.transform.GetChild(1).gameObject;
            GameObject ChildWayPoint2 = WayPoint.transform.GetChild(0).gameObject;

            IntRow = GetBookInfo.BooksRow[BooksAR.SelectNum];
            IntCol = GetBookInfo.BooksCol[BooksAR.SelectNum];
            IntDir = GetBookInfo.BooksDir[BooksAR.SelectNum];

            int ColMinus = IntCol - 1;

            if (IntRow == 4)
            {
                z = 0; //row 높이
            }
            else if (IntRow < 4)
            {
                z = (4 - IntRow) * -0.35f; //row 높이
            }
            else
            {
                z = (float)(IntRow - 4) * 0.35f; //row 높이
            }
            y = (float)ColMinus * -0.91f; //col 깊이

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

            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                Lib.SetActive(false);
                return;
            }
            
            Lib.transform.localPosition = new Vector3(x, y, z);
            Lib.transform.localRotation = Quaternion.Euler(-3.1f, 0f, 3.1f);
            WayPoint.transform.localRotation = Quaternion.Euler(-3.1f, 0f,3.1f);

            ChildWayPoint.transform.localPosition = new Vector3(x + WayPointX, y - 0.367f, z);
            CWPRx++;
            ChildWayPoint.transform.localRotation = Quaternion.Euler(CWPRx, -90, 90);
            ChildWayPoint2.transform.localRotation = Quaternion.Euler(CWPRx, -90, -90);
            Lib.SetActive(true);
        }
    }
}
