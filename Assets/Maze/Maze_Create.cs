﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Create : MonoBehaviour {

    public int[,] maze_arrey = {{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                { 1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1 },
                                { 1,0,1,1,0,1,1,1,0,1,0,1,1,1,0,1,1,0,1 },
                                { 1,0,1,1,0,1,1,1,0,1,0,1,1,1,0,1,1,0,1 },
                                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                { 1,0,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,0,1 },
                                { 1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1 },
                                { 1,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,1,1,1 },
                                { 1,1,1,1,0,1,0,0,0,0,0,0,0,1,0,1,1,1,1 },
                                { 1,1,1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,1 },
                                { 1,1,1,1,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1 },
                                { 1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1 },
                                { 1,1,1,1,0,1,0,0,0,0,0,0,0,1,0,1,1,1,1 },
                                { 1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1 },
                                { 1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1 },
                                { 1,0,1,1,0,1,1,1,0,1,0,1,1,1,0,1,1,0,1 },
                                { 1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1 },
                                { 1,1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,1 },
                                { 1,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1 },
                                { 1,0,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1 },
                                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 } };

    public GameObject m_wall;

    private string stageName; // 読み込む譜面の名前
    private string level; // 難易度
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数

    // Use this for initialization
    void Start () {
        
        for (int y = 0; y < 22; y++)
        {
            for(int x = 0; x < 19; x++)
            {
                if (maze_arrey[y, x] == 1)
                {
                    Instantiate(m_wall, new Vector3(x, 0, y), transform.rotation);
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
