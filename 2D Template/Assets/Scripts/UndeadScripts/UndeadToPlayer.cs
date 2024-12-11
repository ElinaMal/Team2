using UnityEngine;

public class UndeadToPlayer : MonoBehaviour
{
    public bool detected = false;
    public Vector2 directionToPlayer;
    public Transform target;

    public bool correctTarget = false;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        detected = true;

        if (detected) 
        {
            if (collider.gameObject == target)
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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
    }
}