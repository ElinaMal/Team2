using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCRangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject targetDetectorObject;
    [SerializeField] private Transform target;
    [SerializeField] private Animator anim;

    [SerializeField] private float shootRate;
    [SerializeField] private float shootTimer;

    [SerializeField] private float projectileMaxHeight;
    [SerializeField] private float distanceToTargetToDestroyProjectile;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float destroyTime;
    [SerializeField] private float damage;
    [SerializeField] private string targetTag;

    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve speedAnimationCurve;

    [SerializeField] private bool Pierce;
    [SerializeField] private bool Slash;
    [SerializeField] private bool Blunt;
    [SerializeField] private bool AN;
    [SerializeField] private bool Burn;
    [SerializeField] private int burnAmount;
    [SerializeField] private float burnDamage;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        findTarget();
        Shoot();
    }

    private void findTarget()
    {
        EnemyDetection targetDetector = targetDetectorObject.GetComponent<EnemyDetection>();
        target = targetDetector.target;
    }

    private void Shoot()
    {
        EnemyDetection targetDetector = targetDetectorObject.GetComponent<EnemyDetection>();
        if (shootTimer <= 0 && targetDetector.correctTarget)
        {
            anim.SetTrigger("Shooting");
            shootTimer = shootRate;
            BulletScript bulletScript = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<BulletScript>();
            bulletScript.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, speedAnimationCurve);
            bulletScript.InitializeProjectile(projectileMaxHeight, distanceToTargetToDestroyProjectile, maxMoveSpeed, destroyTime, target.position, damage, targetTag, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);

        }

    }
}
