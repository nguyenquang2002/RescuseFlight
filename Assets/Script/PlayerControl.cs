using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 5;
    public GameObject sky;
    public GameObject gameOverObject;
    public float gravity = 9.8f;
    Vector3 direct;
    public AudioSource auS1,auS2;
    public AudioClip flySound,deadSound;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            direct = Vector3.up * speed;
            if(auS1 && flySound)
                auS1.PlayOneShot(flySound);
        }
            
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direct = Vector3.up * speed;
                if (auS1 && flySound)
                    auS1.PlayOneShot(flySound);
            }    
                
        }
        direct.y -= gravity * Time.deltaTime;
        transform.position += direct * Time.deltaTime;
    }
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
        auS1.mute = false;
        Time.timeScale = 1;
    }
    void GameOver()
    {
        gameOverObject.SetActive(true);
        if (auS2 && deadSound)
            auS2.PlayOneShot(deadSound);
        auS1.mute = true;
        Time.timeScale = 0;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == sky)
            return;
        GameOver();
    }
}
