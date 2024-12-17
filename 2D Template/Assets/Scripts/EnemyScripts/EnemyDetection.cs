using System.Collections;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;
    public bool correctTarget = false;
    public UndeadToPlayer undeadToPlayer;
    public WhereIsPlayer whereIsPlayer;
    public bool closeEnough;
    private bool wait;
    [SerializeField] private string targetTag;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        detected = true;
        
        if (detected)
        {
            if (collider.gameObject.CompareTag(targetTag))
            {
                if (gameObject.CompareTag("GoodGuysZone") && closeEnough)
                {
                    undeadToPlayer.enabled = false;
                }

                target = collider.gameObject.transform;
                correctTarget = true;
            }
        }
        else
        {
            target = GameObject.Find("Player").transform;
            correctTarget = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected = false;
        correctTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if (gameObject.CompareTag("GoodGuysZone"))
        {
            if (whereIsPlayer.distance < 16)
            {
                closeEnough = true;
            }
            else
            {
                undeadToPlayer.enabled = true;

                closeEnough = false;
            }
        }
    }
}
