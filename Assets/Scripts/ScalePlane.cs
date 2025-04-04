using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlane : MonoBehaviour
{
    private Vector2 screenResolution;

    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    void Update()
    {
        if(screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            MatchPlaneToScreenSize();
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }
    }

    private void MatchPlaneToScreenSize()
    {
        float planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        float planeHeightScale = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance) / 5.2f;
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        gameObject.transform.localScale = new Vector3(planeWidthScale, 1, planeHeightScale);
    }
}
