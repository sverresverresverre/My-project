using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    float speed;

    GameObject player;

    void Start()
    {
        speed = Random.Range(3, 8);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // distance = Vector2.Distance(transform.position, player.transform.position);
        // Vector2 direction = player.transform.position - transform.position;

        // print(player.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bullet")
        {
            Destroy(this.gameObject);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController controller = player.GetComponent<PlayerController>();

            controller.AddPoints(100);
        }
    }
}
