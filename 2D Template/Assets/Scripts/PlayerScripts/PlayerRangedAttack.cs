using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public KeyCode Shoot = KeyCode.Mouse0;
    [SerializeField] private Animator anim;
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

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetKey(Shoot) && canFire)
        {
            canFire = false;
            BulletScript bulletScript = Instantiate(bullet, bulletTransform.position, Quaternion.identity).GetComponent<BulletScript>();
            bulletScript.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, speedAnimationCurve);
            bulletScript.InitializeProjectile(projectileMaxHeight, distanceToTargetToDestroyProjectile, maxMoveSpeed, destroyTime, mousePos, damage, targetTag, Pierce, Slash, Blunt, AN, Burn, burnAmount, burnDamage);
        }
    }
}
