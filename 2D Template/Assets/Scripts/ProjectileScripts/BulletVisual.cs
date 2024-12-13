using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisual : MonoBehaviour
{
    [SerializeField] private Transform projectileVisual;
    [SerializeField] private Transform projectileShadow;
    [SerializeField] private BulletScript bulletScript;

    //private Vector3 target;
    //private Vector3 trajectoryStartPosition;

    private void Update()
    {
        UpdateProjectileRotation();
    }

    //private void UpdateShadowPosition()
    //{
    //}

    private void UpdateProjectileRotation()
    {
        Vector3 projectileMoveDir = bulletScript.GetProjectileMoveDir();

        projectileVisual.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(projectileMoveDir.y, projectileMoveDir.x) * Mathf.Rad2Deg);
        projectileShadow.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(projectileMoveDir.y, projectileMoveDir.x) * Mathf.Rad2Deg);
    }

    //public void SetTarget(Vector3 target)
    //{
    //    this.target = target;
    //}
}
