using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;

    void Start()
    {
        target = GameObject.Find("Square").transform;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        detected = true;
        
        if (detected)
        {
            target = collider.gameObject.transform;
        }
        else
        {
            target = GameObject.Find("Square").transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            detected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
    }
}
