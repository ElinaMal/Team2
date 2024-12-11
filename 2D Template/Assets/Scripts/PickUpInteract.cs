using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpInteract : MonoBehaviour
{
    [SerializeField]
 
    private bool pickUpAllowed;
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.Escape))
            PickUp();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpText = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpText = false;
        }
    }
    private void PickUp()
    {
        Destroy(gameObject);
    }
}
