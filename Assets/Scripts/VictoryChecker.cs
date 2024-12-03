using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerController controller = player.GetComponent<PlayerController>();

        controller.Victory(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
