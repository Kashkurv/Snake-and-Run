using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerManager playerManager;
    SkinnedMeshRenderer skinnedRenderer;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        skinnedRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    void ColorCheck(int value)
    {
        var newMaterials = new Material[skinnedRenderer.materials.Length];
        switch (value)
        {
            case 1:// Matirials Violet
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matYellow;
                newMaterials[3] = playerManager.matViolet;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(1);
                break;
            case 2:// Matirials Pink
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matYellow;
                newMaterials[3] = playerManager.matPink;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(2);
                break;
            case 3:// Matirials Yellow
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matViolet;
                newMaterials[3] = playerManager.matYellow;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(3);
                break;
            case 4:// Matirials Blue
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matYellow;
                newMaterials[3] = playerManager.matBlue;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(4);
                break;
            case 5:// Matirials TurquoiseI
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matYellow;
                newMaterials[3] = playerManager.matTurquoise;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(5);
                break;
            case 6:// Matirials Green
                newMaterials[0] = playerManager.matWhite;
                newMaterials[1] = playerManager.matBlack;
                newMaterials[2] = playerManager.matYellow;
                newMaterials[3] = playerManager.matGreen;
                skinnedRenderer.materials = newMaterials;
                playerManager.ColorActive(6);
                break;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag == ("VioletCheck"))
            {
                ColorCheck(playerManager.matVioletIndex);
            }
            else if (other.gameObject.tag == ("BlueCheck"))
            {
                ColorCheck(playerManager.matBlueIndex);
            }
            else if (other.gameObject.tag == ("YellowCheck"))
            {
                ColorCheck(playerManager.matYellowIndex);
            }
            else if (other.gameObject.tag == ("TurquoiseCheck"))
            {
                ColorCheck(playerManager.matTurquoiseIndex);
            }
            else if (other.gameObject.tag == ("GreenCheck"))
            {
                ColorCheck(playerManager.matGreenIndex);
            }
        
    }

}
