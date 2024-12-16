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
        List<string> detectedObjects = new List<string>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedObjects.Add(collision.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        detected = true;

        if (detected) 
        {
            if (detectedObjects.Contains("Player"))
            {
                correctTarget = true;
            }
            else
            {
                correctTarget = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected = false;
        detectedObjects.Remove(collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
    }
}