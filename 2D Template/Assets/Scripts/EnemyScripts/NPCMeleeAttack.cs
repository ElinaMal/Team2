using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPCMeleeAttack : MonoBehaviour
{
    private Transform target;
    private bool attacking;
    private float timer;
    public Animator anim;
    public Animator parentAnim;

    [SerializeField] private GameObject attackArea;
    [SerializeField] private GameObject targetDetectorObject;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private string targetTag;


    // Start is called before the first frame update
    void Start()
    {
        parentAnim = parentObject.GetComponent<Animator>();
    }

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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(targetTag))
        {
            attacking = true;
            attackArea.SetActive(attacking);
            anim.SetBool("isAttacking", true);
            parentAnim.SetBool("isAttacking", true);
        }
    }
            private void findTarget()
    {
        EnemyDetection targetDetector = targetDetectorObject.GetComponent<EnemyDetection>();
        target = targetDetector.target;
    }
}
