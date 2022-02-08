using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : MonoBehaviour
{
    public static float MouseXSpeed = 1.0f;
    public static float MouseYSpeed = 1.0f;
    public static float deltaTime = 0.02f;
}

public enum CharState
{
    move,
    hang,
}
