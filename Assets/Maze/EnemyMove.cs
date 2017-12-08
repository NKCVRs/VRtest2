using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    public Transform goal;
    Vector3 start;
    NavMeshAgent agent;

    public LayerMask mask;

    bool isChase = false;//プレイヤーを追いかけるかどうか

    GameObject Player_obj;//プレイヤーのオブジェクト

    Vector2 agent_pos;

    // Use this for initialization
    void Start()
    {
        // 最初の位置を覚えておく
        start = transform.position;
        // NavMeshAgentを取得して
        agent = GetComponent<NavMeshAgent>();

        // ゴールを設定。
        agent.destination = new Vector3(8.0f,1.5f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // クリックで最初の位置にもどる。
        //if (Input.GetMouseButtonDown(0))
        //{
        //    transform.position = start;
        //}

        if (isChase == false)
        {
            if (transform.position.x == 8 && transform.position.z == 1)
            {
                agent.destination = new Vector3(8, transform.position.y, 4);
            }
            else if (transform.position.x == 8 && transform.position.z == 4)
            {
                agent.destination = new Vector3(1, transform.position.y, 4);
            }
            else if (transform.position.x == 1 && transform.position.z == 4)
            {
                agent.destination = new Vector3(1, transform.position.y, 1);
            }
            else if (transform.position.x == 1 && transform.position.z == 1)
            {
                agent.destination = new Vector3(8, transform.position.y, 1);
            }
        }
        else if(isChase == true)
        {
            agent.destination = Player_obj.transform.position;

            //プレイヤーと敵の距離が５より離れたら
            if (Vector2.Distance(transform.position, Player_obj.transform.position) > 5)
            {
                isChase = false;
                agent.destination = new Vector3(8, 1.5f, 1);
            }

        }


        //Debug.DrawRay(transform.position, transform.forward, Color.red, 3, false);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 10000, out hit, Mathf.Infinity))
        {
           //hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;

           if(hit.collider.tag =="Player")
            {
                isChase = true;
                Player_obj = hit.collider.gameObject;
            }
        }
    }
}
