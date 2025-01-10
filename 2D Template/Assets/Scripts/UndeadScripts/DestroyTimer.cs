using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private bool wait = true;
    [SerializeField] private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
