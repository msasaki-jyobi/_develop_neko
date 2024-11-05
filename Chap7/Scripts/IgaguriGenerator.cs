using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko
{

    public class IgaguriGenerator : MonoBehaviour
    {
        [Header("�C�K�O����Prefab���w��")]
        [Tooltip("IgaguriController���A�^�b�`����Ă��邱��")]
        public GameObject igaguriPrefab;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject igaguri = Instantiate(igaguriPrefab);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f); // �Ԃ�Ray���f�o�b�O��ʂ�1�b�� �`��

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