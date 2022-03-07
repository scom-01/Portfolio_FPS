using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : MonoBehaviour
{
    public static float MouseXSpeed = 1.0f;
    public static float MouseYSpeed = 1.0f;
    public static float deltaTime = 0.02f;
    public static bool Fire = false;
    #region CrossHair
    public static float CH_Width = 10;
    public static float CH_Height = 50;
    public static float CH_Height_Fill = 1;
    public static float CH_Pivot_Y = -0.1f;
    #endregion
}

public enum CharState
{
    move,
    hang,
}

public enum CharZoom
{
    idle,
    x1,
    x2,
    x4,
    x8
}
