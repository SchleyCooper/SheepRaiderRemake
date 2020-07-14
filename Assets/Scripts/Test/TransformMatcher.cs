using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMatcher : MonoBehaviour
{
    [SerializeField]
    private Transform source;

    [SerializeField]
    private bool matchPosition, matchRotation, matchScale;

    void LateUpdate()
    {
        if (matchPosition)
            transform.localPosition = source.localPosition;

        if (matchRotation)
            transform.localRotation = source.localRotation;

        if (matchScale)
            transform.localScale = source.localScale;
    }
}
