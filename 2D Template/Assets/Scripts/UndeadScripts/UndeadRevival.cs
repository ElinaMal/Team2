using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadRevival : MonoBehaviour
{
    [SerializeField] private GameObject undead1;
    [SerializeField] private GameObject undead2;
    [SerializeField] private Animation anim;
    private EnemyNumberTracker enemyNumberTracker;
    private float whichUndead;
    [SerializeField] private int undeadLimit = 60;
    [SerializeField] private float skeletonChance;
    private bool revived = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevivalStart()
    {
        if (enemyNumberTracker.undeadCounter <= undeadLimit)
        {
            revived = true;

            whichUndead = Random.Range(0, 101);

            if (whichUndead <= skeletonChance)
            {
                Instantiate(undead1);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(undead2);
                Destroy(gameObject);
            }
        }
    }
}
