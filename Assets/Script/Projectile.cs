using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class Projectile : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public int enemyFix;
    public int enemyBroken;
    [SerializeField]
    TextMeshProUGUI enemieFix;

    // Awake is called when the Projectile GameObject is instantiated
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }


    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        EnemiesContainers containers = other.GetComponent<EnemiesContainers>();
      //  containers.AddEnemie();
       // containers.RemoveEnemie();
        if (enemy != null)
        {

            enemy.Fix();

           // containers.AddEnemie();
           // containers.RemoveEnemie();
            // enemyFix = enemyFix + 1;
            //Debug.Log("+1");

            //Debug.Log("-1");
            // enemyBroken = enemyBroken -1;
            // enemieFix.TextMeshProUGUI = gameObject.ToString();



        }

        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        Destroy(gameObject);



    }

}