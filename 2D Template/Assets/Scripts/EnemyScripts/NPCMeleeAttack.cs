using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPCMeleeAttack : MonoBehaviour
{
    private Transform target;
    private bool attacking;
    private bool canAttack;
    private float timer;
    private float attackTimer;
    public float attackDelay;
    public Animator anim;
    public Animator parentAnim;

    [SerializeField] private GameObject attackArea;
    [SerializeField] private GameObject targetDetectorObject;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private string targetTag;


    // Update is called once per frame
    void Update()
    {
        findTarget();

        Vector3 rotation = target.position - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        attackArea.SetActive(attacking);

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                attacking = false;
                timer = 0;
            }
        }

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay)
        {
            canAttack = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(targetTag) && canAttack)
        {
            attacking = true;
            attackArea.SetActive(attacking);
            //anim.SetTrigger("isAttacking");
            Debug.Log("attack");
            parentAnim.SetTrigger("isAttacking");
            canAttack = false;
            attackTimer = 0;
        }
    }
    private void findTarget()
    {
        EnemyDetection targetDetector = targetDetectorObject.GetComponent<EnemyDetection>();
        target = targetDetector.target;
    }
}
