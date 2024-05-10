using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    // Fall sem kallar á að hlaða næstu senu og endurstillir stigin í RubyController
    public void Byrja()
    {
        SceneManager.LoadScene(1); // Hlaða inn næstu senu
        RubyController.stig = 0; // Endurstilla stigin í RubyController
    }
}
