using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{
    public GameObject[] grade;
    public Image hp;
    public int score;
    public Text scoreText;

    void Start()
    {
        InvokeRepeating("MakeGrade", 1.0f, 1.5f);
        score = 0;
    }

    void MakeGrade()
    {
        Instantiate(grade[Random.Range(0, grade.Length)],
            new Vector2(Random.Range(-3.0f, 3.0f), 7), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        hp.fillAmount -= (1.0f / 100.0f) * Time.deltaTime;
        scoreText.text = score.ToString();
    }
}
