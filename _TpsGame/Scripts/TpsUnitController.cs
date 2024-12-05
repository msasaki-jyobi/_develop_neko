
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
            //�@�J�[�\���𒆉��ɌŒ�iESC�ŉ����j
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
            // �ړ�����(_tpsVelocity) * Speed �ŏ㏑������
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

            // �J�������猩�ĕ��p�����߂�@normalized�F���͒l�����̃x�N�g��(1)�Ŏ擾����
            // ���݂̃J�����̌����irotY�j����ɁA
            // Y��(Vector3.up)����̉�]�i������]�j ��\����]�iQuaternion�j�����
            // �J��������ɓ��͂��ꂽ�����̃x�N�g�����擾����
            var tpsHorizontalRotation = Quaternion.AngleAxis(rotY, Vector3.up);
            _tpsVelocity = tpsHorizontalRotation * new Vector3(InputX, 0, InputY).normalized;

            // ���j�b�g�̉�]�X�s�[�h
            var rotationSpeed = _rotateSpeed * Time.deltaTime;

            // �ړ�����(_tpsVelocity)�������ׂ̉�]�l���v�Z
            if (_tpsVelocity.magnitude > 0.5f)
            {
                // �ڕW�p�x���擾
                _targetRotation = Quaternion.LookRotation(_tpsVelocity, Vector3.up);
            }
            // �Ȃ߂炩�ɐU�����
            // RotateTowards�F(���݂̊p�x)����(�ڕW�̉�])�ցi�w�肳�ꂽ���x�j�Ŋ��炩�ɉ�]����
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rotationSpeed);

            Debug.Log($"tpsVelocity; " +
                $"|rotationSpeed: " +
                $"|tpsVelocity.magnitude" +
                $"|targetRotation //{_tpsVelocity}//{_tpsVelocity.magnitude}//{rotationSpeed}//{_targetRotation},//{tpsHorizontalRotation}" +
                $"");
        }

        private void Motion()
        {
            // ���x��Animator�ɔ��f����
            _animator?.SetFloat("Speed", _tpsVelocity.magnitude * _speed, 0.02f, Time.deltaTime);
        }


        public void IsNotPlay(float time)
        {
            if (_isNotInput) return;

            _isNotInput = true;

            // �ǉ�����
            _tpsVelocity = Vector3.zero; // ���͒l�����Z�b�g
            _rigidBody.velocity = Vector3.zero; // ���x�����Z�b�g

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
