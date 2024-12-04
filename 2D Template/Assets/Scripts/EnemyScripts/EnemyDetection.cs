using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool detected;
    public Vector2 directionToPlayer;
    public Transform target;
    public bool correctTarget = false;
    public object check;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        detected = true;
        
        if (detected)
        {
            if (collider.gameObject.CompareTag("GoodGuys"))
            {
                target = collider.gameObject.transform;
                correctTarget = true;
            }
        }
        else if (collider.tag != "GoodGuys")
        {
            
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
    }
}
