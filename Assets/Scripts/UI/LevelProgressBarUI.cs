using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelProgressBarUI : MonoBehaviour
{
    [Header("Player & Endline references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;
    [SerializeField] Image uiFillImage;


    private Vector3 endLinePosition;

    // "fullDistance" stores the default distance between the player & end line.
    private float fullDistance;
    void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }

    private float GetDistance()
    {
        // Slow
        return Vector3.Distance (playerTransform.position, endLinePosition) ;

        // Fast
       // return (endLinePosition - playerTransform.position).sqrMagnitude;
    }
    private void UpdateProgressFill(float value)
    {
        uiFillImage.DOFillAmount(value, .2f); ;
    }
    void Update()
    {
        // check if the player doesn't pass the End Line
        if (playerTransform.position.z <= endLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

            UpdateProgressFill(progressValue);
        }

    }
}
