using UnityEngine;

public class EnemyBulletControll : MonoBehaviour
{
    private Transform bullet;
    [SerializeField] private float speed;
    [SerializeField] private float zRange; //5f

    private void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.back * speed;
        if (bullet.position.z <= -zRange)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.IsPlayerDead = true; 
            Debug.Log(GameOver.IsPlayerDead.ToString());
        }
        else if (other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.healt -= 1;
            Destroy(gameObject);
        }
    }
}
