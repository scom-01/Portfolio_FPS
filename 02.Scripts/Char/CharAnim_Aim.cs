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
    }

    void Look_Forward()
    {
        Upper_Chest.LookAt(Target.position);
        Vector3 vec = Upper_Chest.forward.normalized;
        vec.y = 0;
        Debug.DrawRay(Upper_Chest.position, vec * 2, Color.green);
        vec = Right_hand.up.normalized;
        vec.y = 0;
        Debug.DrawRay(Right_hand.position, vec * 2, Color.blue);
        
        //Upper_Chest.LookAt(Target.position);
        //spine.rotation = spine.rotation * Quaternion.Euler(Target.position - this.transform.position);
    }
}
