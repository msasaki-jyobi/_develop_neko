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
            Debug.Log($"�j�󂳂�܂��� {gameObject.name}:{UnitType}");
        }

        private void OnObjectHit(GameObject hit)
        {
            // �G�ꂽ�I�u�W�F�N�g��DamageBox�R���|�[�l���g�������Ă����ꍇ
            if (hit.TryGetComponent<DamageBox>(out var box))
            {
                if (box.AttackerType != UnitType) // �����ł͂Ȃ�Type�̃_���[�WBox�̏ꍇ
                {
                    PlayEffect(box.DamageEffect);
                    // ����������
                    Destroy(gameObject);
                }
            }
        }
        private void PlayEffect(GameObject prefab, float destroyTime = 5f)
        {
            if (prefab == null) return;

            // �G�t�F�N�g���Đ��i���[�v����)
            var effect =
                Instantiate(prefab, transform.position, Quaternion.identity);
            // �����܂ߎq�I�u�W�F�N�g�܂őS�ă`�F�b�N
            foreach (var child in effect.GetComponentsInChildren<Transform>())
                // �p�[�e�B�N���V�X�e�������Ă���ꍇ
                if (child.gameObject.TryGetComponent<ParticleSystem>(out var particle))
                    particle.loop = false;
            Destroy(effect, destroyTime);
        }
    }
}
