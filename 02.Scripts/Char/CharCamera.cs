using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCamera : MonoBehaviour
{
    float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        y += Input.GetAxis("Mouse Y") * GlobalValue.MouseYSpeed;

        if (y >= 90)
            y = 90;
        else if (y <= -90)
            y = -90;

        this.transform.localRotation = Quaternion.Euler(-y, 0, 0);
    }
}
