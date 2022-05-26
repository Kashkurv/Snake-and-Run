using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] int ID;
    PlayerManager playerManager;

    AudioManager audioManager;

    bool isHit = false;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        playerTransform = GameObject.FindGameObjectWithTag("BoxHit").transform;
    }
    private void Update()
    {
        if (isHit)
        {
            MoveEnemyMagnet();
        }
    }   

    void MoveEnemyMagnet()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 10f * Time.deltaTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("BoxHit"))
        {
            isHit = true;
        }
        if (other.gameObject.tag == ("HitDestroy"))
        {
            playerManager.CountDedEnemy(ID);
            audioManager.PlaySound("EnemyHit");
            playerManager.CheckQueue("Enemy");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("BoxHit"))
        {
            isHit = false;
        }
    }
}

  

