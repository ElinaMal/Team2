using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float maxMoveSpeed;
    private float trajectoryMaxRelativeHeight;
    private float distanceToTargetToDestroyProjectile;

    private AnimationCurve trajectoryAnimationCurve;
    private AnimationCurve axisCorrectionAnimationCurve;
    private AnimationCurve speedAnimationCurve;

    private Vector3 trajectoryStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        trajectoryStartPoint = transform.position;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 direction = mousePos - transform.position;
        //Vector3 rotation = transform.position - mousePos;
        //rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void UpdateProjectilePosition()
    {
        Vector3 trajectoryRange = mousePos - trajectoryStartPoint;

        if (trajectoryRange.x < 0)
        {
            force = -force;
        }

        float nextPositionX = transform.position.x + force * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;

        float nextPositionYNormalized = trajectoryAnimationCurve.Evaluate(nextPositionXNormalized);
        float nextPositionYCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionXNormalized);
        float nextPositionYCorrection = nextPositionYCorrectionNormalized * trajectoryRange.y;
        float nextPositionY = trajectoryStartPoint.y + nextPositionYNormalized * trajectoryMaxRelativeHeight + nextPositionYCorrection;

        Vector3 nextPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionXNormalized);

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

    public void InitializeProjectile(float trajectoryMaxHeight, float distanceToTargetToDestroyProjectile, float maxMoveSpeed)
    {
        float xDistanceToTarget = mousePos.x - transform.position.x;
        this.trajectoryMaxRelativeHeight = Mathf.Abs(xDistanceToTarget) * trajectoryMaxHeight;
        this.distanceToTargetToDestroyProjectile = distanceToTargetToDestroyProjectile;
        this.maxMoveSpeed = maxMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProjectilePosition();
        if (Vector3.Distance(transform.position, mousePos) < distanceToTargetToDestroyProjectile)
        {
            Destroy(gameObject);
        }
    }
}
