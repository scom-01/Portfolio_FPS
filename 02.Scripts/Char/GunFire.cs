using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("FireDown");
            anim.SetBool("Fire", true);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("FireUp");
            anim.SetBool("Fire", false);
        }
    }
}
