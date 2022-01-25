using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyControll : MonoBehaviour
{
    private Transform enemyHolder;
    [Header("Controll")]
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    [SerializeField] private float speed;
    [Header("Fire")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;
    [Header("Text")]
    [SerializeField] private GameObject winText;
    [SerializeField] private Text restartText;
    private float nextShoot;


    private void Start()
    {
        winText.SetActive(false);
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
        Debug.Log(enemyHolder.childCount.ToString("0"));
    }

    private void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        Random rnd = new Random();
        
        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -xRange || enemy.position.x > xRange)
            {
                speed = -speed;
                enemyHolder.position += Vector3.back * 0.5f;
                return;
            }

            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + fireRate;
                Instantiate(bullet, enemy.position, enemy.rotation);
            }
            if (enemy.position.z <= -zRange)
            {
                GameOver.IsPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (enemyHolder.childCount == 0)
        {
            Debug.Log(enemyHolder.childCount.ToString("0"));
            Time.timeScale = 0;
            winText.SetActive(true);
            restartText.enabled = true;
        }
    }
}
