using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f; // Hraði spilarans
    public int maxHealth = 5; // Hámarks líf spilarans
    public GameObject projectilePrefab; // Forvarði fyrir skot

    public int health { get { return currentHealth; } } // Núverandi líf spilarans
    int currentHealth; // Núverandi líf spilarans

    public float timeInvincible = 2.0f; // Tími á ódrepandi
    bool isInvincible; // Er spilari ódrepandi
    float invincibleTimer; // Teljari fyrir ódrepandi

    Rigidbody2D rigidbody2d; // Rigidbody fyrir spilarann
    float horizontal; // Láréttur áttarstöðuhraði
    float vertical; // Lóðréttur áttarstöðuhraði

    Animator animator; // Animator fyrir spilarann
    Vector2 lookDirection = new Vector2(1, 0); // Átt sem spilari horfir á

    // Start er kallað áður en fyrsti rammur er uppfærður
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Fá Rigidbody úr skránna
        animator = GetComponent<Animator>(); // Fá Animator úr skránna

        currentHealth = maxHealth; // Setja núverandi líf sem hámarks líf
    }

    // Update er kallað einu sinni á hverjum ramma
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // Fá láréttan áttarstöðuhraða
        vertical = Input.GetAxis("Vertical"); // Fá lóðréttan áttarstöðuhraða

        Vector2 move = new Vector2(horizontal, vertical); // Skapa hreyfingu úr stýringunum

        // Athuga hvort að spilari er að hreyfast
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y); // Breyta horfunarstefnu eftir hreyfingu
            lookDirection.Normalize(); // Normaliza horfunarstefnu
        }

        // Uppfæra animator með nýju gildum
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude); // Lengd hreyfingarinnar

        // Athuga hvort að spilari sé ódrepandi
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime; // Minnka ódrepandatímann
            if (invincibleTimer < 0)
                isInvincible = false; // Láta spilarann vera drepandan aftur
        }

        // Athuga hvort að C hnappurinn sé ýtt á
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch(); // Skjóta
        }
    }

    // FixedUpdate er kallað á reglulega tíma
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position; // Núverandi staðsetning
        position.x = position.x + speed * horizontal * Time.deltaTime; // Uppfæra nýju láréttu staðsetningu
        position.y = position.y + speed * vertical * Time.deltaTime; // Uppfæra nýju lóðréttu staðsetningu

        rigidbody2d.MovePosition(position); // Færa spilarann
    }

    // Breyta lífi spilarans
    public void ChangeHealth(int amount)
    {
        // Ef að breytingin á lífi er neikvæð
        if (amount < 0)
        {
            // Ef að spilari er ódrepandi
            if (isInvincible)
                return; // Hætta hér

            isInvincible = true; // Gerast ódrepandi
            invincibleTimer = timeInvincible; // Endurstilla ódrepandatímann
        }

        // Uppfæra núverandi líf
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth); // Skrifa út núverandi og hámarks líf
    }

    // Skjóta
    void Launch()
    {
        // Búa til nýtt skot
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        // Fá Projectile úr skoti
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // Skjóta
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch"); // Spila skjóta animation
    }
}
