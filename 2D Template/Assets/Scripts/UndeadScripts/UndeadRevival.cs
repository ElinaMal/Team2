using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadRevival : MonoBehaviour
{
    [SerializeField] private GameObject undead1;
    [SerializeField] private GameObject undead2;
    private GameObject numberTracker;
    private EnemyNumberTracker enemyNumberTracker;
    private float whichUndead;
    [SerializeField] private int undeadLimit = 60;
    [SerializeField] private float skeletonChance;


    // Start is called before the first frame update
    void Start()
    {
        numberTracker = GameObject.Find("EnemyNumberTracker");
        enemyNumberTracker = numberTracker.GetComponent<EnemyNumberTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevivalStart()
    {
        whichUndead = Random.Range(0, 101);

        if (enemyNumberTracker.undeadCounter <= undeadLimit)
        {
            if (whichUndead <= skeletonChance)
            {
                Instantiate(undead1, transform.position, transform.rotation);
                enemyNumberTracker.undeadCounter++;
                Destroy(gameObject);
            }
            else
            {
                Instantiate(undead2, transform.position, transform.rotation);
                enemyNumberTracker.undeadCounter++;
                Destroy(gameObject);
            }
        }
    }
}
