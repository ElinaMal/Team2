using System.Collections;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;
    public Transform zombiePrefab;
    public bool correctTarget = false;
    public UndeadToPlayer undeadToPlayer;
    public UndeadChasePlayer chasePlayer;
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
                    
                }

                if (gameObject.CompareTag("GoodGuys"))
                {
                    chasePlayer.enabled = false;
                }
                
                target = collider.gameObject.transform;
                correctTarget = true;
            }
        }
        else
        {
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

        if (gameObject.CompareTag("GoodGuysZone") || gameObject.CompareTag("GoodGuys"))
        {
            if (whereIsPlayer.distance < 16)
            {
                closeEnough = true;
            }
            else
            {
                if (undeadToPlayer != null)
                {
                    
                }
                if (chasePlayer != null)
                {
                    chasePlayer.enabled = true;
                }

                closeEnough = false;
            }
        }
    }
}
