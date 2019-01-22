using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class Shot : MonoBehaviour
    {
        [SerializeField, Range(0, 100), Tooltip("発砲間隔")]
        float m_Interval;
        //発砲時間
        float m_Timer;
        [SerializeField, Tooltip("弾丸")]
        Rigidbody m_Bullet;
        
        public Transform m_FireTransform;
        float m_CurrentLaunchForce = 20f;
        float m_MinLaunchForce = 20f;
        //プレイヤー番号
        int m_PlayerNumber;

        // Use this for initialization
        void Start()
        {
            //プレイヤー番号を格納
            m_PlayerNumber = this.gameObject.GetComponent<TankMovement>().m_PlayerNumber;
        }

        // Update is called once per frame
        void Update()
        {
            Shooting();
        }

        /// <summary>
        /// 発砲処理
        /// </summary>
        void Shooting()
        {
            //TankShootingクラスから引用
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_Interval && this.gameObject.layer == 10)
            {
                Rigidbody shellInstance =
                    Instantiate(m_Bullet, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

                //Shellを発射したプレイヤーの番号を格納
                shellInstance.GetComponent<ShellExplosion>().m_PlayerNumber = m_PlayerNumber;

                shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

                m_CurrentLaunchForce = m_MinLaunchForce;
                m_Timer = 0;
            }
        }
    }
}