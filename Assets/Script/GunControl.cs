using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject bullet;
    public float height = 0.5f;
    public float maxTime = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        timer = maxTime;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(timer >= maxTime)
        {
            GameObject temp= Instantiate(bullet, transform.position + new Vector3(0, UnityEngine.Random.Range(-height,height),0),bullet.transform.rotation );
            
            Destroy(temp, 3f);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}