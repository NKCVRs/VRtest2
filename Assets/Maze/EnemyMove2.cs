using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMove2 : MonoBehaviour {

    public Transform goal;
    Vector3 start;
    NavMeshAgent agent;

    public LayerMask mask;

    bool isChase = false;//プレイヤーを追いかけるかどうか

    GameObject Player_obj;//プレイヤーのオブジェクト

    public GameObject Maze_obj;
    Maze_Create Maze_scr;
    int[,] maze_arrey;
    int pos_X = 0;
    int pos_Y = 0;



    // Use this for initialization
    void Start()
    {
        // 最初の位置を覚えておく
        start = transform.position;
        // NavMeshAgentを取得して
        agent = GetComponent<NavMeshAgent>();

        // ゴールを設定。
        agent.destination = new Vector3(8.0f,1.5f,1.0f);

        Maze_scr = Maze_obj.GetComponent<Maze_Create>();
        maze_arrey = Maze_scr.maze_arrey;

        Rand_agent();

        Debug.Log("2X" + pos_X + "Y" + pos_Y);
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
            Debug.Log("X" + pos_X + "Y" + pos_Y);

            if (transform.position.x == pos_Y && transform.position.z == pos_X)
            {
                Rand_agent();
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

    //目標をランダムで設定
    void Rand_agent()
    {
        while (true)
        {
            pos_X = Random.Range(0, maze_arrey.GetLength(0));
            pos_Y = Random.Range(0, maze_arrey.GetLength(1));

            Debug.Log("0 X" + pos_X + "Y" + pos_Y);

            if (maze_arrey[pos_X, pos_Y] == 0)
            {
                agent.destination = new Vector3(pos_Y, 1.5f, pos_X);

                Debug.Log("1 X" + pos_X + "Y" + pos_Y);

                break;
            }
        }
    }
}
