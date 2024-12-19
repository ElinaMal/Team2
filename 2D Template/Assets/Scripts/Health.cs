using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 100;

    [SerializeField] private float MAX_HEALTH = 100;

    [SerializeField] public int defense = 1;

    [SerializeField] public bool pierceRes = false;
    [SerializeField] public bool slashRes = false;
    [SerializeField] public bool bluntRes = false;
    [SerializeField] public bool burnRes = false;
    public bool isBurning = false;

    private float finalDamage;


    
    public Animator anim;
    

    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float amount, bool Pierce, bool Slash, bool Blunt, bool AN, bool Burn, int burnAmount)
    {
        /*
        anim.SetTrigger("isHurt");
        */

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Damage");
        }

        finalDamage = amount;

        if (slashRes && Slash)
        {
            finalDamage = amount / 2;
        }

        if (pierceRes && Pierce)
        {
            finalDamage = amount / 2;
        }

        if (bluntRes && Blunt)
        {
            finalDamage = amount / 2;
        }

        Debug.Log(finalDamage);

        if (AN == false && finalDamage - defense !< 0)
        {
            this.health -= finalDamage - defense;
        }

        if (AN == true)
        {
            this.health -= finalDamage;
        }

        if (finalDamage - defense <= 0)
        {
            Debug.Log("Armor fully negated damage");
        }

        if (Burn && burnRes == false)
        {
            Burning(burnAmount);
        }

        //if (GetComponent<Hearts>() != null)
        //{
        //    Hearts hearts = GetComponent<Hearts>();
        //    hearts.Damage(1);
        //}

        if (health <= 0 && isDead == false)
        {
            Die();
        }
    }

    public void Burning(int burnAmount)
    {
        Debug.Log("I am on fire!");
        for (int i = 0; i < burnAmount; i++)
        {
            Damage(1, false, false, false, true, false, 0);
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Healing");
        }

        bool wouldOverheal = health + amount > MAX_HEALTH;

        if (wouldOverheal)
        {
            this.health = MAX_HEALTH;
        }

        this.health += amount;
    }

    private void Die()
    {
        Debug.Log("I am Dead!");

        //anim.ResetTrigger("isHurt");
        anim.SetBool("isDying", true);

        isDead = true;
        gameObject.tag = "Dead";

        if (GetComponent<EnemyMovement>() != null)
        {
            GetComponent<EnemyMovement>().enabled = false;
        }
        if (GetComponent<UndeadChasePlayer>() != null)
        {
            GetComponent<UndeadChasePlayer>().enabled = false;
        }
        if (GetComponent<EnemyChasing>() != null)
        {
            GetComponent<EnemyChasing>().enabled = false;
        }
        if (GetComponent<NPCRangedAttack>() != null)
        {
            GetComponent<NPCRangedAttack>().enabled = false;
        }
        if (GetComponent<Movement>() != null)
        {
            GetComponent<Movement>().enabled = false;
        }
    }

}
