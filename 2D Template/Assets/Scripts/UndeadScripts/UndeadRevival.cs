using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadRevival : MonoBehaviour
{
    [SerializeField] private GameObject undead1;
    [SerializeField] private GameObject undead2;
    [SerializeField] private Animator anim;
    private int whichUndead;
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
        revived = true;
        
    }
}
