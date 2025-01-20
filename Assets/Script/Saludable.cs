using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saludable : MonoBehaviour
{
    // Start is called before the first frame update
    //audio
    public AudioClip collectedClip;



    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();


        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
           // controller.PlaySound(collectedClip);
        }
    }


}
