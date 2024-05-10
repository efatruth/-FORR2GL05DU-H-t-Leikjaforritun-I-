using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RubyController : MonoBehaviour
{
    // Opinberar breytur
    public float speed = 3.0f; // Hra�i fyrir hreyfingu Rubys

    // Einka breytur
    Rigidbody2D rigidbody2d; // Vi�mi�unarfl�kt 2D hlutur
    float horizontal; // Horizontal st�ringar gildi
    float vertical; // L��r�tt st�ringar gildi
    public static int stig; // Stat�skur breyta til a� geyma stig
    public TextMeshProUGUI countText; // Texti UI hlutur til a� s�na stig

    Animator animator; // Vi�mi�unarhlutur
    Vector2 lookDirection = new Vector2(1, 0); // Vigur til a� geyma stefnu �horfandans

    // Start er kalla� fyrir fyrsta rammauppf�rsluna
    void Start()
    {
        // F� vi�mi�unarfl�kt 2D hlut
        rigidbody2d = GetComponent<Rigidbody2D>();
        // F� vi�mi�unarhlut
        animator = GetComponent<Animator>();
        // Upphafsstilla stig sem 0
        stig = 0;
        // Uppf�ra texta um stig
        SetCountText();
    }

    // Update er kalla� einu sinni � hverri rammauppf�rslu
    void Update()
    {
        // F� horizontal og l��r�tt st�ringar gildi
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // B�a til hreyfingu vigur �t fr� st�ringum
        Vector2 move = new Vector2(horizontal, vertical);

        // Uppf�ra stefnuhorfandi mi�a� vi� hreyfingu vigurs
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        // Uppf�ra vi�mi�unar breytur
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    // FixedUpdate er kalla� � fastan fj�lda sinnum � sek�ndu
    void FixedUpdate()
    {
        // Reikna n�ja sta�setningu mi�a� vi� st�ringar og hra�a
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        // F�ra Ruby � n�ju sta�setningu
        rigidbody2d.MovePosition(position);
    }

    // Kalla� �egar Ruby rekst � annan hlut
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Athuga merki samr�mis og uppf�ra stig eftir �v�
        if (collision.collider.tag == "skrimsli")
        {
            stig -= 1; // Minka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut �virkan
        }
        if (collision.collider.tag == "orn")
        {
            stig -= 2; // Minka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut �virkan
        }
        if (collision.collider.tag == "gim")
        {
            stig += 1; // Auka stig
            collision.collider.gameObject.SetActive(false); // Gera hlut �virkan
        }
        // Uppf�ra texta um stig
        SetCountText();
    }

    // Uppf�rir texta um stig
    void SetCountText()
    {
        countText.text = "Stig: " + stig.ToString(); // S�na n�verandi stig
    }
}
