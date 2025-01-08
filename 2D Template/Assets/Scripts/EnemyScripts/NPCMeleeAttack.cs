using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMeleeAttack : MonoBehaviour
{
    private Transform target;
    [SerializeField] private GameObject targetDetectorObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findTarget();

        Vector3 rotation = target.position - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void findTarget()
    {
        EnemyDetection targetDetector = targetDetectorObject.GetComponent<EnemyDetection>();
        target = targetDetector.target;
    }
}
