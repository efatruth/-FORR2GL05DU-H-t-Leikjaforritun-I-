using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    // Fall sem kallar � a� hla�a n�stu senu og endurstillir stigin � RubyController
    public void Byrja()
    {
        SceneManager.LoadScene(1); // Hla�a inn n�stu senu
        RubyController.stig = 0; // Endurstilla stigin � RubyController
    }
}
