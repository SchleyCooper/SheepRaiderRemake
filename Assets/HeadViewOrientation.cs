using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadViewOrientation : MonoBehaviour
{
    [SerializeField]
    private Transform observer; // player observing this graphic

    [SerializeField]
    private Transform detector; // character watching the player

    [SerializeField]
    private Transform detectorMimic;    // mimic object matching the detector

    [SerializeField]
    private float offsetDistance = 2f;

    private Vector3 viewDirection;

    // Update is called once per frame
    void LateUpdate()
    {
        viewDirection = observer.position - detector.position;   // grab direction from player to detector
        transform.position = detectorMimic.position + viewDirection.normalized * offsetDistance;    // offset the mimic camera in same direction
        transform.LookAt(detectorMimic);    // make sure always facing mimic
    }
}
