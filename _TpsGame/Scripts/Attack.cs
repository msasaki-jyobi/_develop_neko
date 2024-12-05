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
                    // 操作を停止する
                    TpsUnitController.IsNotPlay(AttackDelayTime);
                    // アニメーションを実行
                    Animator.SetTrigger("Attack");
                    // 連続防止
                    _delayTimer = AttackDelayTime;

                    // ダメージボックスを生成
                    var prefab = Instantiate(DamageBoxPrefab);
                    // 自分が向いている方向に応じた座標を計算
                    var pos =
                     transform.position +
                     transform.right * Offset.x +
                     transform.up * Offset.y +
                     transform.forward * Offset.z;
                    prefab.transform.position = pos; // 座標を設定
                    prefab.transform.rotation = transform.rotation; // プレイヤーの向きを反映 
                                                                    // ダメージ判定のユニットタイプを設定
                    if (prefab.TryGetComponent<DamageBox>(out var damageBox))
                        damageBox.AttackerType = EUnitType.Player;
                    // 指定時間後に削除
                    Destroy(prefab, BoxLifeTime);

                }
            }
        }
    }

}