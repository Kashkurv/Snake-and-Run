using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] float rotationSpeed;
    [SerializeField] float controlSpeed;


    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;

    [SerializeField] float positionXMax;
    [SerializeField] float positionXMin;
    [SerializeField] int countTailStart;
    public float z_offset = 1f;

    Transform defoultPosition;
    


    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();     
    }

    void Update()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move && playerManager.playerState != PlayerManager.PlayerState.Fever)
        {
            GetInput();
        }
        else if (playerManager.playerState == PlayerManager.PlayerState.Fever)
        {
            FeverActive();
        }
    }

    private void FixedUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Move && playerManager.playerState != PlayerManager.PlayerState.Fever)
        {
            transform.position += Vector3.forward * playerManager.speed * Time.fixedDeltaTime;

            if (isTouching)
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;

                if (touchPosX <= positionXMin)
                {
                    touchPosX = positionXMin;
                }
                else if (touchPosX >= positionXMax)
                {
                    touchPosX = positionXMax;
                }
            }
            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
        }
    }
    void FeverActive()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.position += Vector3.forward * (playerManager.speed * 3) * Time.fixedDeltaTime;
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }else{
            isTouching = false;
        }
    }
}
