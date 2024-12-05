using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko

{
    public class Attack : MonoBehaviour
    {
        public EUnitType UnitType = EUnitType.Player;
        public Animator Animator;
        public TpsUnitController TpsUnitController;
        public GameObject DamageBoxPrefab;
        public Vector3 Offset;
        public float AttackDelayTime = 1f;
        public float BoxLifeTime = 0.5f;

        private float _delayTimer;

        void Update()
        {
            _delayTimer -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                if (_delayTimer <= 0)
                {
                    // ������~����
                    TpsUnitController.IsNotPlay(AttackDelayTime);
                    // �A�j���[�V���������s
                    Animator.SetTrigger("Attack");
                    // �A���h�~
                    _delayTimer = AttackDelayTime;

                    // �_���[�W�{�b�N�X�𐶐�
                    var prefab = Instantiate(DamageBoxPrefab);
                    // �����������Ă�������ɉ��������W���v�Z
                    var pos =
                     transform.position +
                     transform.right * Offset.x +
                     transform.up * Offset.y +
                     transform.forward * Offset.z;
                    prefab.transform.position = pos; // ���W��ݒ�
                    prefab.transform.rotation = transform.rotation; // �v���C���[�̌����𔽉f 
                                                                    // �_���[�W����̃��j�b�g�^�C�v��ݒ�
                    if (prefab.TryGetComponent<DamageBox>(out var damageBox))
                        damageBox.AttackerType = EUnitType.Player;
                    // �w�莞�Ԍ�ɍ폜
                    Destroy(prefab, BoxLifeTime);

                }
            }
        }
    }

}