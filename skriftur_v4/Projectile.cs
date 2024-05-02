using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Rigidbody fyrir skot
    // Awake er kalla� �egar skr�nna er lesin inn � minni�
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // F� Rigidbody �r skr�nna
    }

    // Launch falli� er nota� til a� kasta skoti � gefna �tt me� gefinni krafti
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); // B�ta krafti vi� skot
    }

    // Update er kalla� � hverjum ramma
    void Update()
    {
        // Ef sta�setning skotsins er st�rri en 1000 einingar
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject); // Ey�a skotinu
        }
    }

    // OnCollisionEnter2D er kalla� �egar hlutur rekst � annan hlut
    void OnCollisionEnter2D(Collision2D other)
    {
        // F� EnemyController ef rekst � �vin
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null) // Ef �vinurinn er ekki null
        {
            e.Fix(); // Laga �vininn
        }

        Destroy(gameObject); // Ey�a skotinu
    }
}
