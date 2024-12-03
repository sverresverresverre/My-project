using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    public Transform gunPosition;

    [SerializeField]
    public GameObject bullet;

    [SerializeField]
    float timeBetweenShots = 0.3f;
    float timeSinceLastShot = 0;

    void Start()
    {
        // Vector2 position = new();

        // transform.position = position;
    }

    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 diff = (Vector2)transform.position - mouseCursorPos;

        transform.right = diff.normalized;

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            timeSinceLastShot = 0;

            Instantiate(bullet, gunPosition.position, Quaternion.identity);
            
        }
    }
}
