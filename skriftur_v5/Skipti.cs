using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Byrjun"); // Skrifar �t "Byrjun" �egar object er b�i� til
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("H�ho"); // Skrifar �t "H�ho" �egar anna� object snertir �etta object
        other.gameObject.SetActive(false); // Gerir object-inu sem snerti �etta �virkt
        StartCoroutine(Bida()); // Kallar � falli� "Bida" sem bi�ur � sm� stund
    }

    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3); // Bi�ur � 3 sek�ndur
        Endurr�sa(); // Kallar � falli� "Endurr�sa" til a� hla�a n�stu senu
    }

    public void Endurr�sa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Hla�a inn n�stu senu
    }
}
