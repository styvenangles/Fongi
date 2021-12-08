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
    private Animator fongiAnims;
    private AudioSource fongiSounds;

    [SerializeField] GameObject genericHit;

    [SerializeField] AudioClip soundSaut;
    [SerializeField] AudioClip soundDash;

    public static fongiMain instance;
    private Vector3 isMoving;

    private float maxHp = 100f;
    private float timeLeft = 5F;
    public float currentHp;
    private float moveSpeed = 10;
    private float jumpVelocity = 25f;
    private float dashPower = 5f;
    private float directionHeaded = 0;
    private float moveValue;
    private int countJump = 0;
    private bool flipX = false;
    private bool isJumping = false;
    private bool hadDash = false;
    public bool isDead = false;
    private bool isFixed = false;

    private void Awake()
    {
        fongiControls = new FongiControls();
        fongiCollider = transform.GetComponent<BoxCollider2D>();
        fongiBody = transform.GetComponent<Rigidbody2D>();
        fongiSprite = transform.GetComponent<SpriteRenderer>();
        fongiAnims = transform.GetComponent<Animator>();
        fongiSounds = transform.GetComponent<AudioSource>();

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;

    }

    void OnHorizontal(InputValue value)
    {
        moveValue = value.Get<float>();
        if (moveValue < 0)
        {
            flipX = true;
            fongiSprite.flipX = flipX;
            genericHit.transform.position = new Vector3 (fongiBody.transform.position.x - 0.75F, fongiBody.transform.position.y + 0.5F, fongiBody.transform.position.z);

        }
        else if (moveValue > 0)
        {
            flipX = false;
            fongiSprite.flipX = flipX;
            genericHit.transform.position = new Vector3(fongiBody.transform.position.x + 0.75F, fongiBody.transform.position.y + 0.5F, fongiBody.transform.position.z);
        }
    }

    void OnDash()
    {
        if (hadDash == false)
        {
            hadDash = true;
            fongiSounds.clip = soundSaut;
            fongiSounds.Play();
            fongiAnims.SetBool("isDashing", true);
            transform.position += new Vector3(directionHeaded, 0) * dashPower;
            Invoke("setDash", 0.75F);
        }
    }

    void OnJump(InputValue value)
    {
        if (isJumping == false || countJump < 2)
        {
            fongiBody.velocity = Vector2.up * jumpVelocity;
            countJump++;
            fongiSounds.clip = soundSaut;
            fongiSounds.Play();
        }
        
    }

    void setDash()
    {
        hadDash = false;
        fongiAnims.SetBool("isDashing", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isJumping = false;
            fongiAnims.SetBool("isJumping", isJumping);
            countJump = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {

            isJumping = true;
            fongiAnims.SetBool("isJumping", isJumping);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        isMoving.x = transform.position.x;
    }
    
    public void TakeDamge(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        fongiCollider.size = fongiSprite.bounds.size;
        directionHeaded = moveValue;
        transform.Translate(new Vector2(moveValue, 0) * moveSpeed * Time.deltaTime);
        fongiAnims.SetFloat("Speed", Mathf.Abs(directionHeaded));
    }

    private void FixedUpdate()
    {

    }
}
