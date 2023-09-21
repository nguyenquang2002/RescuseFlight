using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeControl : MonoBehaviour
{
    public GameObject tree1,tree2,tree3;
    public float scalePlus = 0.15f;
    public float maxTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > maxTime)
        {
            float r = Random.Range(0, 3);
            GameObject temp;
            if(r < 1)
            {
                temp = Instantiate(tree1, transform.position, Quaternion.identity);
            }
            else if(r < 2)
            {
                temp = Instantiate(tree2, transform.position, Quaternion.identity);
            }
            else
            {
                temp = Instantiate(tree3, transform.position, Quaternion.identity);
            }
            float s = Random.Range(-scalePlus, 0);
            temp.transform.localScale = new Vector3(1 + s, 1 + s);
            Destroy(temp, 9f);
            timer = 0;
            
        }
        timer += Time.deltaTime;
    }
}
