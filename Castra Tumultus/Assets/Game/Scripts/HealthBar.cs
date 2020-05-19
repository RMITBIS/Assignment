﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;
    private Quaternion rotation;

    private void Awake ()
    {
        GetComponentInParent<Health>().OnHealthPctChanged += HandleHealthChanged;
        rotation = transform.rotation;

    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;
        
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }
    
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.rotation = rotation;
       //transform.LookAt(MainCamera.Transform);
       transform.Rotate(0, 225, 0);
    }
}
