using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//  ３秒経過したら自動でゲームが始まるようにする
public class StageInfoController1 : MonoBehaviour
{
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(delta > 3.0)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
