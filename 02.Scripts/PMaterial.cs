using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMaterial : MonoBehaviour
{
    [SerializeField]
    PhysicMaterial PM;
    CapsuleCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag != "Ground")
        {
            PM.dynamicFriction = 0;
        }
        else
        {
            PM.dynamicFriction = 0.6f;
        }
    }
}
