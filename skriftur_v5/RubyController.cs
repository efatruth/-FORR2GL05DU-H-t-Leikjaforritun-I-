using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RubyController : MonoBehaviour
{
    // Opinberar breytur
    public float speed = 3.0f; // Hraði fyrir hreyfingu Rubys

    // Einka breytur
    Rigidbody2D rigidbody2d; // Viðmiðunarflökt 2D hlutur
    float horizontal; // Horizontal stýringar gildi
    float vertical; // Lóðrétt stýringar gildi
    public static int stig; // Statískur breyta til að geyma stig
    public TextMeshProUGUI countText; // Texti UI hlutur til að sýna stig

    Animator animator; // Viðmiðunarhlutur
    Vector2 lookDirection = new Vector2(1, 0); // Vigur til að geyma stefnu áhorfandans

    // Start er kallað fyrir fyrsta rammauppfærsluna
    void Start()
    {
        // Fá viðmiðunarflökt 2D hlut
        rigidbody2d = GetComponent<Rigidbody2D>();
        // Fá viðmiðunarhlut
        animator = GetComponent<Animator>();
        // Upphafsstilla stig sem 0
        stig = 0;
        // Uppfæra texta um stig
        SetCountText();
    }

    // Update er kallað einu sinni á hverri rammauppfærslu
    void Update()
    {
        // Fá horizontal og lóðrétt stýringar gildi
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Búa til hreyfingu vigur út frá stýringum
        Vector2 move = new Vector2(horizontal, vertical);

        // Uppfæra stefnuhorfandi miðað við hreyfingu vigurs
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        // Uppfæra viðmiðunar breytur
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    // FixedUpdate er kallað á fastan fjölda sinnum á sekúndu
    void FixedUpdate()
    {
        // Reikna nýja staðsetningu miðað við stýringar og hraða
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        // Færa Ruby á nýju staðsetningu
        rigidbody2d.MovePosition(position);
    }

    // Kallað þegar Ruby rekst á annan hlut
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Athuga merki samræmis og uppfæra stig eftir því
        if (collision.collider.tag == "skrimsli")
        {
            stig -= 1; // Minka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut óvirkan
        }
        if (collision.collider.tag == "orn")
        {
            stig -= 2; // Minka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut óvirkan
        }
        if (collision.collider.tag == "gim")
        {
            stig += 1; // Auka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut óvirkan
        }
        // Uppfæra texta um stig
        SetCountText();
    }

    // Uppfærir texta um stig
    void SetCountText()
    {
        countText.text = "Stig: " + stig.ToString(); // Sýna núverandi stig
    }
}
