using UnityEngine;
using System.Collections.Generic;

public class UndeadToPlayer : MonoBehaviour
{
    public bool detected = false;
    public Vector2 directionToPlayer;
    public Transform target;
    public WhereIsPlayer player;
    public bool correctTarget = false;
    public List<string> detectedObjects;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if (player.distance >= 8)
        {
            detected = false;
            correctTarget = false;
        }
        else
        {
            detected = true;
            correctTarget = true;
        }
    }
}