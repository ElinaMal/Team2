using UnityEngine;

public class SimonAttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 3;

    [SerializeField] private string targetTag;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && collider.gameObject.CompareTag(targetTag))
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}