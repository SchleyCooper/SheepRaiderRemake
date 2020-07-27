using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField]
    private float visionAngle = 180f;
    // [SerializeField]
    // private float visionRange = 50f;
    [SerializeField]
    private float awarenessRadius = 20f;
    [SerializeField]
    private float speedNoiseTreshold = 5f;
    [SerializeField]
    private Transform visionOrigin;
    [SerializeField]
    private LayerMask targetLayers;
    [SerializeField]
    private LayerMask raycastLayers;

    private Rigidbody detectedTarget;
    private Vector3 lastKnownPosition = Vector3.zero;
    
    private Collider[] awarenessTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for targets in sphere (awareness range)

        // check for line of sight

        // if no line of sight, check for sound (speedNoiseThreshold)

        CheckTargetsInRange();
    }

    public void CheckTargetsInRange()
    {
        

        // sphere cast for players in range
        awarenessTargets = Physics.OverlapSphere(visionOrigin.position, awarenessRadius, targetLayers);
        if (awarenessTargets.Length > 0)
        {
            // targets in range
            foreach(Collider target in awarenessTargets)
            {
                Debug.DrawLine(visionOrigin.position, target.transform.position, Color.red);
                // check if within vision radius
                float angle = Vector3.Angle(visionOrigin.forward, target.transform.position);
                if (angle <= visionAngle * 0.5f)
                {
                    // check for direct line of sight
                    Vector3 direction = target.transform.position - visionOrigin.position;
                    RaycastHit hit;
                    if (Physics.Raycast(visionOrigin.position, direction, out hit, awarenessRadius, raycastLayers))
                    {
                        // direct LOS found, set detection parameters
                        Debug.DrawLine(visionOrigin.position, hit.transform.position, Color.green); // GREEN = DETECTED
                        lastKnownPosition = target.transform.position;
                        
                        Rigidbody rb = target.gameObject.GetComponent<Rigidbody>();
                        if (rb != null && detectedTarget != rb)
                        {
                            if (!detectedTarget)
                                detectedTarget = rb;
                            else if (Vector3.Distance(target.transform.position, visionOrigin.position) < Vector3.Distance(detectedTarget.position, visionOrigin.position))
                            {
                                detectedTarget = rb;
                            }
                        }
                    }
                    else
                    {
                        // target only within vision cone but not seen
                        Debug.DrawLine(visionOrigin.position, target.transform.position, Color.cyan); // CYAN = WITHIN VISION RADIUS
                    }

                    // Debug.Log($"{hit.transform}");
                }
                else {
                    // if not seen, then check if target is moving quick enough to be 'heard'
                    Rigidbody targetRb = target.GetComponent<Rigidbody>();
                    if (targetRb && targetRb.velocity.sqrMagnitude >= Mathf.Pow(speedNoiseTreshold, 2))
                    {
                        lastKnownPosition = target.transform.position;  // set to where 'noise' originated
                        Debug.DrawLine(visionOrigin.position, target.transform.position, Color.yellow); // YELLOW = IN 'AUDIBLE' RANGE
                    }
                    else if (targetRb = null)
                    {
                        // target only within range
                        // if (!target.GetComponent<Player>())
                        Debug.Log(target.gameObject.name);
                        Debug.DrawLine(visionOrigin.position, target.transform.position, Color.red); // RED = ONLY WITHIN RANGE
                    }
                }
            }
        }
        else
        {
            detectedTarget = null;  // no targets in range
        }
    }

    // public bool CheckLineOfSight(Transform target)
    // {
    //     return true;    // no
    // }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(visionOrigin.position, awarenessRadius);
        
        if(detectedTarget) {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.white;
        }
        Gizmos.DrawWireCube(lastKnownPosition, Vector3.one);
    }
}
