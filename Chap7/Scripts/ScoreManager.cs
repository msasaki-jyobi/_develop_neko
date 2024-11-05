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
            var load = PlayerPrefs.GetInt("Igaguri"); // Key:Igaguri‚Ì’l‚ðŽæ“¾
            Debug.Log($"load: {load}");
            PlayerPrefs.SetInt("Igaguri", saveValue); // Key:Igaguri‚É’l‚ð•Û‘¶

            PlayerPrefs.Save(); // ŠmŽÀ‚É•Û‘¶‚·‚é
        }
    }
}
