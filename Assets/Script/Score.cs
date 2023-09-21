using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text, scoreEnd, hiScore;
    public float score=0f;
    float highScore;
    public float[] mark = { 50, 100, 150, 200, 220, 300 };
    public GameObject gun1, gun2, spawnTree,laucher;
    GameObject gun1clone;
    // Start is called before the first frame update
    void Start()
    {
        gun1clone = Instantiate(gun1);
        gun1clone.SetActive(false);
        if (!PlayerPrefs.HasKey("HighScore"))
            highScore = 0f;
        else highScore = PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 5;
        if(score >= mark[0] && score < mark[1])
            gun1.SetActive(true);
        if (score >= mark[1] && score < mark[2])
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            
        }
        if (score >= mark[2] && score < mark[3])
            gun1.SetActive(true);
        if (score >= mark[3] && score < mark[4])
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
            spawnTree.SetActive(false);
        }
        if (score >= mark[4] && score < mark[5])
        {
            gun1.SetActive(true);
            gun1.transform.position = new Vector3(13, 0, 0);
            gun1.GetComponent<GunControl>().height = 3;
            gun2.SetActive(true);
            gun2.transform.position = new Vector3(-13, 0, 0);
            gun2.GetComponent<GunControl>().height = 3;
            laucher.SetActive(true);
        }
        if (score > mark[5])
        {
            gun1clone.SetActive(true);
            gun1clone.transform.position = new Vector3(13, 0, 0);
            gun1clone.GetComponent<GunControl>().height = 3;
            gun1clone.GetComponent<GunControl>().maxTime = 2.2f;
        }
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }    
        text.text = score.ToString("0.0") + "m";
        scoreEnd.text = score.ToString("0.0") + "m";
        hiScore.text = highScore.ToString("0.0") + "m";
    }
}
