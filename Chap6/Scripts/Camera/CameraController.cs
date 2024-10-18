using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        // catオブジェクトを取得
        player = GameObject.Find("cat");
    }

    private void Update()
    {
        // プレイヤーの座標
        Vector3 playerPos = player.transform.position;
        // 自身の座標を上書き（Y座標だけPlayerの座標で上書き）
        transform.position = 
            new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
