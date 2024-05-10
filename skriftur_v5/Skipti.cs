using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Byrjun"); // Skrifar út "Byrjun" þegar object er búið til
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hóho"); // Skrifar út "Hóho" þegar annað object snertir þetta object
        other.gameObject.SetActive(false); // Gerir object-inu sem snerti þetta óvirkt
        StartCoroutine(Bida()); // Kallar á fallið "Bida" sem biður í smá stund
    }

    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3); // Biður í 3 sekúndur
        Endurræsa(); // Kallar á fallið "Endurræsa" til að hlaða næstu senu
    }

    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Hlaða inn næstu senu
    }
}
