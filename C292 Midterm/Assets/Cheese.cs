using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheese : MonoBehaviour
{

    private int ratCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag.Equals("Player")) {
            Destroy(collider.gameObject);
            ratCount = ratCount + 1;
            if (ratCount >= 3) {
                ratCount = 0;
                LoadNextLevel();
            }
        }
    }

    void LoadNextLevel() {
        int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(NextLevel);
    }
}
