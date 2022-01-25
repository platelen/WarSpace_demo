using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controll")]
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    [Header("Fire")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform startBullet;
    [SerializeField] private float fireRate;

    private float nextFire;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        MoveControll();
    }

    private void Update()
    {
        ShootControll();
    }

    private void ShootControll()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, startBullet.position, startBullet.rotation);
        }
    }
    private void MoveControll()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }



        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

    }
}
