using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    private void Update()
    {
        // ¶ƒNƒŠƒbƒN‚³‚ê‚½‚ç
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene"); // GameScene‚É‰æ–Ê‘JˆÚ‚·‚é
    }
}
