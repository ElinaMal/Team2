using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    private float destroyTime;


    public void InitializeTimer(float destroyTime)
    {
        this.destroyTime = destroyTime;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(destroyTime);
        Object.Destroy(gameObject);
    }
}
