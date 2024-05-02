using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; // Hra�i hreyfingar
    public bool vertical; // Segir til um hvort hreyfingin s� l��r�tt e�a l�r�tt
    public float changeTime = 3.0f; // T�mi milli �ttabreytinga

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1; // �tt sem �vinurinn er a� fer�ast �
    bool broken = true; // Segir til um hvort �vinurinn s� skemmdur e�a ekki

    Animator animator;

    // Start er kalla�ur ��ur en fyrsta ramma uppf�rir
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // S�kja Rigidbody2D komponentinn
        timer = changeTime; // Upphafsgildi fyrir breytuna timer
        animator = GetComponent<Animator>(); // S�kja Animator komponentinn
    }

    void Update()
    {
        // Athuga hvort �vinurinn s� ekki skemmdur, ef svo er, h�tta vi�
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime; // L�ta timer telja ni�ur

        if (timer < 0) // Ef timer er or�inn minni en 0
        {
            direction = -direction; // Breyta �ttinni
            timer = changeTime; // Endurstilla timer
        }
    }

    void FixedUpdate()
    {
        // Athuga hvort �vinurinn s� ekki skemmdur, ef svo er, h�tta vi�
        if (!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position; // S�kja sta�setninguna

        if (vertical) // Ef hreyfingin er l��r�tt
        {
            position.y = position.y + Time.deltaTime * speed * direction; // Hreyfa � l��r�ttu �ttina
            animator.SetFloat("Move X", 0); // Setja hra�astillingu X
            animator.SetFloat("Move Y", direction); // Setja hra�astillingu Y
        }
        else // Ef hreyfingin er ekki l��r�tt (l�r�tt)
        {
            position.x = position.x + Time.deltaTime * speed * direction; // Hreyfa � l�r�ttu �ttina
            animator.SetFloat("Move X", direction); // Setja hra�astillingu X
            animator.SetFloat("Move Y", 0); // Setja hra�astillingu Y
        }

        rigidbody2D.MovePosition(position); // F�ra rigidbody2D � n�ja sta�setningu
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>(); // S�kja RubyController komponentann fr� annarri leikhlut

        if (player != null)
        {
            player.ChangeHealth(-1); // M�nusa l�f spilarans um eitt
        }
    }

    // Public �v� vi� viljum kalla � �etta annarssta�ar eins og � projectile scriptunni
    public void Fix()
    {
        broken = false; // Endurstilla skemmda st��una
        rigidbody2D.simulated = false; // H�tta a� reikna hreyfingar
        // Valkv�mt ef �� b�tir vi� fastri animation
        animator.SetTrigger("Fixed"); // Virkja fastri animation
    }
}
