using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject fongi;
    private fongiMain fongiMain;
    private GameObject cameraBoss;
    private CameraBoss camBoss;
    private GameObject bossA;
    private bossAttacks bossAttacks;

    [SerializeField] Camera outBossZoneCamera;
    [SerializeField] Camera inBossZoneCamera;

    private void Awake()
    {
        cameraBoss = GameObject.Find("BossCamera");
        camBoss = cameraBoss.GetComponent<CameraBoss>();
        fongi = GameObject.Find("Fongi2");
        fongiMain = fongi.GetComponent<fongiMain>();
        bossA = GameObject.Find("Boss");
        bossAttacks = bossA.GetComponent<bossAttacks>();
    }

    private IEnumerator manageCamera()
    {
        while(fongiMain.isDead != true)
        {
            while (camBoss.isInBossZone == false)
            {
                bossAttacks.isActive = false;
                inBossZoneCamera.enabled = false;
                outBossZoneCamera.enabled = true;
                yield return null;
            }
            bossAttacks.isActive = true;
            outBossZoneCamera.enabled = false;
            inBossZoneCamera.enabled = true;
            yield return null;
        }

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("manageCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
