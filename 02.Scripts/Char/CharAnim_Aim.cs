using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim_Aim : MonoBehaviour
{
    public Transform Target;

    public GameObject Gun;
    private Vector3 Gun_Idle_Pos;
    private Vector3 Gun_Idle_Rot;
    private Vector3 Gun_Fire_Pos;
    private Vector3 Gun_Fire_Rot;

    private Animator anim;
    private Transform Upper_Chest;    //아바타의 상체
    private Transform Right_hand;    //아바타의 오른손
    private Transform Left_hand;    //아바타의 오른손
    private Transform Right_Shoulder;    //아바타의 오른어깨
    private Transform Left_Shoulder;    //아바타의 왼어깨
    
    private bool isFire = false;
    private Vector3 velocity = Vector3.zero;
    private Vector3 Upper_Chest_Vec;
    private Vector3 Right_hand_Vec;
    private Vector3 Gun_Point;
    // Start is called before the first frame update

    private void Awake()
    {
        Gun_Idle_Pos = new Vector3(0.056f, 0.25f, 0.041f);
        Gun_Idle_Rot = new Vector3(61.331f, -96.23501f, 3.613f);

        Gun_Fire_Pos = new Vector3(0.0089f, 0.272f, 0.0427f);
        Gun_Fire_Rot = new Vector3(82.367f, -126.921f, -35.09f);

        Gun.transform.localPosition = Gun_Idle_Pos;
        Gun.transform.localRotation = Quaternion.Euler(Gun_Idle_Rot);

        anim = GetComponent<Animator>();
        Upper_Chest = anim.GetBoneTransform(HumanBodyBones.UpperChest);
        Right_hand = anim.GetBoneTransform(HumanBodyBones.RightIndexProximal);
        Left_hand = anim.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
        Right_Shoulder = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
        Left_Shoulder = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);

        Gun_Point = (Right_hand.transform.localPosition - Left_hand.transform.localPosition) / 2;
        Gun.transform.localPosition = Gun_Point;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Look_Forward();
        Debug.DrawRay(Gun.transform.position, Gun.transform.forward * -2, Color.black);

        if(Input.GetMouseButton(0))
        {
            Fire();
        }
        else
        {
            Idle();
        }
    }

    void Look_Forward()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2f);
        //Debug.Log(Vector3.Dot(Camera.main.transform.forward, Upper_Chest.forward));
        Vector3 alpha = Camera.main.transform.forward;
        alpha.y = 0;
        Vector3 Beta = Right_hand.up;
        Beta.y = 0;

        float theta = Mathf.Acos(Vector3.Dot(alpha, Beta) / Vector3.Magnitude(alpha) / Vector3.Magnitude(Beta)) * Mathf.Rad2Deg;
        //Debug.Log(theta);
        //Debug.DrawRay(transform.position + Right_hand.up * 2f, Target.transform.position - (transform.position + Right_hand.up * 2f), Color.green);
        //Debug.DrawRay(Target.position, Target.transform.right * Mathf.Sin(theta));
        //Upper_Chest.LookAt(Target.position + Target.transform.right * Mathf.Sin(theta));
        //Upper_Chest.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(new Vector3(20, 0, 0));
        Debug.DrawRay(Left_Shoulder.position, Camera.main.transform.forward * 3f, Color.cyan);
        Debug.DrawRay(Right_Shoulder.position, Camera.main.transform.forward * 3f, Color.cyan);

        Right_Shoulder.rotation = Right_Shoulder.rotation;// + );
        Left_Shoulder.rotation = Left_Shoulder.rotation * Quaternion.Euler(Camera.main.transform.forward);// + );
        //Debug.Log(Camera.main.transform.eulerAngles);
        //Right_Shoulder.rotation = Camera.main.transform.rotation* Quaternion.Euler(new Vector3(135,120,45));// + );
        //Debug.Log(Target.transform.right * Mathf.Sin(theta));
        Vector3 vec = Upper_Chest.forward.normalized;
        vec.y = 0;
        Debug.DrawRay(Upper_Chest.position, vec * 2, Color.green);
        vec = Right_hand.up.normalized;
        vec.y = 0;
        Debug.DrawRay(Right_hand.position, vec * 2, Color.blue);
        
        //Upper_Chest.LookAt(Target.position);
        //spine.rotation = spine.rotation * Quaternion.Euler(Target.position - this.transform.position);
    }

    void Fire()
    {
        if(Gun.transform.localPosition == Gun_Fire_Pos && Gun.transform.localRotation == Quaternion.Euler(Gun_Fire_Rot))
        {
            return;
        }
        //isFire = true;
        //yield return new WaitForSeconds(1.0f);
        Gun.transform.localPosition = Vector3.SmoothDamp(Gun.transform.localPosition, Gun_Fire_Pos, ref velocity, 0.3f);
        //Gun.transform.localRotation = Quaternion.Euler(Gun_Fire_Rot);

        Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Quaternion.Euler(Gun_Fire_Rot), GlobalValue.deltaTime * 5f);
    }

    void Idle()
    {
        if (Gun.transform.localPosition == Gun_Idle_Pos && Gun.transform.localRotation == Quaternion.Euler(Gun_Idle_Rot))
        {
            return;
        }
        //isFire = false;
        //yield return new WaitForSeconds(1.0f);
        //Gun.transform.localPosition = Gun_Idle_Pos;
        Gun.transform.localPosition = Vector3.SmoothDamp(Gun.transform.localPosition, Gun_Idle_Pos, ref velocity, 0.3f);
        //Gun.transform.localRotation = Quaternion.Euler(Gun_Idle_Rot);
        Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Quaternion.Euler(Gun_Idle_Rot), GlobalValue.deltaTime * 5f);
    }
}
