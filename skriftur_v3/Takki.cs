using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Byrja() //Nota til að byrja
    {
        SceneManager.LoadScene(1);
    }
    public void Endir() //Til að enda
    {
        SceneManager.LoadScene(0);
       
    }
    
}
