using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    Image CrossImg;
    // Start is called before the first frame update
    void Start()
    {
        CrossImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CrossImg.rectTransform.position = new Vector3(CrossImg.canvas.renderingDisplaySize.x / 2, CrossImg.canvas.renderingDisplaySize.y / 2, 0);
        CrossImg.rectTransform.sizeDelta = new Vector2(GlobalValue.CH_Width, GlobalValue.CH_Height);
        CrossImg.fillAmount = GlobalValue.CH_Height_Fill;
        //Debug.Log(CrossImg.rectTransform.sizeDelta.x);
        //CrossImg.rectTransform.pivot.y
    }
}
