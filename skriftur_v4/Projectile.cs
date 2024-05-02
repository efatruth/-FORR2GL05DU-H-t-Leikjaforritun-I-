using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Rigidbody fyrir skot
    // Awake er kallað þegar skránna er lesin inn í minnið
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Fá Rigidbody úr skránna
    }

    // Launch fallið er notað til að kasta skoti í gefna átt með gefinni krafti
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); // Bæta krafti við skot
    }

    // Update er kallað í hverjum ramma
    void Update()
    {
        // Ef staðsetning skotsins er stærri en 1000 einingar
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject); // Eyða skotinu
        }
    }

    // OnCollisionEnter2D er kallað þegar hlutur rekst á annan hlut
    void OnCollisionEnter2D(Collision2D other)
    {
        // Fá EnemyController ef rekst á óvin
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null) // Ef óvinurinn er ekki null
        {
            e.Fix(); // Laga óvininn
        }

        Destroy(gameObject); // Eyða skotinu
    }
}
