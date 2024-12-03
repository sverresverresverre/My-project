using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Slider hpBar;

    [SerializeField]
    int maxHealth = 5;
    public static int currentHealth = 5;
    public static int startHealth;

    [SerializeField]
    TMP_Text pointsText;

    [SerializeField]
    TMP_Text AmountOfHearts;

    [SerializeField]
    GameObject easyDoor;

    [SerializeField]
    GameObject hardDoor;

    [SerializeField]
    GameObject victoryConfirmed;

    [SerializeField]
    public int winPoints;

    public static int points = 0;

    public static int startPoints;

    public static int hearts = 2;

    public static int currentScene;

    public static int roomComplete;

    void Start()
    {
        hpBar.value = currentHealth;

        AddPoints(0);

        pointsText.text = points.ToString();

        AmountOfHearts.text = hearts.ToString();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xInput, yInput) * speed * Time.deltaTime;

        transform.Translate(movement);

        if (points >= winPoints + startPoints)
        {
            easyDoor.SetActive(true);
            hardDoor.SetActive(true);
            victoryConfirmed.SetActive(true);
        }

        if (hearts <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void Victory(int amount)
    {
        roomComplete += amount;

        if (roomComplete == 3)
        {
            SceneManager.LoadScene(4);
        }
    }

    void HeartDecrease(int amount)
    {
        hearts -= amount;
        AmountOfHearts.text = hearts.ToString();
        currentHealth = maxHealth;
        hpBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            currentHealth--;
            hpBar.value = currentHealth;

            if (currentHealth <= 0)
            {
                HeartDecrease(1);

                SceneManager.LoadScene(currentScene);
                currentHealth = maxHealth;
                points = startPoints;
            }
        }

        if(other.tag == "Easydoor")
        {
            SceneManager.LoadScene(2);
            startPoints = points;
            startHealth = currentHealth;
            currentScene = 2;
        }

        if(other.tag == "Harddoor")
        {
            SceneManager.LoadScene(3);
            startPoints = points;
            startHealth = currentHealth;
            currentScene = 3;
        }
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointsText.text = points.ToString();
    }
}
