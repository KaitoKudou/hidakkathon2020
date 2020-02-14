using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
    MapReader mapReader;
    Rigidbody2D rigid2D;
    GameObject playerInstance;
    //float moveForce = 780.6f;
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    TextAsset map;

    Ray2D ray_up, ray_down, ray_left, ray_right;

    //Rayが当たったオブジェクトの情報を入れる箱
    RaycastHit2D hit;

    //Rayの長さ
    float maxDistance = 0.5f;

    //レイヤーマスク作成
    public LayerMask layerMaskHardBlock; // HardBlockレイヤーマスク
    public LayerMask layerMaskSoftBlock; // SoftBlockレイヤーマスク

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("sugorillaman_front_01");
        //mapReader = GameObject.Find("MapCSVDirector").GetComponent<MapReader>();
        //playerInstance = mapReader.GetPlayerIndtance();
        //playerInstance = GameObject.Find("sugorillaman_front_01(Clone)");
        this.playerInstance = GameObject.FindWithTag("player");
        //rigid2D = playerInstance.GetComponent<Rigidbody2D>();
        //player = Instantiate(mapReader.playerPrefab) as GameObject;

        map = Resources.Load("map") as TextAsset; // Resouces下のCSV読み込み
        Debug.Log(map.text);
        StringReader reader = new StringReader(map.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() > -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加


        }
        for(int i=0;i<13;i++)
        {
            for(int j=0;j<17;j++)
            {
                Debug.Log(csvDatas[i][j]);
            }
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        
        //rigid2D = playerInstance.GetComponent<Rigidbody2D>();
        // Rayの作成
        //第１引数：始点、第２引数：Rayの方向
        ray_up = new Ray2D(playerInstance.transform.position, playerInstance.transform.up * maxDistance);
        ray_down = new Ray2D(playerInstance.transform.position, -playerInstance.transform.up * maxDistance);
        ray_left = new Ray2D(playerInstance.transform.position, -playerInstance.transform.right * maxDistance);
        ray_right = new Ray2D(playerInstance.transform.position, playerInstance.transform.right * maxDistance);
        Debug.DrawRay(ray_up.origin, ray_up.direction*maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_down.origin, ray_down.direction * maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_left.origin, ray_left.direction * maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_right.origin, ray_right.direction * maxDistance, Color.red, 1.0f);
    }

    public void UpButton()
    {
        hit = Physics2D.Raycast(ray_up.origin, ray_up.direction * maxDistance, maxDistance);
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがhardblockだったら
        if (Physics2D.Raycast(ray_up.origin, ray_up.direction, maxDistance, layerMaskHardBlock.value))
        {
            
            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがhardblockに当たった");

            }
            else
            {
                Debug.Log("hardblock以外に衝突");
            }

        }
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがsoftblockだったら
        else if (Physics2D.Raycast(ray_up.origin, ray_up.direction, maxDistance, layerMaskSoftBlock.value))
        {
            
            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがsoftblockに当たった");

            }
        }
        else
        {
            Debug.Log("衝突していない");
            playerInstance.transform.Translate(0, 0.6f, 0);
        }
        //this.rigid2D.AddForce(transform.up * this.moveForce);
        //transform.Translate(0, 0.4f, 0);
        //mapReader.gorila.transform.Translate(0, 0.4f, 0);
        
        Debug.Log("up");

    }

    public void DownButton()
    {
        hit = Physics2D.Raycast(ray_down.origin, ray_down.direction * maxDistance, maxDistance);
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがhardblockだったら
        if (Physics2D.Raycast(ray_down.origin, ray_down.direction, maxDistance, layerMaskHardBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがhardblockに当たった");

            }
            else
            {
                Debug.Log("hardblock以外に衝突");
            }

        }
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがsoftblockだったら
        else if (Physics2D.Raycast(ray_down.origin, ray_down.direction, maxDistance, layerMaskSoftBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがsoftblockに当たった");

            }
        }
        else
        {
            Debug.Log("衝突していない");
            playerInstance.transform.Translate(0, -0.6f, 0);
        }
        
        //transform.Translate(0, -0.6f, 0);
        Debug.Log("down");
    }

    public void LeftButton()
    {
        hit = Physics2D.Raycast(ray_left.origin, ray_left.direction * maxDistance, maxDistance);
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがhardblockだったら
        if (Physics2D.Raycast(ray_left.origin, ray_left.direction, maxDistance, layerMaskHardBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがhardblockに当たった");

            }
            else
            {
                Debug.Log("hardblock以外に衝突");
            }

        }
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがsoftblockだったら
        else if (Physics2D.Raycast(ray_left.origin, ray_left.direction, maxDistance, layerMaskSoftBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがsoftblockに当たった");

            }
        }
        else
        {
            Debug.Log("衝突していない");
            playerInstance.transform.Translate(-0.6f, 0, 0);
        }
        
        //transform.Translate(-0.6f, 0, 0);
        Debug.Log("left");
    }

    public void RightButton()
    {
        hit = Physics2D.Raycast(ray_right.origin, ray_right.direction * maxDistance, maxDistance);
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがhardblockだったら
        if (Physics2D.Raycast(ray_right.origin, ray_right.direction, maxDistance, layerMaskHardBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがhardblockに当たった");

            }
            else
            {
                Debug.Log("hardblock以外に衝突");
            }

        }
        //もしRayにオブジェクトが衝突したら
        //Rayが当たったオブジェクトがsoftblockだったら
        else if (Physics2D.Raycast(ray_right.origin, ray_right.direction, maxDistance, layerMaskSoftBlock.value))
        {

            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log("Rayがsoftblockに当たった");

            }
        }
        else
        {
            Debug.Log("衝突していない");
            playerInstance.transform.Translate(0.6f, 0, 0);
        }
        
        //transform.Translate(0.6f, 0, 0);
        Debug.Log("right");
    }
}
