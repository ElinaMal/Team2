using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactObject;
    public UnityEvent interactAction;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactObject))
            {
                interactAction.Invoke();
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
            isInRange = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player now in range");
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
            isInRange = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player not in range");
        }
    }
}

    

