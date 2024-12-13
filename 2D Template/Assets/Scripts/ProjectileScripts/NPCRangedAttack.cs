using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform target;

    [SerializeField] private float shootRate;
    [SerializeField] private float shootTimer;

    [SerializeField] private float projectileMaxHeight;
    [SerializeField] private float distanceToTargetToDestroyProjectile;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float destroyTime;

    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve speedAnimationCurve;

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            shootTimer = shootRate; 
            NPCBulletScript bulletScript = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<NPCBulletScript>();
            bulletScript.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, speedAnimationCurve);
            bulletScript.InitializeProjectile(projectileMaxHeight, distanceToTargetToDestroyProjectile, maxMoveSpeed, destroyTime, target);

        }
    }
}
