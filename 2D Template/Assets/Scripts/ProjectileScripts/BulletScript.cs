using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //[SerializeField] private BulletVisual bulletVisual;
    [SerializeField] private ProjectileDestroy projectileDestroy;

    private Vector3 target;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float maxMoveSpeed;
    private float trajectoryMaxRelativeHeight;
    private float distanceToTargetToDestroyProjectile;
    private float damage;
    private string targetTag;

    private AnimationCurve trajectoryAnimationCurve;
    private AnimationCurve axisCorrectionAnimationCurve;
    private AnimationCurve speedAnimationCurve;

    private Vector3 trajectoryStartPoint;
    private Vector3 projectileMoveDir;
    private Vector3 trajectoryRange;

    private float nextYTrajectoryPosition;
    private float nextXTrajectoryPosition;
    private float nextPositionYCorrection;
    private float nextPositionXCorrection;

    private bool Pierce;
    private bool Slash;
    private bool Blunt;
    private bool AN;
    private bool Burn;
    private int burnAmount;
    private float burnDamage;

    // Start is called before the first frame update
    void Start()
    {
        trajectoryStartPoint = transform.position;
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Camera>();
        rb = GetComponent<Rigidbody2D>();
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 direction = mousePos - transform.position;
        //Vector3 rotation = transform.position - mousePos;
        //rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void UpdateProjectilePosition()
    {
        trajectoryRange = target - trajectoryStartPoint;

        //Debug.Log(trajectoryMaxRelativeHeight);

        if (Mathf.Abs(trajectoryRange.normalized.x) < Mathf.Abs(trajectoryRange.normalized.y))
        {
            //Projectile curved on X axis

            if (trajectoryRange.y < 0)
            {
                force = -force;
            }

            UpdatePositionWithXCurve();
        }
        else
        {
            //Projectile curved on Y axis

            if (trajectoryRange.x < 0)
            {
                force = -force;
            }

            UpdatePositionWithYCurve();
        }
    }
    private void UpdatePositionWithXCurve()
    {
        float nextPositionY = transform.position.y + force * Time.deltaTime;
        float nextPositionYNormalized = (nextPositionY - trajectoryStartPoint.y) / trajectoryRange.y;

        //Debug.Log(nextPositionYNormalized);

        float nextPositionXNormalized = trajectoryAnimationCurve.Evaluate(nextPositionYNormalized);

        //Debug.Log(nextPositionXNormalized);

        nextXTrajectoryPosition = nextPositionXNormalized * trajectoryMaxRelativeHeight;


        float nextPositionXCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionYNormalized);
        nextPositionXCorrection = nextPositionXCorrectionNormalized * trajectoryRange.x;

        if(trajectoryRange.x > 0 && trajectoryRange.y > 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }

        if (trajectoryRange.x < 0 && trajectoryRange.y < 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }

        float nextPositionX = trajectoryStartPoint.x + nextXTrajectoryPosition + nextPositionXCorrection;

        Vector3 nextPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionYNormalized);
        projectileMoveDir = nextPosition - transform.position;

        transform.position = nextPosition;
    }
    private void UpdatePositionWithYCurve()
    {
        float nextPositionX = transform.position.x + force * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;

        float nextPositionYNormalized = trajectoryAnimationCurve.Evaluate(nextPositionXNormalized);
        nextYTrajectoryPosition = nextPositionYNormalized * trajectoryMaxRelativeHeight;

        float nextPositionYCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionXNormalized);
        nextPositionYCorrection = nextPositionYCorrectionNormalized * trajectoryRange.y;
        float nextPositionY = trajectoryStartPoint.y + nextYTrajectoryPosition + nextPositionYCorrection;

        Vector3 nextPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionXNormalized);
        projectileMoveDir = nextPosition - transform.position;

        transform.position = nextPosition;
    }

    private void CalculateNextProjectileSpeed(float nextPositionXNormalized)
    {
        float nextMoveSpeedNormalized = speedAnimationCurve.Evaluate(nextPositionXNormalized);

        force = nextMoveSpeedNormalized * maxMoveSpeed;
    }
    public void InitializeAnimationCurves(AnimationCurve trajectoryAnimationCurve, AnimationCurve axisCorrectionAnimationCurve, AnimationCurve speedAnimationCurve)
    {
        this.trajectoryAnimationCurve = trajectoryAnimationCurve;
        this.axisCorrectionAnimationCurve = axisCorrectionAnimationCurve;
        this.speedAnimationCurve = speedAnimationCurve;
    }

    public void InitializeProjectile(float trajectoryMaxHeight, float distanceToTargetToDestroyProjectile, float maxMoveSpeed, float destroyTime, Vector3 target, float damage, string targetTag, bool Pierce, bool Slash, bool Blunt, bool AN, bool Burn, int burnAmount, float burnDamage)
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        this.target = target;
        float xDistanceToTarget = target.x - transform.position.x;
        this.trajectoryMaxRelativeHeight = Mathf.Abs(xDistanceToTarget) * trajectoryMaxHeight;
        //Debug.Log(Mathf.Abs(xDistanceToTarget));
        this.distanceToTargetToDestroyProjectile = distanceToTargetToDestroyProjectile;
        this.maxMoveSpeed = maxMoveSpeed;
        this.damage = damage;
        this.targetTag = targetTag;
        projectileDestroy.InitializeTimer(destroyTime);
        this.Pierce = Pierce;
        this.Slash = Slash;
        this.Blunt = Blunt;
        this.AN = AN;
        this.Burn = Burn;
        this.burnAmount = burnAmount;
        this.burnDamage = burnDamage;

        //bulletVisual.SetTarget(mousePos);
    }

    public Vector3 GetProjectileMoveDir()
    {
        return projectileMoveDir;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && collider.gameObject.CompareTag(targetTag))
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProjectilePosition();
        if (Vector3.Distance(transform.position, target) < distanceToTargetToDestroyProjectile)
        {
            Destroy(gameObject);
        }
    }
}
