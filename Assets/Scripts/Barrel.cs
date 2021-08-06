using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    PlayerManager playerManager;
    AudioManager audioManager;

   [SerializeField] ParticleSystem particleSystem;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
                
            if (other.gameObject.tag == ("HitDestroy"))
            {                
                audioManager.PlaySound("BoomHit");
                Instantiate(particleSystem, transform.position, Quaternion.identity);
                particleSystem.Play();
               
                Destroy(gameObject);

                if (playerManager.playerState != PlayerManager.PlayerState.Fever)
                {
                    playerManager.GameOver();
                }
            }
        
    }  
}
