using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagneRagdoll : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_Ragdoll;

    public Rigidbody spine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Change();
        }
    }

    public void Change()
    {
        CopyCharTransformToRagdoll(Player.transform, Player_Ragdoll.transform);

        Player.SetActive(Player.activeSelf ? false : true);
        Player_Ragdoll.SetActive(Player.activeSelf ? false : true);

        spine.AddForce(new Vector3(0, 0, 300), ForceMode.Impulse);
    }

    private void CopyCharTransformToRagdoll(Transform origin, Transform ragdoll)
    {
        for(int i = 0; i < origin.childCount; i++)
        {
            if(origin.childCount != 0)
            {
                CopyCharTransformToRagdoll(origin.GetChild(i), ragdoll.GetChild(i));
            }

            ragdoll.GetChild(i).localPosition = origin.GetChild(i).localPosition;
            ragdoll.GetChild(i).localRotation = origin.GetChild(i).localRotation;
        }
    }
}
