using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRay : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(this.transform.position, Camera.main.ScreenToWorldPoint(new Vector2(0, 1080))* 10);
        //Debug.DrawRay(this.transform.position, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) * 10);
        //Debug.DrawRay(this.transform.position, Camera.main.ViewportToWorldPoint(new Vector2(1920, 0)) * 10);
        //Debug.DrawRay(this.transform.position, Camera.main.ViewportToWorldPoint(new Vector2(1920, 1080)) * 10);
    }
}
