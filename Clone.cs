using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clone : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー番号")]
    public int m_PlayerNumber;
    [SerializeField, Range(0, 10), Tooltip("生成位置")]
    float m_CreatePos;

    // Use this for initialization
    void Start()
    {
        //プレイヤー番号をTankMovementクラスから取得
        m_PlayerNumber = this.gameObject.GetComponent<Complete.TankMovement>().m_PlayerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //複製処理
        CreateClone();
    }

    /// <summary>
    /// 複製実装
    /// </summary>
    void CreateClone()
    {
        //プレイヤー番号が1のときプレイヤー1、2のときプレイヤー2
        switch (m_PlayerNumber)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Creat();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    Creat();
                }
                break;
        }
    }

    /// <summary>
    /// 自機複製処理
    /// </summary>
    void Creat()
    {
        //自機前方に複製位置を指定
        var pos = transform.position + transform.forward * m_CreatePos;
        //複製
        GameObject clone = Instantiate(this.gameObject, pos, transform.rotation);
        //Layer名をCloneに変更
        clone.layer = LayerMask.NameToLayer("Clone");
    }
}