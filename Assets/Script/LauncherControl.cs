using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    public GameObject rocket1,rocket2;
    public float height = 2.5f;
    public float maxTime = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (timer >= maxTime)
        {
            float r = Random.Range(0, 2);
            GameObject temp;
            if (r < 1)
            {
                temp = Instantiate(rocket1, transform.position + new Vector3(0, Random.Range(-height, height), 0), rocket1.transform.rotation);
            }
            else
            {
                temp = Instantiate(rocket2, transform.position + new Vector3(0, Random.Range(-height, height), 0), rocket2.transform.rotation);
            }
            Destroy(temp, 5f);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}