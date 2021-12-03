using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fongiAttack : MonoBehaviour
{
    private FongiControls fongiControls;
    public Transform attackPoint;
    private LayerMask enemiesLayer;
    private AudioSource fongiSounds;

    [SerializeField] AudioClip soundHit;

    private float attackRange = 0.5f;
    private int attackDamage = 10;

    private void Awake()
    {
        fongiControls = new FongiControls();
        enemiesLayer = LayerMask.GetMask("Enemy");
        fongiSounds = transform.GetComponent<AudioSource>();

    }

    void OnAttack()
    {
        fongiSounds.clip = soundHit;
        fongiSounds.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<bossMain>().TakeDamge(attackDamage);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
