using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revival : MonoBehaviour
{
    [SerializeField] private GameObject undead1;
    [SerializeField] private GameObject undead2;
    [SerializeField] private Animator anim;
    private bool revived = false;


    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Corpse"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
