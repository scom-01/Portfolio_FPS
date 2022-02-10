using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : MonoBehaviour
{
    public static float MouseXSpeed = 1.0f;
    public static float MouseYSpeed = 1.0f;
    public static float deltaTime = 0.02f;

    #region CrossHair
    public static float CH_Width = 10;
    public static float CH_Height = 50;
    public static float CH_Height_Fill = 1;
    #endregion
}

public enum CharState
{
    move,
    hang,
}
