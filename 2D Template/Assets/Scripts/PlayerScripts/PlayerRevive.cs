using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    [SerializeField] private KeyCode button = KeyCode.E;
    private GameObject reviveArea;
    private float timer;
    private float timeStart = 0.2f;
    private float timeLimit = 0.60f;


    // Start is called before the first frame update
    void Start()
    {
        reviveArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button))
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
