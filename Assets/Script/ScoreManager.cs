using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    private int score = 0;
    private int HighScore = 0; 
    private GameObject scoreObj;
    private GameObject HighScoreObj;
    public int Life = 3;
    public TMP_Text life;
    
    //créer un si ScoreManager x2 dans la scene en détruire 1

    private void Awake()
    {
        scoreObj= GameObject.FindWithTag("Score");
       // HighScoreObj= GameObject.FindWithTag("HighScore");
        scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        //highScoreText =HighScoreObj.GetComponent<TextMeshProUGUI>();
        instance = this;
    }

    void Start()
    {
        
        scoreText.text = $"{score} POINTS";
       // highScoreText.text= $"HighScore: {HighScore}";
       
    }
    

    public void TankPoints()
    {
        score += 100;
        scoreText.text = score.ToString() + "POINTS";
       
    }

    public void RangedTankPoints()
    {
        score += 500;
        scoreText.text = score.ToString() + "POINTS";
       
    }
    public void MeleeTankPoints()
    {
        score += 300;
        scoreText.text = score.ToString() + "POINTS";
        
    }
    public void LifeCount()
    {
        //life -= 1;
       // lifeText.text = $"{life} POINTS";
        
    }
    

     
}
