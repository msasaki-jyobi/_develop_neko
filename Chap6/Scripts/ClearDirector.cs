using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    private void Update()
    {
        // ���N���b�N���ꂽ��
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene"); // GameScene�ɉ�ʑJ�ڂ���
    }
}
