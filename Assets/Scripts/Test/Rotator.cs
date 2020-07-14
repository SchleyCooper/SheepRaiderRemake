using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2f;

    [SerializeField]
    private float maxRotation = 45f;

    private Vector3 targetAngles = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        targetAngles.y = Mathf.Sin(Time.time * rotationSpeed) * maxRotation;
        transform.localRotation = Quaternion.Euler(targetAngles);
    }
}
