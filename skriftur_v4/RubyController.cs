using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f; // Hra�i spilarans
    public int maxHealth = 5; // H�marks l�f spilarans
    public GameObject projectilePrefab; // Forvar�i fyrir skot

    public int health { get { return currentHealth; } } // N�verandi l�f spilarans
    int currentHealth; // N�verandi l�f spilarans

    public float timeInvincible = 2.0f; // T�mi � �drepandi
    bool isInvincible; // Er spilari �drepandi
    float invincibleTimer; // Teljari fyrir �drepandi

    Rigidbody2D rigidbody2d; // Rigidbody fyrir spilarann
    float horizontal; // L�r�ttur �ttarst��uhra�i
    float vertical; // L��r�ttur �ttarst��uhra�i

    Animator animator; // Animator fyrir spilarann
    Vector2 lookDirection = new Vector2(1, 0); // �tt sem spilari horfir �

    // Start er kalla� ��ur en fyrsti rammur er uppf�r�ur
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // F� Rigidbody �r skr�nna
        animator = GetComponent<Animator>(); // F� Animator �r skr�nna

        currentHealth = maxHealth; // Setja n�verandi l�f sem h�marks l�f
    }

    // Update er kalla� einu sinni � hverjum ramma
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // F� l�r�ttan �ttarst��uhra�a
        vertical = Input.GetAxis("Vertical"); // F� l��r�ttan �ttarst��uhra�a

        Vector2 move = new Vector2(horizontal, vertical); // Skapa hreyfingu �r st�ringunum

        // Athuga hvort a� spilari er a� hreyfast
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y); // Breyta horfunarstefnu eftir hreyfingu
            lookDirection.Normalize(); // Normaliza horfunarstefnu
        }

        // Uppf�ra animator me� n�ju gildum
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude); // Lengd hreyfingarinnar

        // Athuga hvort a� spilari s� �drepandi
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime; // Minnka �drepandat�mann
            if (invincibleTimer < 0)
                isInvincible = false; // L�ta spilarann vera drepandan aftur
        }

        // Athuga hvort a� C hnappurinn s� �tt �
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch(); // Skj�ta
        }
    }

    // FixedUpdate er kalla� � reglulega t�ma
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position; // N�verandi sta�setning
        position.x = position.x + speed * horizontal * Time.deltaTime; // Uppf�ra n�ju l�r�ttu sta�setningu
        position.y = position.y + speed * vertical * Time.deltaTime; // Uppf�ra n�ju l��r�ttu sta�setningu

        rigidbody2d.MovePosition(position); // F�ra spilarann
    }

    // Breyta l�fi spilarans
    public void ChangeHealth(int amount)
    {
        // Ef a� breytingin � l�fi er neikv��
        if (amount < 0)
        {
            // Ef a� spilari er �drepandi
            if (isInvincible)
                return; // H�tta h�r

            isInvincible = true; // Gerast �drepandi
            invincibleTimer = timeInvincible; // Endurstilla �drepandat�mann
        }

        // Uppf�ra n�verandi l�f
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth); // Skrifa �t n�verandi og h�marks l�f
    }

    // Skj�ta
    void Launch()
    {
        // B�a til n�tt skot
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        // F� Projectile �r skoti
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // Skj�ta
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch"); // Spila skj�ta animation
    }
}
