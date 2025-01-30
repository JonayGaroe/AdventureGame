using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class EnemyController : MonoBehaviour
{

    // bool para los enemigos
    bool broken = true;

    // ANIMATOR
    Animator animator;



    // Public variables
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public ParticleSystem smokeEffect;
    // Private variables
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;
    [SerializeField]
    TextMeshProUGUI enemieFix;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
        EnemiesContainers.instance.AddEnemie();

    }


    // Update is called every frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();


        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }


    public void Fix()
    {

        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        EnemiesContainers.instance.RemoveEnemie();

        // EnemiesContainers.AddEnemie();
        //  EnemiesContainers.RemoveEnemie();


        if (smokeEffect != null)
        {
            smokeEffect.Stop();
        }
        else
        {
            Debug.LogWarning("SmokeEffect no est� asignado en el EnemyController.");
        }

    }

}



//para que se pare la musica
//   AudioSource audioSource = GetComponent<AudioSource>();

//if (audioSource != null && audioSource.isPlaying)
//  {
//   audioSource.Stop();
// }