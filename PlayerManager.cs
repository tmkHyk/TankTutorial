using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class PlayerManager : MonoBehaviour
    {
        //体力ゲージオブジェクト
        public GameObject health;

        // Use this for initialization
        void Start()
        {
            //子オブジェクトから体力オブジェクトを取得
            health = this.gameObject.transform.GetChild(4).gameObject;

            //レイヤー名が10なら以下のコンポーネント、オブジェクトを削除
            if (this.gameObject.layer == 10)
            {
                Destroy(this.gameObject.GetComponent<Clone>());
                Destroy(this.gameObject.GetComponent<TankMovement>());
                Destroy(this.gameObject.GetComponent<TankHealth>());
                Destroy(this.gameObject.GetComponent<TankShooting>());
                Destroy(health);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}