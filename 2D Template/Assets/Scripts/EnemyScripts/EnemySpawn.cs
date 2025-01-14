using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    public int enemyNumberLimit;
    public EnemyNumberTracker enemyNumber;
    private float timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        setTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        
        if (enemyNumber.levelUpScore >= 30 && enemyNumberLimit < 400)
        {
            enemyNumberLimit += 40;
        }

        if (timeUntilSpawn <= 0 && enemyNumber.enemyCounter < enemyNumberLimit)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyNumber.enemyCounter++;
            setTimeUntilSpawn();
        }
        
    }

    void setTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
