using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start er kalla� ��ur en fyrsti rammur er uppf�r�ur
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); // Finna RubyController � ��rum game object

        if (controller != null)
        {
            if (controller.health < controller.maxHealth) // Ef l�f spilarans er minna en h�marks l�f
            {
                controller.ChangeHealth(1); // Auka l�f spilarans um einn
                Destroy(gameObject); // Ey�a health collectible game object
            }
        }
    }
}
