using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        // cat�I�u�W�F�N�g���擾
        player = GameObject.Find("cat");
    }

    private void Update()
    {
        // �v���C���[�̍��W
        Vector3 playerPos = player.transform.position;
        // ���g�̍��W���㏑���iY���W����Player�̍��W�ŏ㏑���j
        transform.position = 
            new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
