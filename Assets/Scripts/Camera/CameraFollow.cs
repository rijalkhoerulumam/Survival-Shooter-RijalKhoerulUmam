﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region 1

    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
