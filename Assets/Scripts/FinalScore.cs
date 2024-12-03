using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField]
    TMP_Text FinalResult;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        int pointFinal = PlayerController.points;

        FinalResult.text = pointFinal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
