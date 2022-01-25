using UnityEngine;

public class BulletControll : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform bullet;
    [SerializeField] private int scoreValue;
    private PlayerScore playerScore;

    private void Start()
    {
        GameObject Score = GameObject.FindWithTag("Score");
        if (Score != null)
        {
            playerScore = Score.GetComponent<PlayerScore>();
        }

        if (Score == null)
        {
            Debug.Log("Ошибка контроллера очков");
        }
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.forward * speed;

        if (bullet.position.z >= 25f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Collision");
            Destroy(other.gameObject);
            Destroy(gameObject);
            playerScore.AddScore(scoreValue);
        }
        else if (other.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
