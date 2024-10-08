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
        // ���}�E�X���N���b�N���ꂽ��
        if(Input.GetMouseButtonDown(0))
        {
            // �}�E�X���N���b�N�������W
            startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // �}�E�X�𗣂������W
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - startPos.x;
            speed = swipeLength / 500.0f;
        }

        // ���W��(X:0.2f, Y:0, Z:0)�� �ړ�����
        transform.Translate(speed, 0, 0);

        // ����
        speed *= 0.98f;
    }
}
