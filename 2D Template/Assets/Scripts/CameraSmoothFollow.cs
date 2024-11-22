using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
   [SerializeField] private float damping;
    [SerializeField] private Vector3 offset;
    public Transform target;
    private Vector3 vel = Vector3.zero;
    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref
        vel, damping);
    }
}
