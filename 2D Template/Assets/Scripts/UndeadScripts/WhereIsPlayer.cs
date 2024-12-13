using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereIsPlayer : MonoBehaviour
{
    public Vector2 directionToPlayer;
    public Transform target;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        distance = enemyToPlayerVector.magnitude;
    }
}
