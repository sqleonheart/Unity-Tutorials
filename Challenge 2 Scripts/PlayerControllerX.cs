using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool isReady = true;
    private int cooldown = 3;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isReady)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                isReady = false;
            }
        }
    }
}
