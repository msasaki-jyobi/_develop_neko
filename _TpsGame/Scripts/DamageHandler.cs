using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko
{

    public enum EUnitType
    {
        None,
        Player,
        Enemy,
    }

    public class DamageHandler : MonoBehaviour
    {
        public EUnitType UnitType;

        private void OnTriggerEnter(Collider other)
        {
            OnObjectHit(other.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnObjectHit(collision.gameObject);
        }
        private void OnDestroy()
        {
            Debug.Log($"破壊されました {gameObject.name}:{UnitType}");
        }

        private void OnObjectHit(GameObject hit)
        {
            // 触れたオブジェクトがDamageBoxコンポーネントを持っていた場合
            if (hit.TryGetComponent<DamageBox>(out var box))
            {
                if (box.AttackerType != UnitType) // 自分ではないTypeのダメージBoxの場合
                {
                    PlayEffect(box.DamageEffect);
                    // 自分も消滅
                    Destroy(gameObject);
                }
            }
        }
        private void PlayEffect(GameObject prefab, float destroyTime = 5f)
        {
            if (prefab == null) return;

            // エフェクトを再生（ループ解除)
            var effect =
                Instantiate(prefab, transform.position, Quaternion.identity);
            // 自分含め子オブジェクトまで全てチェック
            foreach (var child in effect.GetComponentsInChildren<Transform>())
                // パーティクルシステムがついている場合
                if (child.gameObject.TryGetComponent<ParticleSystem>(out var particle))
                    particle.loop = false;
            Destroy(effect, destroyTime);
        }
    }
}
