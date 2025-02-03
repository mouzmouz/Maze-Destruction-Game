using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class CreateMaze : MonoBehaviour
{

    public GameObject T1;
    public GameObject T2;
    public GameObject T3;
    public GameObject R;
    public GameObject G;
    public GameObject B;
    public GameObject Player;
    public GameObject Wall;


    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below


    float level = 0f;
    float top = 0.0f;

    void Start()
    {
        theSourceFile = new FileInfo("Assets/Resources/file.maz");
        reader = theSourceFile.OpenText();
        text = reader.ReadLine();
        char[] spearator = { '=', ' ' };
        String[] lArr = text.Split(spearator);
        int L = int.Parse(lArr[1]);
        text = reader.ReadLine();
        String[] nArr = text.Split(spearator);
        int N = int.Parse(nArr[1]);
        text = reader.ReadLine();
        String[] kArr = text.Split(spearator);
        int K = int.Parse(kArr[1]);


        float maxSize = (N - 1) * 3.5f;
        float halfSize = maxSize / 2.0f;

        GameObject wall1;
        Vector3 posWall1 = new Vector3(-1.5f, 0.0f, halfSize);
        Vector3 rotWall1 = new Vector3(0.0f, 0.0f, -90.0f);
        wall1 = (GameObject)(Instantiate(Wall, posWall1, Quaternion.Euler(rotWall1)));

        GameObject wall2;
        Vector3 posWall2 = new Vector3(halfSize, 0.0f, maxSize + 1.5f);
        Vector3 rotWall2 = new Vector3(0.0f, 90.0f, -90.0f);
        wall2 = (GameObject)(Instantiate(Wall, posWall2, Quaternion.Euler(rotWall2)));

        GameObject wall3;
        Vector3 posWall3 = new Vector3(maxSize + 1.5f, 0.0f, halfSize);
        Vector3 rotWall3 = new Vector3(-90.0f, 90.0f, 0.0f);
        wall3 = (GameObject)(Instantiate(Wall, posWall3, Quaternion.Euler(rotWall3)));

        GameObject wall4;
        Vector3 posWall4 = new Vector3(halfSize, 0.0f, -1.5f);
        Vector3 rotWall4 = new Vector3(90.0f, 0.0f, 0.0f);
        wall4 = (GameObject)(Instantiate(Wall, posWall4, Quaternion.Euler(rotWall4)));



        Vector3[] freePos = new Vector3[10000];
        int index = 0;
        int arrSize = 0;

        while (text != null)
        {
            text = reader.ReadLine();
            if (text != null && text.Contains("LEVEL"))
            {
                string topLevel = "LEVEL " + L;
                if (text.Equals(topLevel))
                {
                    top = level + 0.7f;
                }
                for (int i = 0; i < N; i++)
                {
                    text = reader.ReadLine();
                    text = text.Replace("  ", " ");
                    char[] s = { ' ', ' ' };
                    String[] line = text.Split(s);
                    for (int j = 0; j < N; j++)
                    {
                        GameObject cube;

                        float x = i * 3.5f;
                        float y = level + 1.5f;
                        float z = j * 3.5f;

                        Vector3 pos = new Vector3(x, y, z);

                        if (line[j] == "T1")
                        {

                            cube = (GameObject)(Instantiate(T1, pos, Quaternion.identity));
                        }
                        else if (line[j] == "T2")
                        {
                            cube = (GameObject)(Instantiate(T2, pos, Quaternion.identity));
                        }
                        else if (line[j] == "T3")
                        {
                            cube = (GameObject)(Instantiate(T3, pos, Quaternion.identity));
                        }
                        else if (line[j] == "R")
                        {
                            cube = (GameObject)(Instantiate(R, pos, Quaternion.identity));
                        }
                        else if (line[j] == "G")
                        {
                            cube = (GameObject)(Instantiate(G, pos, Quaternion.identity));
                        }
                        else if (line[j] == "B")
                        {
                            cube = (GameObject)(Instantiate(B, pos, Quaternion.identity));
                        }
                        else if (level == 0f && line[j] == "E")
                        {
                            freePos[index++] = pos;
                        }
                    }
                }
                arrSize = index;
                level += 3.5f;
            }
        }
        GameObject player;
        System.Random rnd = new System.Random();
        int playerPos = rnd.Next(arrSize);
        player = (GameObject)(Instantiate(Player, freePos[playerPos], Quaternion.identity));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            print("see ya");
            Application.Quit();
        }

        Vector3 bar = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (bar.y >= top)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("bye");
                Application.Quit();
            }
        }
    }
}





