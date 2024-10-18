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

        // 左右移動
        int key = 0;
        //if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        //if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        key = (int)Input.GetAxisRaw("Horizontal");

        // プレイヤーの速度 Abs: 値を+にする
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        // スピード制限
        if (speedx < maxWalkSpeed)
            rigid2D.AddForce(transform.right * key * walkFouce);

        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        // アニメーションの速度を反映させる
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
        // flag に触れたら
        if (collision.gameObject.name == "flag")
        {
            Debug.Log($"ゴール, " +
                $"Name:{collision.gameObject.name}, Tag:{collision.gameObject.tag}");

            SceneManager.LoadScene("ClearScene");
        }
    }

}
