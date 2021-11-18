using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float xPos = 0;
    [SerializeField] float yPos = 0;
    [SerializeField] GameObject _playerPrefab;
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
            Instantiate(_playerPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
    }
}
