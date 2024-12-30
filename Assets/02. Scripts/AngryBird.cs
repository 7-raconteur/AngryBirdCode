using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngryBird : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int bigpigScore = 50;
    private int minipigScore = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = TextMeshProUGUI.FindObjectOfType<TextMeshProUGUI>(scoreText);
        Debug.Log(scoreText.text);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BigPig")
        {
            Debug.Log(collision.gameObject.name);
            int score = int.Parse(scoreText.text);
            
            int newScore = score + bigpigScore; 
            
            scoreText.text = newScore.ToString();
            
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.tag == "MiniPig")
        {
            Debug.Log(collision.gameObject.name);
            int score = int.Parse(scoreText.text);
            
            int newScore = score + minipigScore;
            
            scoreText.text = newScore.ToString();
            collision.gameObject.SetActive(false);

        }
    }


 
    
}
