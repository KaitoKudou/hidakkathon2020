using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    float span = 3.0f; // 3秒ごとに爆破
    float delta = 0.0f;
    Ray2D ray_up, ray_down, ray_left, ray_right;
    //Rayが当たったオブジェクトの情報を入れる箱
    RaycastHit2D hit_up, hit_down, hit_left, hit_right;
    //Rayの長さ
    float maxDistance = 0.5f;
    //レイヤーマスク作成
    public LayerMask layerMaskSoftBlock; // SoftBlockレイヤーマスク
    BombGenerator bombGenerator;

    // Start is called before the first frame update
    void Start()
    {
        bombGenerator = GameObject.Find("BombGenerator").GetComponent<BombGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rayの作成
        //第１引数：始点、第２引数：Rayの方向
        ray_up = new Ray2D(transform.position, transform.up * maxDistance);
        ray_down = new Ray2D(transform.position, -transform.up * maxDistance);
        ray_left = new Ray2D(transform.position, -transform.right * maxDistance);
        ray_right = new Ray2D(transform.position, transform.right * maxDistance);
        Debug.DrawRay(ray_up.origin, ray_up.direction * maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_down.origin, ray_down.direction * maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_left.origin, ray_left.direction * maxDistance, Color.red, 1.0f);
        Debug.DrawRay(ray_right.origin, ray_right.direction * maxDistance, Color.red, 1.0f);

        this.delta += Time.deltaTime;

        // 3秒ごとに爆破
        if (this.delta >= this.span)
        {
            this.delta = 0;

            hit_up = Physics2D.Raycast(ray_up.origin, ray_up.direction * maxDistance, maxDistance);
            //もしRayにオブジェクトが衝突したら
            //Rayが当たったオブジェクトがsoftblockだったら
            //上方向
            if (Physics2D.Raycast(ray_up.origin, ray_up.direction, maxDistance, layerMaskSoftBlock.value))
            {
                Debug.Log("上方向" + hit_up.collider.gameObject.name + "爆破！！！");
                Destroy(hit_up.collider.gameObject);
                
            }

            // 下方向
            hit_down = Physics2D.Raycast(ray_down.origin, ray_down.direction * maxDistance, maxDistance);
            if (Physics2D.Raycast(ray_down.origin, ray_down.direction, maxDistance, layerMaskSoftBlock.value))
            {
                Debug.Log("下方向" + hit_down.collider.gameObject.name + "爆破！！！");
                Destroy(hit_down.collider.gameObject);
            }

            // 左方向
            hit_left = Physics2D.Raycast(ray_left.origin, ray_left.direction * maxDistance, maxDistance);
            if (Physics2D.Raycast(ray_left.origin, ray_left.direction, maxDistance, layerMaskSoftBlock.value))
            {
                Debug.Log("左方向" + hit_left.collider.gameObject.name + "爆破！！！");
                Destroy(hit_left.collider.gameObject);
            }

            // 右方向
            hit_right = Physics2D.Raycast(ray_right.origin, ray_right.direction * maxDistance, maxDistance);
            if (Physics2D.Raycast(ray_right.origin, ray_right.direction, maxDistance, layerMaskSoftBlock.value))
            {
                Debug.Log("右方向" + hit_right.collider.gameObject.name + "爆破！！！");
                Destroy(hit_right.collider.gameObject);
            }

            // 爆弾を削除
            //Debug.Log(bombGenerator.GetBombCount() + "個の爆弾を置いた");
            //bombGenerator.SetBombCount(-1);
            Destroy(this.gameObject);
            //Debug.Log("爆発！！");
            //Debug.Log(bombGenerator.GetBombCount() + "個の爆弾を置いた");

        }
    }
}
