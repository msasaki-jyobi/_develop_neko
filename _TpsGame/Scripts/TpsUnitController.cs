
using System;
using System.Collections;
using UnityEngine;

namespace develop_neko
{
    public class TpsUnitController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _dashRange = 1.5f;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Animator _animator;

        // private Input Parameter
        public float InputX;
        public float InputY;
        private Vector3 _tpsVelocity;
        private Quaternion _targetRotation;
        private float _rotateSpeed = 600f;

        private Camera _camera;

        private float _defaultSpeed;
        private bool _isNotInput;

        void Start()
        {
            _defaultSpeed = _speed;
            //　カーソルを中央に固定（ESCで解除）
            Cursor.lockState = CursorLockMode.Locked;
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isNotInput) return;

            GetInput();
            Rotation();
            Motion();
        }

        private void FixedUpdate()
        {
            // 移動方向(_tpsVelocity) * Speed で上書きする
            _rigidBody.velocity =
                new Vector3(_tpsVelocity.x * _speed, _rigidBody.velocity.y, _tpsVelocity.z * _speed);
        }

        private void GetInput()
        {
            InputX = Input.GetAxis("Horizontal");
            InputY = Input.GetAxis("Vertical");

            var dash = _defaultSpeed * 1.5f;
            _speed =
                Input.GetKey(KeyCode.LeftShift) ? dash : _defaultSpeed;
        }

        private void Rotation()
        {
            float rotY = _camera.transform.rotation.eulerAngles.y;

            // カメラから見て方角を決める　normalized：入力値を一定のベクトル(1)で取得する
            // 現在のカメラの向き（rotY）を基準に、
            // Y軸(Vector3.up)周りの回転（水平回転） を表す回転（Quaternion）を作る
            // カメラを基準に入力された方向のベクトルを取得する
            var tpsHorizontalRotation = Quaternion.AngleAxis(rotY, Vector3.up);
            _tpsVelocity = tpsHorizontalRotation * new Vector3(InputX, 0, InputY).normalized;

            // ユニットの回転スピード
            var rotationSpeed = _rotateSpeed * Time.deltaTime;

            // 移動方向(_tpsVelocity)を向く為の回転値を計算
            if (_tpsVelocity.magnitude > 0.5f)
            {
                // 目標角度を取得
                _targetRotation = Quaternion.LookRotation(_tpsVelocity, Vector3.up);
            }
            // なめらかに振り向く
            // RotateTowards：(現在の角度)から(目標の回転)へ（指定された速度）で滑らかに回転する
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rotationSpeed);

            Debug.Log($"tpsVelocity; " +
                $"|rotationSpeed: " +
                $"|tpsVelocity.magnitude" +
                $"|targetRotation //{_tpsVelocity}//{_tpsVelocity.magnitude}//{rotationSpeed}//{_targetRotation},//{tpsHorizontalRotation}" +
                $"");
        }

        private void Motion()
        {
            // 速度をAnimatorに反映する
            _animator?.SetFloat("Speed", _tpsVelocity.magnitude * _speed, 0.02f, Time.deltaTime);
        }


        public void IsNotPlay(float time)
        {
            if (_isNotInput) return;

            _isNotInput = true;

            // 追加処理
            _tpsVelocity = Vector3.zero; // 入力値をリセット
            _rigidBody.velocity = Vector3.zero; // 速度をリセット

            StartCoroutine(Wait(time, () =>
            {
                _isNotInput = false;
            }));
        }

        private IEnumerator Wait(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action();
        }
    }
}
