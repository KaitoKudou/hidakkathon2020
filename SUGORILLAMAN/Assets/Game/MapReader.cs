using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapReader : MonoBehaviour
{
    TextAsset map;
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    GameObject hardblock;
    GameObject softblock;
    GameObject appleman;
    GameObject bananaman;
    GameObject sharkman;
    GameObject hamburgerman;
    GameObject playerInstance;
    Rigidbody2D rigid2D;
    //float moveForce = 10.6f;
    

    public GameObject hardblockPrefab;
    public GameObject softblockPrefab;
    public GameObject applemanPrefeb;
    public GameObject bananamanPrefab;
    public GameObject sharkmanPrefab;
    public GameObject hamburgermanPrefab;
    public GameObject playerPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        //hardblock = GameObject.Find("hardblock");
        //softblock = GameObject.Find("softblock");
        //appleman = GameObject.Find("appleman_wait_01");
        //bananaman = GameObject.Find("bananaman_wait_01");
        //sharkman = GameObject.Find("shark_left_01");
        //hamburgerman = GameObject.Find("hamburger_wait_01");
        //player = GameObject.Find("sugorillaman_front_01");

        this.rigid2D = GetComponent<Rigidbody2D>();

        map = Resources.Load("map") as TextAsset; // Resouces下のCSV読み込み
        //Debug.Log(map.text);
        StringReader reader = new StringReader(map.text);


        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() > -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            

        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        //Debug.Log(csvDatas[0][1]);

        /*for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                Debug.Log(csvDatas[i][j]);
                //GameObject hard = Instantiate(hardblockPrefab) as GameObject;
                //hard.transform.position = new Vector3(j * 0.6f - 4.3f, i * 0.6f - 3.5f, 0);

                
                // hard block
                if (csvDatas[i][j] == "9")
                {
                    GameObject hard = Instantiate(hardblockPrefab) as GameObject;
                    hard.transform.position = new Vector3(j * 0.6f - 4.3f, i * 0.6f - 3.5f, 0);
                }

                // soft block
                else if (csvDatas[i][j] == "1" || csvDatas[i][j] == "11" || csvDatas[i][j] == "12" || csvDatas[i][j] == "13" || csvDatas[i][j] == "14" || csvDatas[i][j] == "21")
                {
                    GameObject soft = Instantiate(softblockPrefab) as GameObject;
                    //soft.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    soft.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                    Debug.Log("csvDatas[1][1] の値は" + csvDatas[1][1]);
                    Debug.Log("csvDatas[1][1] の座標は"+ soft.transform.position);
                }

                // enemy
                else if(csvDatas[i][j] == "4")
                {
                    GameObject apple = Instantiate(applemanPrefeb) as GameObject;
                    //apple.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    apple.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
                else if(csvDatas[i][j] == "2")
                {
                    GameObject banana = Instantiate(bananamanPrefab) as GameObject;
                    //banana.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    banana.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
                else if (csvDatas[i][j] == "3")
                {
                    GameObject shark = Instantiate(bananamanPrefab) as GameObject;
                    //shark.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    shark.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
                else if (csvDatas[i][j] == "5")
                {
                    GameObject hamburger = Instantiate(bananamanPrefab) as GameObject;
                    //hamburger.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    hamburger.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
                // player
                else if (csvDatas[i][j] == "8")
                {
                    GameObject player = Instantiate(playerPrefab) as GameObject;
                    //player.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    player.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                    //gorila = GameObject.Find("sugorillaman_front_01");
                    this.player = player;
                }
            }
        }*/

        MakeHardBlock();
        MakeSoftBlock();
        MakeApple();
        MakeBanana();
        MakeShark();
        Makehamburger();
        MakePlayer();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string[]> GetList()
    {
        return this.csvDatas;
    }

    public void MakeHardBlock()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "9")
                {
                    GameObject hard = Instantiate(hardblockPrefab) as GameObject;
                    hard.transform.position = new Vector3(j * 0.6f - 4.3f, i * 0.6f - 3.5f, 0);
                }
            }
        }
    }

    public void MakeSoftBlock()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "1" || csvDatas[i][j] == "11" || csvDatas[i][j] == "12" || csvDatas[i][j] == "13" || csvDatas[i][j] == "14" || csvDatas[i][j] == "21")
                {
                    GameObject soft = Instantiate(softblockPrefab) as GameObject;
                    //soft.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    soft.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                    //Debug.Log("csvDatas[1][1] の値は" + csvDatas[1][1]);
                    //Debug.Log("csvDatas[1][1] の座標は" + soft.transform.position);
                }
            }
        }
    }

    public void MakeApple()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "4")
                {
                    GameObject apple = Instantiate(applemanPrefeb) as GameObject;
                    //apple.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    apple.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
            }
        }
    }

    public void MakeBanana()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "2")
                {
                    GameObject banana = Instantiate(bananamanPrefab) as GameObject;
                    //banana.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    banana.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
            }
        }
    }

    public void MakeShark()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "3")
                {
                    GameObject shark = Instantiate(bananamanPrefab) as GameObject;
                    //shark.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    shark.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                }
            }
        }
    }

    public void Makehamburger()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "5")
                {
                    GameObject hamburger = Instantiate(bananamanPrefab) as GameObject;
                    //hamburger.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    hamburger.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);

                }
            }
        }
    }

    public void MakePlayer()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                if (csvDatas[i][j] == "8")
                {
                    playerInstance = Instantiate(playerPrefab) as GameObject;
                    //player.transform.position = new Vector3(j * 0.4f - 3.0f, i * (-0.4f) + 1.0f, 0);
                    playerInstance.transform.position = new Vector3(j * 0.6f - 4.3f, i * (-0.6f) + 3.7f, 0);
                    //gorila = GameObject.Find("sugorillaman_front_01");
                    
                    
                }
            }
        }
    }

    public GameObject GetPlayerIndtance()
    {
        Debug.Log("instance");
        return this.playerInstance;
    }

}
