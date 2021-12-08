using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fongiAttack : MonoBehaviour
{
    private FongiControls fongiControls;
    public Transform attackPoint;
    private LayerMask enemiesLayer;
    private AudioSource fongiSounds;
    private Animator fongiAnims;
    private GameObject fongi;
    private fongiMain fongiMain;

    [SerializeField] AudioClip soundHit;

    private float attackRange = 0.5f;
    private int attackDamage = 10;

    private bool isPunching;
    private bool isDead = false;

    private void Awake()
    {
        fongiControls = new FongiControls();
        enemiesLayer = LayerMask.GetMask("Enemy");
        fongiSounds = transform.GetComponent<AudioSource>();
        fongiAnims = transform.GetComponent<Animator>();
        fongi = GameObject.Find("Fongi2");
        fongiMain = fongi.GetComponent<fongiMain>();

    }
    private IEnumerator setPunching()
    {
        while (isDead != true)
        {

            while (isPunching == false)
            {
                yield return null;
            }

            yield return new WaitForSeconds(.45F);
            isPunching = false;
            fongiAnims.SetBool("isPunching", isPunching);
        }
        yield return null;
    }

    void OnAttack()
    {
        if (isPunching == false)
        {
            fongiSounds.clip = soundHit;
            fongiSounds.Play();
            isPunching = true;
            fongiAnims.SetBool("isPunching", isPunching);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<bossMain>().TakeDamge(attackDamage);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        } else
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("setPunching");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
