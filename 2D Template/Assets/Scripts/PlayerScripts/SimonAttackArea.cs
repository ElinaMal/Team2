using UnityEngine;

public class SimonAttackArea : MonoBehaviour
{
    [SerializeField] private float damage = 3;

    [SerializeField] private string targetTag;

    [SerializeField] private bool Pierce;
    [SerializeField] private bool Slash;
    [SerializeField] private bool Blunt;
    [SerializeField] private bool AN;
    [SerializeField] private bool Burn;
    [SerializeField] private int burnAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && collider.gameObject.CompareTag(targetTag))
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage, Pierce, Slash, Blunt, AN, Burn, burnAmount);
        }
    }
}