using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    PlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }

    private void FixedUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move && playerManager.playerState != PlayerManager.PlayerState.Fever)
        {
           transform.position -= Vector3.forward * playerManager.speed * Time.fixedDeltaTime;
        } else if (playerManager.levelState == PlayerManager.LevelState.Finished)
        {
            transform.position = transform.position;
        }
    }
}
