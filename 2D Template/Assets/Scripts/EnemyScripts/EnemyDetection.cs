using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;
    public bool correctTarget = false;

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
                if (gameObject.CompareTag("GoodGuys"))
                {
                    GetComponent<UndeadToPlayer>().enabled = false;

                    GetComponent<UndeadChasePlayer>().enabled = false;

                    GetComponent<EnemyMovement>().enabled = false;
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

        if (gameObject.CompareTag("GoodGuys"))
        {
            GetComponent<UndeadToPlayer>().enabled = true;

            GetComponent<UndeadChasePlayer>().enabled = true;
        }
    }
}
