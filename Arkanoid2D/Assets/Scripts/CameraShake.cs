﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Camera cam;
    Vector3 origin;

    private void Awake()
    {
        origin = cam.transform.position;
    }

    public IEnumerator Shake(float durantion, float force)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < durantion)
        {
            float x = origin.x + Random.Range(-1f, 1f) * force;
            float y = origin.y + Random.Range(-1f, 1f) * force;

            transform.localPosition = new Vector3(x, y, origin.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = origin;
    }
}
