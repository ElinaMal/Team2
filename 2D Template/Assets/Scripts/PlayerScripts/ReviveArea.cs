using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveArea : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UndeadRevival>() != null && collision.CompareTag("Corpse"))
        {
            UndeadRevival undeadRevival = collision.GetComponent<UndeadRevival>();
            undeadRevival.RevivalStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
