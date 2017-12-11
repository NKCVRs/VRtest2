using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

//決まった場所を周回する敵
public class EnemyMove : MonoBehaviour {

    public Transform goal;
    Vector3 start;
    NavMeshAgent agent;

    public LayerMask mask;

    bool isChase = false;//プレイヤーを追いかけるかどうか

    GameObject Player_obj;//プレイヤーのオブジェクト

    float chase_range = 5.0f;   //追跡範囲

    Vector2[] agent_pos = new Vector2[4];

    float timer = 0;

    // Use this for initialization
    void Start()
    {
        // 最初の位置を覚えておく
        start = transform.position;
        // NavMeshAgentを取得して
        agent = GetComponent<NavMeshAgent>();

        agent_pos[0] = new Vector2(8,1);
        agent_pos[1] = new Vector2(8, 4);
        agent_pos[2] = new Vector2(1, 4);
        agent_pos[3] = new Vector2(1, 1);

        // ゴールを設定。
        agent.destination = new Vector3(agent_pos[0].x, 1.5f, agent_pos[0].y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (isChase == false)
        {
            if (IsPosition(agent_pos[0].x, agent_pos[0].y))
            {
                agent.destination = new Vector3(agent_pos[1].x, transform.position.y, agent_pos[1].y);
            }
            else if (IsPosition(agent_pos[1].x, agent_pos[1].y))
            {
                agent.destination = new Vector3(agent_pos[2].x, transform.position.y, agent_pos[2].y);
            }
            else if (IsPosition(agent_pos[2].x, agent_pos[2].y))
            {
                agent.destination = new Vector3(agent_pos[3].x, transform.position.y, agent_pos[3].y);
            }
            else if (IsPosition(agent_pos[3].x, agent_pos[3].y))
            {
                agent.destination = new Vector3(agent_pos[0].x, transform.position.y, agent_pos[0].y);
            }
        }
        else if(isChase == true)
        {
            if (timer < 1) return;
            agent.destination = Player_obj.transform.position;

            //プレイヤーと敵の距離が５より離れたら
            if (Vector2.Distance(transform.position, Player_obj.transform.position) > chase_range)
            {
                isChase = false;
                agent.destination = new Vector3(8, 1.5f, 1);
            }
            timer = 0;
        }


        //Debug.DrawRay(transform.position, transform.forward, Color.red, 3, false);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 10000, out hit, Mathf.Infinity))
        {

           if(hit.collider.tag =="Player")
            {
                isChase = true;
                Player_obj = hit.collider.gameObject;
            }
        }
    }

    //敵が目標座標に移動したかどうかの判定
    bool IsPosition(float x, float y)
    {
        bool isposX = transform.position.x > x - 0.1f && transform.position.x < x + 0.1f;
        bool isposY = transform.position.z > y - 0.1f && transform.position.z < y + 0.1f;

        if (isposX == true && isposY == true)
        {
            return true;
        }

        return false;
    }
}
