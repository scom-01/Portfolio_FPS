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
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("Fire", true);
        }
        else
        {
            anim.SetBool("Fire", false);
        }
    }
}
