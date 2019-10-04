//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;
        float Blockz = 0.45f;
        float Blockx = 0.2535f;
        float Blocky = 0.9314f;
        int Left = 1;
        int Right = 2;
        float RotationY;
        float WayPointX;
        //지금까지 상수였구연

        public GameObject Lib;
        public GameObject WayPoint;
        public int IntRow, IntCol, IntDir;
        public float x, y, z;
        float CWPRx;

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {

            GameObject ChildWayPoint= WayPoint.transform.GetChild(1).gameObject;
            GameObject ChildWayPoint2 = WayPoint.transform.GetChild(0).gameObject;

            IntRow = GetBookInfo.BooksRow[BooksAR.SelectNum];
            IntCol = GetBookInfo.BooksCol[BooksAR.SelectNum];
            IntDir = GetBookInfo.BooksDir[BooksAR.SelectNum];

            int ColMinus = IntCol - 1;

            if (IntRow == 4)
            {
                y = (float)ColMinus * -0.91f; //col 깊이
                z = 0; //row 높이
            }
            else if (IntRow < 4)
            {
                y = (float)ColMinus * -0.91f; //col 깊이
                if (IntRow == 3)
                {
                    z = 1 * -0.35f;//row 높이
                }
                else if (IntRow == 2)
                {
                    z = 2 * -0.35f;//row 높이
                }
                else
                {
                    z = 3 * -0.35f;//row 높이
                }
            }
            else
            {
                y = (float)ColMinus * -0.91f; //col 깊이
                z = (float)(IntRow - 4) * 0.35f;//row 높이
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

            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                Lib.SetActive(false);
                return;
            }
            Lib.transform.localPosition = new Vector3(x, y, z);
            Lib.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            ChildWayPoint.transform.localPosition = new Vector3(x + WayPointX, y-0.367f, z);
            CWPRx = CWPRx + 1;
            ChildWayPoint.transform.localRotation = Quaternion.Euler(CWPRx, -90, 90);
            ChildWayPoint2.transform.localRotation = Quaternion.Euler(CWPRx, -90, -90);

            Lib.SetActive(true);
        }
    }
}
