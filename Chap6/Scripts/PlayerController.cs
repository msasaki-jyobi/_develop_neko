using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkFouce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
        {
            animator.SetTrigger("JumpTrigger");
            rigid2D.AddForce(transform.up * jumpForce);
        }

        // ���E�ړ�
        int key = 0;
        //if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        key = (int)Input.GetAxisRaw("Horizontal");

        // �v���C���[�̑��x Abs: �l��+�ɂ���
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        // �X�s�[�h����
        if (speedx < maxWalkSpeed)
            rigid2D.AddForce(transform.right * key * walkFouce);

        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        // �A�j���[�V�����̑��x�𔽉f������
        if (rigid2D.velocity.y == 0)
        {
            animator.speed = speedx / 2.0f;
        }
        else
        {
            animator.speed = 1f;
        }

        if (transform.position.y < -10)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // flag �ɐG�ꂽ��
        if (collision.gameObject.name == "flag")
        {
            Debug.Log($"�S�[��, " +
                $"Name:{collision.gameObject.name}, Tag:{collision.gameObject.tag}");

            SceneManager.LoadScene("ClearScene");
        }
    }

}
