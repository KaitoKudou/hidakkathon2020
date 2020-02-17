using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    GameObject bombInstance;
    GameObject playerInstance;
    public GameObject bombPrefab;
    Vector2 playerPos;
    private static int bombCount = 0; // Current
    private int maxBombCount = 3; // Max
    float span = 3.0f; 
    float delta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameObject.Find("sugorillaman_front_01(Clone)");

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.playerInstance.transform.position;
        //Debug.Log(playerInstance.transform.position);

        //Debug.Log(this.playerInstance);

        
        /*if (bombInstance)
        {
            this.delta += Time.deltaTime;
            if (this.delta >= this.span)
            {
                this.delta = 0;
                Debug.Log(GetBombCount());
                SetBombCount(-1);
                Debug.Log(GetBombCount());

            }
        }*/
    }

    // 現在の爆弾の個数を取得
    public static int GetBombCount()
    {
        //Debug.Log("現在の爆弾を置いた個数は" + this.bombCount);
        return bombCount;
        
    }

    //　現在の爆弾の個数を更新
    public static void SetBombCount(int n)
    {
        bombCount += n;
        //Debug.Log("現在の爆弾の手持ち個数は"+this.bombCount);
    }

    //　最大爆弾個数の取得
    public int GetMaxBombCount()
    {
        return this.maxBombCount;
    }

    //　最大爆弾個数の更新
    public void SetMaxBombCount(int n)
    {
        this.maxBombCount += n;
    }


    public void BombButton()
    {
        
        if (bombCount < GetMaxBombCount())
        {
            bombInstance = Instantiate(bombPrefab) as GameObject;
            bombInstance.transform.position = this.playerPos;
            SetBombCount(1);
            Debug.Log(GetBombCount()+"個の爆弾を置いた");


        }
        else
        {
            Debug.Log("おけん！！！");
        }
    }
}
