using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko
{

    public class IgaguriGenerator : MonoBehaviour
    {
        [Header("イガグリのPrefabを指定")]
        [Tooltip("IgaguriControllerがアタッチされていること")]
        public GameObject igaguriPrefab;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject igaguri = Instantiate(igaguriPrefab);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f); // 赤いRayをデバッグ画面に1秒間 描画

                if (igaguri.TryGetComponent<IgaguriController>(out var controller))
                {
                    var power = ray.direction * 2000f;
                    Debug.Log($"rayDirection:{ray.direction}");
                    controller.Shoot(power);
                }

            }
        }
    }
}