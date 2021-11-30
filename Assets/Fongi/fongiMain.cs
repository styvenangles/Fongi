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

    private float moveSpeed = 10;
    private float jumpVelocity = 25f;
    private float moveValue;
    private bool flipX = false;
    private bool isJumping = false;

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

    void OnJump(InputValue value)
    {
        if (isJumping == false)
        {
            fongiBody.velocity = Vector2.up * jumpVelocity;
        }
        
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

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(moveValue, 0) * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {

    }
}
