using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossAttacks : MonoBehaviour
{
    [SerializeField] public Transform attackPunchPoint;
    [SerializeField] public Transform attackVerticalPoint;

    private LayerMask playerLayer;
    private AudioSource bossSounds;
    private Animator bossAnims;
    private GameObject bossM;
    private bossMain bossMain;
    private GameObject fongi;
    private fongiMain fongiMain;

    [SerializeField] AudioClip soundStomp;
    [SerializeField] AudioClip soundPunch;

    private int attackDamage;
    public float randWhichHit;
    private float missCount = 1;
    private Vector2 inRange;
    private bool isRandLock = false;
    public bool isActive;

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Fongi");
        bossSounds = transform.GetComponent<AudioSource>();
        bossAnims = transform.GetComponent<Animator>();
        bossM = GameObject.Find("Boss");
        bossMain = bossM.GetComponent<bossMain>();
        fongi = GameObject.Find("Fongi2");
        fongiMain = fongi.GetComponent<fongiMain>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (!bossMain.isDead)
        {
            while (isActive == false)
            {
                yield return null;
            }
            StartCoroutine(randOrg(0F, 100F));
            if (isRandLock)
            {
                if (randWhichHit >= 95F)
                {
                    bossMain.moveDirection = bossMain.fongiBox.transform.position - bossMain.bossBody.transform.position;
                    bossMain.moveDirection.z = 0;
                    bossMain.fongiBox.AddForce(bossMain.moveDirection.normalized * bossMain.impulsForce, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(3F);
                }
                else if (randWhichHit >= 31F)
                {
                    bossSounds.clip = soundPunch;
                    bossSounds.Play();
                    Vector3 attackRange = new Vector3(3.5F, 2, 0);
                    attackDamage = 10;
                    performAttack(attackPunchPoint, attackRange, attackDamage);
                    yield return new WaitForSeconds(3F);
                }
                else
                {
                    bossAnims.SetBool("isStomping", true);
                    bossSounds.clip = soundStomp;
                    bossSounds.Play();
                    Vector3 attackRange = new Vector3(4, 9, 0);
                    attackDamage = 10;
                    performAttack(attackVerticalPoint, attackRange, attackDamage);
                    yield return new WaitForSeconds(1F);
                    bossAnims.SetBool("isStomping", false);
                    yield return new WaitForSeconds(3F);
                }
                isRandLock = false;
            } else
            {
                yield return null;
            }
        }
        yield return null;
    }

    private void performAttack(Transform attackPoint, Vector3 attackRange, int attackDamage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, playerLayer);
        inRange = bossMain.bossBody.transform.position - bossMain.fongiBox.transform.position;
        foreach (Collider2D enemy in hitEnemies)
        {
            if (missCount >= 3 && (inRange.x > - 5F && inRange.x < 5F))
            {
                bossMain.moveDirection = bossMain.fongiBox.transform.position - bossMain.bossBody.transform.position;
                bossMain.moveDirection.z = 0;
                bossMain.fongiBox.AddForce(bossMain.moveDirection.normalized * bossMain.impulsForce, ForceMode2D.Impulse);
                fongiMain.TakeDamge(5);
                missCount = 0;

            }
            else if (enemy.CompareTag("Fongi"))
            {
                fongiMain.TakeDamge(attackDamage);
                if (missCount > 0)
                {
                    missCount--;
                }
                else
                {
                    return;
                }
            } else
            {
                missCount++;
            }
        }
    }

   private IEnumerator randOrg(float lowRange, float highRange)
    {
        while (!bossMain.isDead)
        {
            randWhichHit = Random.Range(lowRange, highRange);
            isRandLock = true;
            yield return new WaitForSeconds(3F);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPunchPoint != null)
        {
            Vector3 attackRange = new Vector3(3.5F, 2, 0);
            Gizmos.DrawWireCube(attackPunchPoint.position, attackRange);
        }
        else
        {
            return;
        }

        if (attackVerticalPoint != null)
        {
            Vector3 attackRange = new Vector3(4, 9, 0);
            Gizmos.DrawWireCube(attackVerticalPoint.position, attackRange);
        }
        else
        {
            return;
        }
    }
}
