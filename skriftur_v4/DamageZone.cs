using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); // Finna RubyController í öðrum game object

        if (controller != null)
        {
            controller.ChangeHealth(-1); // Mínusa líf spilarans um einn ef hann snertir skaðasvæðið
        }
    }
}
