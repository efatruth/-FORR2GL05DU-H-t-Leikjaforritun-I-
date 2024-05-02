using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; // Hraði hreyfingar
    public bool vertical; // Segir til um hvort hreyfingin sé lóðrétt eða lárétt
    public float changeTime = 3.0f; // Tími milli áttabreytinga

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1; // Átt sem óvinurinn er að ferðast í
    bool broken = true; // Segir til um hvort óvinurinn sé skemmdur eða ekki

    Animator animator;

    // Start er kallaður áður en fyrsta ramma uppfærir
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Sækja Rigidbody2D komponentinn
        timer = changeTime; // Upphafsgildi fyrir breytuna timer
        animator = GetComponent<Animator>(); // Sækja Animator komponentinn
    }

    void Update()
    {
        // Athuga hvort óvinurinn sé ekki skemmdur, ef svo er, hætta við
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime; // Láta timer telja niður

        if (timer < 0) // Ef timer er orðinn minni en 0
        {
            direction = -direction; // Breyta áttinni
            timer = changeTime; // Endurstilla timer
        }
    }

    void FixedUpdate()
    {
        // Athuga hvort óvinurinn sé ekki skemmdur, ef svo er, hætta við
        if (!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position; // Sækja staðsetninguna

        if (vertical) // Ef hreyfingin er lóðrétt
        {
            position.y = position.y + Time.deltaTime * speed * direction; // Hreyfa í lóðréttu áttina
            animator.SetFloat("Move X", 0); // Setja hraðastillingu X
            animator.SetFloat("Move Y", direction); // Setja hraðastillingu Y
        }
        else // Ef hreyfingin er ekki lóðrétt (lárétt)
        {
            position.x = position.x + Time.deltaTime * speed * direction; // Hreyfa í láréttu áttina
            animator.SetFloat("Move X", direction); // Setja hraðastillingu X
            animator.SetFloat("Move Y", 0); // Setja hraðastillingu Y
        }

        rigidbody2D.MovePosition(position); // Færa rigidbody2D í nýja staðsetningu
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>(); // Sækja RubyController komponentann frá annarri leikhlut

        if (player != null)
        {
            player.ChangeHealth(-1); // Mínusa líf spilarans um eitt
        }
    }

    // Public því við viljum kalla á þetta annarsstaðar eins og í projectile scriptunni
    public void Fix()
    {
        broken = false; // Endurstilla skemmda stöðuna
        rigidbody2D.simulated = false; // Hætta að reikna hreyfingar
        // Valkvæmt ef þú bætir við fastri animation
        animator.SetTrigger("Fixed"); // Virkja fastri animation
    }
}
