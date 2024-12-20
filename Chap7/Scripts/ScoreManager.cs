using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko
{

    public class ScoreManager : MonoBehaviour
    {
        public int saveValue = 3;
        public int loadValue;

        // Start is called before the first frame update
        void Start()
        {
            var load = PlayerPrefs.GetInt("Igaguri"); // Key:Igaguriの値を取得
            Debug.Log($"load: {load}");
            PlayerPrefs.SetInt("Igaguri", saveValue); // Key:Igaguriに値を保存

            PlayerPrefs.Save(); // 確実に保存する
        }
    }
}
