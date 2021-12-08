using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float _lrSpeed = 6;
    [SerializeField] float _ratSpeed = 10;
    [SerializeField] float _jumpSpeed = 5;
    [SerializeField] float _ratJumpSpeed = 8;
    [SerializeField] Transform GroundPos;
    [SerializeField] Transform RatPos;
    [SerializeField] AudioSource jumpSound;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isRatted = false;
    private float jumpTimer = 0f;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircleAll(GroundPos.position, .05f, LayerMask.GetMask("Ground")).Length > 0 && jumpTimer >= .25f) {
            isGrounded = true;
            jumpTimer = 0;
        }
        if (Physics2D.OverlapCircleAll(RatPos.position, .05f, LayerMask.GetMask("Rat")).Length > 0) {
            isRatted = true;
        }
        Move();
        Jump();
        Death();
    }

    void Move() {
        float dir = Input.GetAxis("Horizontal");
        if (isRatted) {
            rb.velocity = new Vector3(dir * _ratSpeed, rb.velocity.y, 0);
        }
        else {
            rb.velocity = new Vector3(dir * _lrSpeed, rb.velocity.y, 0);
        }

        if (dir < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(dir > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
    void Jump() {
        if (Input.GetButtonDown("Jump") && isRatted) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, _ratJumpSpeed, 0);
            jumpSound.Play();
            isGrounded = false;
            isRatted = false;
        }
        else if (Input.GetButtonDown("Jump") && isGrounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, _jumpSpeed, 0);
            jumpSound.Play();
            isGrounded = false;
            isRatted = false;
        }

        if (isGrounded == false) {
            jumpTimer += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(GroundPos.position, .05f);
        Gizmos.DrawSphere(RatPos.position, .025f);
    }

    void Death() {
        if (GroundPos.position.y < -5) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
