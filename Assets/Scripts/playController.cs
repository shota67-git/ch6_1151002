using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Animator animator;
    public float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float walkMaxSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2d.AddForce(transform.up * jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(rigid2d.velocity.x);
        if(speedx < walkMaxSpeed)                
                rigid2d.AddForce(transform.right * key * walkForce);
        if(key != 0)
        {
            transform.localScale = new Vector3(key*1.5f, 1.5f, 1.5f);
        }
        animator.speed = speedx / 2.0f;
        if (transform.position.y < -5.8f)
        {
            SceneManager.LoadScene("ch6_GameScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("EndScene");
    }
}
