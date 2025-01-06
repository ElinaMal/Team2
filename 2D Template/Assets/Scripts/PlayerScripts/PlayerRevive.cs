using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    private GameObject reviveArea;
    private float timer;
    private float timeStart = 0.2f;
    private float timeLimit = 0.60f;


    // Start is called before the first frame update
    void Start()
    {
        reviveArea = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timer += Time.deltaTime;

            if (timer >= timeStart)
            {
                reviveArea.SetActive(true);
            }
            else if (timer >= timeLimit)
            {
                timer = 0;
                reviveArea.SetActive(false);
            }
        }
    }
}
