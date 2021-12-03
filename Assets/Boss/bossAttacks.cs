using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossAttacks : MonoBehaviour
{
    private Transform attackPunchPoint;
    private Transform attackVerticalPoint;
    private LayerMask playerLayer;

    private Coroutine co;

    private int attackDamage;
    private float randTryAttack;
    private float randWhichHit;
    private bool canAttack = true;
    private bool isRandLock = false;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Fongi");
        attackPunchPoint = GameObject.Find("PunchHit").transform;
        attackVerticalPoint = GameObject.Find("VerticalHit").transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void TryAttack(float randWhichAttack)
    {
        if (canAttack)
        {
            if (randWhichHit >= 31F)
            {
                Vector3 attackRange = new Vector3(1.5F, 1, 0);
                attackDamage = 10;
                co = StartCoroutine(performAttack(attackPunchPoint, attackRange, attackDamage, 3.5F));
            } else
            {
                Vector3 attackRange = new Vector3(2, 2, 0);
                attackDamage = 10;
                co = StartCoroutine(performAttack(attackVerticalPoint, attackRange, attackDamage, 4F));
            }
        } else
        {
            StopCoroutine(co);
            canAttack = !canAttack;
        }
    }

    private IEnumerator performAttack(Transform attackPoint, Vector3 attackRange, int attackDamage, float waitTime)
    {
        canAttack = !canAttack;
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Fongi"))
            {
                Debug.Log(attackPoint.name);
                enemy.GetComponent<fongiMain>().TakeDamge(attackDamage);
            } else
            {
                yield return null;
            }
        }
        yield return new WaitForSeconds(waitTime);
    }

   private IEnumerator randOrg(float lowRange, float highRange)
    {
        randTryAttack = Random.Range(lowRange, highRange);
        randWhichHit = Random.Range(lowRange, highRange);
        yield return new WaitForSeconds(2F);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRandLock == false)
        {
            StartCoroutine(randOrg(0F, 100F));
            Debug.Log(randTryAttack);
            Debug.Log(randTryAttack <= 5F);
            if (randTryAttack <= 5F)
            {
/*                isRandLock = !isRandLock;
*/                TryAttack(randWhichHit);
            }

        }
        else
        {
            return; 
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPunchPoint != null)
        {
            Vector3 attackRange = new Vector3(1.5F, 1, 0);
            Gizmos.DrawWireCube(attackPunchPoint.position, attackRange);
        }
        else
        {
            return;
        }

        if (attackVerticalPoint != null)
        {
            Vector3 attackRange = new Vector3(2, 2, 0);
            Gizmos.DrawWireCube(attackVerticalPoint.position, attackRange);
        }
        else
        {
            return;
        }
    }
}
