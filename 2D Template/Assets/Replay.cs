using UnityEngine;
using UnityEngine.SceneManagement;


public class Replay : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private EnemyNumberTracker enemyNumberTracker;
   
   
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            enemyNumberTracker.timePassed = 0;
        }
    }

