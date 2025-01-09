using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    private GameObject reviveArea;
    private bool revived = false;
    private float timer;
    private float timeStart = 0.3f;
    private float timeLimit = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        reviveArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Revive();
        }

        if (revived)
        {
            if (timer >= timeStart)
            {
                reviveArea.SetActive(true);
            }
        }

        if (revived)
        {
            timer += Time.deltaTime;

            if (timer >= timeLimit)
            {
                timer = 0;
                revived = false;
                reviveArea.SetActive(false);
            }
        }
    }

    void Revive()
    {
        revived = true;
    }
}
