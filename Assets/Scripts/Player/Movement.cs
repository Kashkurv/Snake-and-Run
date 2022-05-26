using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PlayerManager playerManager;


#if UNITY_EDITOR
    float controlSpeed = 20;
#else
    float controlSpeed = 7;
#endif

    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;

    [SerializeField] float positionXMax;
    [SerializeField] float positionXMin;

    [SerializeField] float velocity;

    


    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();     
    }

    private void Update()
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
            //direction = new Vector3(touchPosX,0f,0f);

            /* if (direction.magnitude>0.5f)
             {
                 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position),Time.fixedDeltaTime*velocity);
             }
             else
             {
                 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime * velocity);
             }*/
        }
    }
    void FeverActive()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.position += Vector3.forward * (playerManager.speed * 3f) * Time.deltaTime;
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
