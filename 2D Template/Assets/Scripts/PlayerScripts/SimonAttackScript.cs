using UnityEngine;

public class SimonAttackScript : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.53f;
    private float timeToDamage = 0.26f;
    private float timer = 0f;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        if (attacking)
        {
            if (timer >= timeToDamage)
            {
                attackArea.SetActive(attacking);
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                //anim.SetBool("isAttacking", attacking);
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        //anim.SetBool("isAttacking", attacking);
    }
}
