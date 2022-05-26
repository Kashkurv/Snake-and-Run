using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    Transform playerTransform;
    PlayerManager playerManager;
    AudioManager audioManager;

    bool isHit = false;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        playerTransform = GameObject.FindGameObjectWithTag("BoxHit").transform;
    }

    
    void Update()
    {
        if (isHit)
        {
            MoveEnemyMagnet();
        }
    }
    void MoveEnemyMagnet()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 20f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("BoxHit"))
        {
            isHit = true;
        }
        if (other.gameObject.tag == ("HitDestroy"))
        {
            audioManager.PlaySound("CrystalHit");
            playerManager.CheckQueue("Crystal");
            playerManager.CountCrystal(1);
            Destroy(gameObject);
        }
    }
}
