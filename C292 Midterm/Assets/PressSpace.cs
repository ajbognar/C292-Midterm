using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PressStart();
    }

    void PressStart() {
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Level1");
        } 
    }
}
