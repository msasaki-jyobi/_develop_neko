using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed = 0;
    private Vector2 startPos;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 左マウスがクリックされたら
        if(Input.GetMouseButtonDown(0))
        {
            // マウスをクリックした座標
            startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // マウスを離した座標
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - startPos.x;
            speed = swipeLength / 500.0f;
        }

        // 座標を(X:0.2f, Y:0, Z:0)分 移動する
        transform.Translate(speed, 0, 0);

        // 減速
        speed *= 0.98f;
    }
}
