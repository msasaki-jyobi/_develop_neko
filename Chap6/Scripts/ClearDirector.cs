using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    private void Update()
    {
        // 左クリックされたら
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene"); // GameSceneに画面遷移する
    }
}
