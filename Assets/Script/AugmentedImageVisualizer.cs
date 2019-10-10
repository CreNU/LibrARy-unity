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
        protected AugmentedImage Image;
        
        protected const float Blockz = 0.45f, Blockx = 0.2535f, Blocky = 0.9314f;
        protected int IntRow, IntCol, IntDir;
        protected float x, y, z;
        protected int SelectedNum;
        protected enum EnumDir
        {
            Left = 1,
            Right = 2
        }
        
        protected float RotationY;
        protected float WayPointX;
        protected GameObject Lib;
        protected GameObject WayPoint;
        protected GameObject Center;
        protected float CWPRx;
        protected bool ObjectTrue = false;
        
        // The Unity Update method.
        public void Update()
        {
            Center.transform.position = Camera.current.transform.position;
            GameObject ChildWayPoint= WayPoint.transform.GetChild(1).gameObject;
            GameObject ChildWayPoint2 = WayPoint.transform.GetChild(0).gameObject;
            
            SelectedNum = BooksAR.GetSelectNum();
            IntRow = GetBookInfo.BooksRow[SelectedNum];
            IntCol = GetBookInfo.BooksCol[SelectedNum];
            IntDir = GetBookInfo.BooksDir[SelectedNum];

            int ColMinus = IntCol - 1;

            if (IntRow == 4)//z값 계산
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
            
            y = (float)ColMinus * -0.91f; //col 깊이 // y값 계산

            if (IntDir == EnumDir.Left)// x값 계산
            {
                RotationY = 0f;
                WayPointX = -0.9f;
            }
            else
            {
                RotationY = 180f;
                WayPointX = 0.9f;
            }

            if (Image == null || Image.TrackingState != TrackingState.Tracking)//예외 처리
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
