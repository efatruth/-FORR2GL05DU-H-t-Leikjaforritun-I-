using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); // Finna RubyController � ��rum game object

        if (controller != null)
        {
            controller.ChangeHealth(-1); // M�nusa l�f spilarans um einn ef hann snertir ska�asv��i�
        }
    }
}
