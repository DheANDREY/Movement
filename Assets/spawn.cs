using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawn : MonoBehaviour
{
    public GameObject Bar1;
    public bool spawnBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnBar)
        {
            spawnBar = false;
            munculBar();
  

        }
    }
    private void munculBar(int x = -30)
    {
        //for (int i = 1; i < 3; i++)
        //{
            GameObject g = Instantiate(Bar1, new Vector3(x, 0, 0), Quaternion.identity) as GameObject;
            g.transform.SetParent(GameObject.FindGameObjectWithTag("bar").transform, false);
       // }
    }
}
