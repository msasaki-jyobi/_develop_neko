using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace develop_neko
{

public class IgaguriController : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        //var power = new Vector3(0, 200, 2000);
        //Shoot(power);
    }

    public void Shoot(Vector3 dir)
    {
        
        if (TryGetComponent<Rigidbody>(out var rigid))
        {
            // ���[���h���W x:0 y:200 z:2000�̕����ɗ͂�������
            rigid.AddForce(dir);

            // �������猩�� x;0 y;200 z;2000�̕����ɗ͂�������
            //rigid.AddForce(
            //    transform.right * dir.x +
            //    transform.up * dir.y +
            //    transform.forward * dir.z
            //    );

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent<Rigidbody>(out var rigid))
            rigid.isKinematic = true;
        if (TryGetComponent<ParticleSystem>(out var particle))
            particle.Play();
    }

}
}
