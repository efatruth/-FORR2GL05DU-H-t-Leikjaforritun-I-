using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start er kallað áður en fyrsti rammur er uppfærður
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); // Finna RubyController í öðrum game object

        if (controller != null)
        {
            if (controller.health < controller.maxHealth) // Ef líf spilarans er minna en hámarks líf
            {
                controller.ChangeHealth(1); // Auka líf spilarans um einn
                Destroy(gameObject); // Eyða health collectible game object
            }
        }
    }
}
