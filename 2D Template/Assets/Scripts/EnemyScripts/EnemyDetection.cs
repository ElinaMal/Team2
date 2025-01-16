using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;
    public bool correctTarget = false;
    public UndeadToPlayer undeadToPlayer;
    public UndeadChasePlayer chasePlayer;
    public WhereIsPlayer whereIsPlayer;
    public bool closeEnough;
    [SerializeField] private string targetTag;
    private float distanceTarget;

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
        if (target == null)
        {
            target = target = GameObject.Find("Player").transform;
        }

        Vector2 enemyToPlayerVector = target.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        distanceTarget = enemyToPlayerVector.magnitude;

        if (gameObject.CompareTag("GoodGuysZone") || gameObject.CompareTag("GoodGuys"))
        {
            //
            if (whereIsPlayer.distance < 2)
            {
                closeEnough = false;

                if (undeadToPlayer != null)
                {
                    undeadToPlayer.enabled = true;
                }
                if (chasePlayer != null)
                {
                    chasePlayer.enabled = true;
                }
            }
            //
            else if (whereIsPlayer.distance < 18 && distanceTarget < 18)
            {
                closeEnough = true;
            }
            else
            {
                closeEnough = false;

                if (undeadToPlayer != null)
                {
                    undeadToPlayer.enabled = true;
                }
                if (chasePlayer != null)
                {
                    chasePlayer.enabled = true;
                }
            }
        }
    }
}
