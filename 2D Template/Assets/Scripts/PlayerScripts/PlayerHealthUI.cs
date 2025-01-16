using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public GameObject fullHP;
    public GameObject threeFourthsHP;
    public GameObject halfHP;
    public GameObject oneFourthHP;
    public GameObject NoHP;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Health health = player.GetComponent<Health>();

        if (health.health == 8)
        {
            fullHP.SetActive(true);
            threeFourthsHP.SetActive(false);
            halfHP.SetActive(false);
            oneFourthHP.SetActive(false);
            NoHP.SetActive(false);
        }
        else if (health.health == 6)
        {
            fullHP.SetActive(false);
            threeFourthsHP.SetActive(true);
            halfHP.SetActive(false);
            oneFourthHP.SetActive(false);
            NoHP.SetActive(false);
        }
        else if (health.health == 4)
        {
            fullHP.SetActive(false);
            threeFourthsHP.SetActive(false);
            halfHP.SetActive(true);
            oneFourthHP.SetActive(false);
            NoHP.SetActive(false);
        }
        else if (health.health == 2)
        {
            fullHP.SetActive(false);
            threeFourthsHP.SetActive(false);
            halfHP.SetActive(false);
            oneFourthHP.SetActive(true);
            NoHP.SetActive(false);
        }
        else if (health.health == 0)
        {
            fullHP.SetActive(false);
            threeFourthsHP.SetActive(false);
            halfHP.SetActive(false);
            oneFourthHP.SetActive(false);
            NoHP.SetActive(true);
        }
    }
}
