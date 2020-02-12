using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardblockGenerator : MonoBehaviour
{
    public GameObject hardblock;
    public GameObject softblock;
    MapReader mapReader;
    
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                GameObject hard = Instantiate(hardblock) as GameObject;
                //Debug.Log(mapReader.csvDatas[i][j]);

                if (mapReader.csvDatas[i][j] == "9")
                {
                    hard.transform.position = new Vector3(i * 0.4f - 3.0f, j * 0.4f - 3.8f, 0);
                }
 
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
