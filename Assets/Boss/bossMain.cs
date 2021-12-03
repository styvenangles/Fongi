using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossMain : MonoBehaviour
{
    private SpriteRenderer bossSprite;
    private Rigidbody2D bossBody;
    private RaycastHit2D rayCastGen;
    private BoxCollider2D bossCollider;
    private AudioSource bossSounds;

    [SerializeField] Rigidbody2D fongiBox;

    [SerializeField] AudioClip soundHit;
    [SerializeField] AudioClip soundDeath;

    private float hpMax = 100;
    public float hpCurrent;
    private float impulsForce = 5F;
    private float hitCount = 1;
    private float timeRemaining = 3.00F;
    private float rand;

    private Vector3 moveDirection;

    private bool isPhased = false;
    private bool randIsLocked = false;

    private void Awake()
    {
        hpCurrent = hpMax;
        bossSprite = transform.GetComponent<SpriteRenderer>();
        bossBody = transform.GetComponent<Rigidbody2D>();
        bossCollider = transform.GetComponent<BoxCollider2D>();
        bossSounds = transform.GetComponent<AudioSource>();

    }
    private void knockBackIniciator(int number)
    {
        for (int i = 0; i < number; i++)
        {

            moveDirection = bossBody.transform.position - fongiBox.transform.position;
            fongiBox.AddForce(moveDirection.normalized * impulsForce);

        }
    }
    private IEnumerator WaitAndLockRandom(float xWaitedSeconds)
    {
        yield return new WaitForSeconds(xWaitedSeconds);
        randIsLocked = false;
        
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
        timeRemaining -= Time.deltaTime;
        if (randIsLocked == false)
        {
            rand = Random.Range(0F, 100F);
            if (rand > 95.99F)
            {
                moveDirection = bossBody.transform.position - fongiBox.transform.position;
                fongiBox.AddForce(moveDirection.normalized * impulsForce, ForceMode2D.Impulse);
                Debug.Log("Pushed by Luck!!!");
                yield return new WaitForSeconds(2F);
                /*randIsLocked = true;*/
/*                StartCoroutine(WaitAndLockRandom(0.5F));
*/            }
        }
        if (timeRemaining < 0)
        {
            timeRemaining = 3.00F;
            hitCount = 1;
        } else if (hitCount > 3)
        {
            moveDirection = bossBody.transform.position - fongiBox.transform.position;
            fongiBox.AddForce(moveDirection.normalized * impulsForce, ForceMode2D.Impulse);
            Debug.Log("Pushed by hits!!");
            yield return new WaitForSeconds(0.5F);
/*            hitCount = 1;
*/        }
        yield return null;
    }
    
    public void TakeDamge(int damage)
    {
        bossSounds.clip = soundHit;
        bossSounds.Play();
        hpCurrent -= damage;

        if (hpCurrent <= 0 )
        {
            StopAllCoroutines();
            Die();
        }
    }

    private void Die()
    {
        bossSounds.clip = soundDeath;
        bossSounds.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnablePhase2");
    }

    // Update is called once per frame
    void Update()
    {
        bossCollider.size = bossSprite.bounds.size / 2;
        if (hpCurrent > 0)
        {
            if (isPhased)
            {
                StopCoroutine("EnablePhase2");
                StartCoroutine("KnockBack");
                bossSprite.color = Color.red;
            }
            else
            {
            }
        }
    }
}
