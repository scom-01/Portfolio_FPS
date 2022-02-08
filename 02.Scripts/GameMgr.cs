using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Text SpeedTxt;
    public Text VelocityTxt;
    public Text MouseTxt;
    public Text TransformTxt;
    public Slider MouseX_Slider;
    public Slider MouseY_Slider;
    public Slider FOV_Slider;
    
    GameObject Player1;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
        cc = Player1.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CusorOnOff();
        DebugCanvas();
    }

    void DebugCanvas()
    {
        SpeedTxt.text = string.Format("Speed : {0:F2}", cc.velocity.magnitude);
        VelocityTxt.text = string.Format("Velocity X : {0:F2} Y : {1:F2} Z : {2:F2}", cc.velocity.x, cc.velocity.y, cc.velocity.z);
        MouseTxt.text = string.Format("Mouse X(감도 : {0:F2}) : {1:F2} Y(감도{2:F2}) : {3:F2}", GlobalValue.MouseXSpeed, Input.GetAxis("Mouse X") * GlobalValue.MouseXSpeed, GlobalValue.MouseYSpeed, Input.GetAxis("Mouse Y") * GlobalValue.MouseYSpeed);
        TransformTxt.text = string.Format("Transform\n" +
            "Position : {0}\n" +
            "Rotation : {1}\n" +
            "Scale : {2}",
            Player1.transform.position,
            Player1.transform.rotation,
            Player1.transform.localScale);

        GlobalValue.MouseXSpeed = MouseX_Slider.value;
        GlobalValue.MouseYSpeed = MouseY_Slider.value;

        Camera.main.fieldOfView = FOV_Slider.value;
        FOV_Slider.GetComponentInChildren<Text>().text = string.Format("FOV : {0:F0}",Camera.main.fieldOfView);
    }

    void CusorOnOff()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Cursor.visible = Cursor.visible == true ? false : true;
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
}
