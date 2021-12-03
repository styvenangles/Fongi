using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class fongiMain : MonoBehaviour
{
    private FongiControls fongiControls;
    private BoxCollider2D fongiCollider;
    private Rigidbody2D fongiBody;
    private SpriteRenderer fongiSprite;

    private float maxHp = 100f;
    public float currentHp;
    private float moveSpeed = 10;
    private float jumpVelocity = 25f;
    private float dashPower = 5f;
    private float directionHeaded = 0;
    private float moveValue;
    private bool flipX = false;
    private bool isJumping = false;
    private bool hadDash = false;

    private void Awake()
    {
        fongiControls = new FongiControls();
        fongiCollider = transform.GetComponent<BoxCollider2D>();
        fongiBody = transform.GetComponent<Rigidbody2D>();
        fongiSprite = transform.GetComponent<SpriteRenderer>();

    }

    void OnHorizontal(InputValue value)
    {
        moveValue = value.Get<float>();
        if (moveValue < 0)
        {
            flipX = true;
            fongiSprite.flipX = flipX;
        }
        else if (moveValue > 0)
        {
            flipX = false;
            fongiSprite.flipX = flipX;
        }
    }

    void OnDash()
    {
        if (hadDash == false)
        {
            hadDash = true;
            transform.position += new Vector3(directionHeaded, 0) * dashPower;
            Invoke("setDash", 1);
        }
    }

    void OnJump(InputValue value)
    {
        if (isJumping == false)
        {
            fongiBody.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    void setDash()
    {
        hadDash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isJumping = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        directionHeaded = moveValue;
        transform.Translate(new Vector2(moveValue, 0) * moveSpeed * Time.deltaTime);
    }
    public void TakeDamge(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }

    private void FixedUpdate()
    {

    }
}
