using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSControl : MonoBehaviour
{
    private CharZoom curZoom;           //현재 배율
    private CharZoom oldZoom;           //이전 배율

    private Vector3 curPos;             //현재 총기 위치
    private Vector3 oldPos;             //이전 총기 위치

    private float curFOV;               //현재 FOV
    private float oldFOV;               //이전 FOV

    [SerializeField]    private Camera ZoomCamera;          //배율 카메라
    [SerializeField]    private RawImage ZoomRenderImg;     //배율 카메라 랜더텍스쳐이미지

    //각 배율 별 총기 위치
    [SerializeField]    private Vector3 IdlePos;
    [SerializeField]    private Vector3 x1Pos;
    [SerializeField]    private Vector3 x2Pos;
    [SerializeField]    private Vector3 x4Pos;
    [SerializeField]    private Vector3 x8Pos;

    [SerializeField]    private float   Idle_FOV;
    [SerializeField]    private float   x1_FOV;
    [SerializeField]    private float   x2_FOV;
    [SerializeField]    private float   x4_FOV;
    [SerializeField]    private float   x8_FOV;

    private void Awake()
    {
        Idle_FOV = 60;
        x1_FOV = 50;
        x2_FOV = 30;
        x4_FOV = 15;
        x8_FOV = 7.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        curZoom = CharZoom.idle;
        oldZoom = CharZoom.x1;
        curPos = IdlePos;
        oldPos = x1Pos;
        curFOV = Idle_FOV;
        oldFOV = x1_FOV;

        ZoomRenderImg.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        IsZoom();
        Zoom();
        //Debug.Log(curZoom);
    }

    void IsZoom()
    {
        if(curZoom == CharZoom.idle)
        {
            if(Input.GetMouseButtonDown(1))     //우클릭
            {
                curZoom = oldZoom;
                curPos = oldPos;
                curFOV = oldFOV;
            }
            return;
        }
        else if(curZoom == CharZoom.x1)
        {
            if (Input.GetMouseButtonDown(1))     //우클릭
            {
                oldZoom = curZoom;
                curZoom = CharZoom.idle;
                oldPos = curPos;
                curPos = IdlePos;
                oldFOV = curFOV;
                curFOV = Idle_FOV;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                curZoom = CharZoom.x2;
                curPos = x2Pos;
                curFOV = x2_FOV;
            }
            return;
        }
        else if (curZoom == CharZoom.x2)
        {
            if (Input.GetMouseButtonDown(1))     //우클릭
            {
                oldZoom = curZoom;
                curZoom = CharZoom.idle;
                oldPos = curPos;
                curPos = IdlePos;
                oldFOV = curFOV;
                curFOV = Idle_FOV;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                curZoom = CharZoom.x4;
                curPos = x4Pos;
                curFOV = x4_FOV;
            }
            return;
        }
        else if (curZoom == CharZoom.x4)
        {
            if (Input.GetMouseButtonDown(1))     //우클릭
            {
                oldZoom = curZoom;
                curZoom = CharZoom.idle;
                oldPos = curPos;
                curPos = IdlePos;
                oldFOV = curFOV;
                curFOV = Idle_FOV;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                curZoom = CharZoom.x8;
                curPos = x8Pos;
                curFOV = x8_FOV;
            }
            return;
        }
        else if (curZoom == CharZoom.x8)
        {
            if (Input.GetMouseButtonDown(1))     //우클릭
            {
                oldZoom = curZoom;
                curZoom = CharZoom.idle;
                oldPos = curPos;
                curPos = IdlePos;
                oldFOV = curFOV;
                curFOV = Idle_FOV;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                curZoom = CharZoom.x1;
                curPos = x1Pos;
                curFOV = x1_FOV;
            }
            return;
        }
    }

    void Zoom()
    {
        transform.localPosition = Vector3.Lerp(this.transform.localPosition, curPos, GlobalValue.deltaTime * 5f);
        ZoomCamera.fieldOfView = curFOV;
    }
}
