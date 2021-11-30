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

    [SerializeField] Rigidbody2D fongiBox;

    private float hpMax = 100;
    public float hpCurrent;
    private float impulsForce = -0.30F;
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

    }

    private IEnumerator WaitAndLockRandom(float xWaitedSeconds)
    {
        yield return new WaitForSeconds(xWaitedSeconds);
        randIsLocked = false;
        
    }

    private IEnumerator EnablePhase2()
    {
        if(hpCurrent <= 50)
        {
            moveDirection = bossBody.transform.position - fongiBox.transform.position;
            fongiBox.AddForce(moveDirection.normalized * impulsForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5F);

            isPhased = true;
        } else
        {
            yield return null;
        }
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

    private IEnumerator VerticalHit()
    {
        rand = Random.Range(0, 10);
        if (rand < 5)
        {
        }
        yield return null;
    }

    private IEnumerator PunchHit()
    {
        
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fongi"))
        {
            if (isPhased)
            {
                hitCount++;
            }
            hpCurrent -= 10;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fongi"))
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hpCurrent > 0)
        {
            StartCoroutine("VerticalHit");
            StartCoroutine("PunchHit");
            if (isPhased)
            {
                StopCoroutine("EnablePhase2");
                StartCoroutine("KnockBack");
                bossSprite.color = Color.red;
            }
            else
            {
                StartCoroutine("EnablePhase2");
            }
        }
    }
}
