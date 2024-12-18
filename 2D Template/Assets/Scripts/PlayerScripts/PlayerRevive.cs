using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    [SerializeField] private KeyCode button = KeyCode.E;
    private GameObject reviveArea;


    // Start is called before the first frame update
    void Start()
    {
        reviveArea = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            
            reviveArea.SetActive(true);
        }
    }
}
