using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttacks : MonoBehaviour
{
    private BoxCollider2D punchBox;
    private BoxCollider2D verticalBox;

    private bool canAttack;


    private void OnEnable()
    {
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = collision.CompareTag("Fongi");

        if(hit && canAttack)
        {
            Debug.Log("Punched");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        punchBox = GetComponent<BoxCollider2D>();
        punchBox.enabled = false;
        verticalBox = GetComponent<BoxCollider2D>();
    }

    private IEnumerator TryAttack()
    {
        punchBox.enabled = true;
        yield return new WaitForSeconds(5F);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("TryAttack");
    }
}
