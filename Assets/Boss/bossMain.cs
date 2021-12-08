using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossMain : MonoBehaviour
{
    private SpriteRenderer bossSprite;
    public Rigidbody2D bossBody;
    private BoxCollider2D bossCollider;
    private AudioSource bossSounds;
    private GameObject bossA;
    private bossAttacks bossAttacks;

    [SerializeField] public Rigidbody2D fongiBox;

    [SerializeField] AudioClip soundHit;
    [SerializeField] AudioClip soundDeath;

    private float hpMax = 100;
    public float hpCurrent;
    public float impulsForce = 100F;
    private float hitCount = 0;
    private float timeRemaining = 3.00F;

    public Vector3 moveDirection;

    public bool isPhased = false;
    public bool isDead = false;
    public bool knockActive = false;
    private bool flipX = false;

    private void Awake()
    {
        hpCurrent = hpMax;
        bossSprite = transform.GetComponent<SpriteRenderer>();
        bossBody = transform.GetComponent<Rigidbody2D>();
        bossCollider = transform.GetComponent<BoxCollider2D>();
        bossSounds = transform.GetComponent<AudioSource>();
        bossA = GameObject.Find("Boss");
        bossAttacks = bossA.GetComponent<bossAttacks>();

    }
    private void knockBackIniciator(bool state)
    {
        if(state == true)
        {
            knockActive = true;
        }
    }

    private IEnumerator FlipAxe()
    {
        while (isDead != true)
        {
            if (transform.position.x < fongiBox.position.x)
            {
                flipX = true;
                bossSprite.flipX = flipX; 
                bossAttacks.attackPunchPoint.transform.position = new Vector3(bossBody.transform.position.x + 3.66F, bossBody.transform.position.y - 1.324F, bossBody.transform.position.z);
                bossAttacks.attackVerticalPoint.transform.position = new Vector3(bossBody.transform.position.x + 4.6F, bossBody.transform.position.y - 0.96F, bossBody.transform.position.z);
                yield return null;
            }
            else if (transform.position.x > fongiBox.position.x)
            {
                flipX = false;
                bossSprite.flipX = flipX;
                bossAttacks.attackPunchPoint.transform.position = new Vector3(bossBody.transform.position.x - 3.66F, bossBody.transform.position.y - 1.324F, bossBody.transform.position.z);
                bossAttacks.attackVerticalPoint.transform.position = new Vector3(bossBody.transform.position.x - 4.6F, bossBody.transform.position.y - 0.96F, bossBody.transform.position.z);
                yield return null;
            }
        }
        yield return null;
    }

    private IEnumerator EnablePhase2()
    {
        while (hpCurrent > 50)
        {
            yield return null;
        }

        isPhased = true;

    }

    private IEnumerator KnockBack()
    {
        while(knockActive == false)
        {
            yield return null;
        }

        moveDirection = fongiBox.transform.position - bossBody.transform.position;
        moveDirection.z = 0;
        fongiBox.AddForce(moveDirection.normalized * impulsForce, ForceMode2D.Impulse);

    }
    
    public void TakeDamge(int damage)
    {
        bossSounds.clip = soundHit;
        bossSounds.Play();

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0F)
        {
            timeRemaining = 3.00F;
            hitCount = 0;
        }
        else if (hitCount < 2)
        {
            hpCurrent -= damage;
            hitCount++;
        }
        else
        {
            moveDirection = fongiBox.transform.position - bossBody.transform.position;
            moveDirection.z = 0;
            fongiBox.AddForce(moveDirection.normalized * impulsForce, ForceMode2D.Impulse);
            hitCount = 0;
        }

        if (hpCurrent <= 0 )
        {
            isDead = true;
            StopAllCoroutines();
            Die();
        }
    }

    private void Die()
    {
        GameObject.Destroy(gameObject);
        bossSounds.clip = soundDeath;
        bossSounds.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnablePhase2");
        StartCoroutine("KnockBack");
        StartCoroutine("FlipAxe");
    }

    // Update is called once per frame
    void Update()
    {
        bossCollider.size = bossSprite.bounds.size / 2;

        if (isPhased)
        {
            StopCoroutine("EnablePhase2");
            knockBackIniciator(true);
        }
    }
}
