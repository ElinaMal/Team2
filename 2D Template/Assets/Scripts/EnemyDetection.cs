using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private bool detected = false;
    public EnemyChasing target;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        detected = true;
        
        if (detected)
        {
            target.targetting = collider.gameObject.transform;
        }
        else
        {
            target.targetting = null;
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detected = false;
    }
}
