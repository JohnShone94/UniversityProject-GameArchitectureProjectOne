using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_MapCreation : MonoBehaviour
{
    private int xPos;
    private int zPos;
    private int tempXpos;
    private int tempYpos;
    private int bodiesofwater;
    private int rows;
    private int columns;
    private int treeAmount;
    private bool stageOneComplete;
    private bool stageTwoComplete;
    private bool stageThreeComplete;

    public GameObject tileGrass;
    public GameObject tileWater;
    public GameObject tileTree;
    public GameObject tileFruitTree;
    public GameObject rayStart;

    public void LoadMap(int vRows, int vColumns, int bodiesOfWater, int trees)
    {
        columns = vColumns;
        rows = vRows;
        treeAmount = trees;
        bodiesofwater = bodiesOfWater;

        GenerateWorld();
    }

    private void GenerateWorld()
    {
        while (!stageOneComplete)
        {
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    Vector3 pos = new Vector3(c, 1, r);
                    Instantiate(tileGrass, pos, transform.rotation);
                }
            }
            Debug.Log("Stage One Has Been Completed!");
            stageOneComplete = true;
        }

        while(!stageTwoComplete)
        {
            for(int j = 0; j < bodiesofwater; j++)
            {
                xPos = Random.Range(1, columns);
                zPos = Random.Range(1, rows);
                Vector3 pos = new Vector3(xPos, 1, zPos);
                float radius = Random.Range(2, 4);
                GetWater(pos, radius);
            }
            Debug.Log("Stage Two Has Been Completed!");
            stageTwoComplete = true;
        }

        while (!stageThreeComplete)
        {
            GetFoliage();
            Debug.Log("Stage Three Has Been Completed!");
            stageThreeComplete = true;
        }


        stageOneComplete = false;
        stageTwoComplete = false;
        stageThreeComplete = false;
    }

    private void GetWater(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for(int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].transform.gameObject.tag == "Ground")
            {
                Destroy(hitColliders[i].gameObject);
                Instantiate(tileWater, hitColliders[i].gameObject.transform.position, transform.rotation);
            }
            else if(hitColliders[i].transform.gameObject.tag == "Water")
            {
                //Do nothing.
            }
        }
    }

    private void GetFoliage()
    {
        int radius = 4;
        for (int j = 0; j < treeAmount; j++)
        {
            bool treePlaced = false;
            while (!treePlaced)
            {
                xPos = Random.Range(1, columns);
                zPos = Random.Range(1, rows);
                Vector3 pos = new Vector3(xPos, 1, zPos);
                Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
                for (int h = 0; h < hitColliders.Length; h++)
                {
                    RaycastHit hit;
                    Vector3 fwd = transform.TransformDirection(Vector3.forward);
                    Ray ray = Camera.main.ScreenPointToRay(rayStart.transform.position);
                    Debug.DrawRay(rayStart.transform.position, transform.TransformDirection(transform.forward), Color.red, 100f);
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        if(hit.transform.gameObject.tag == "Water")
                        {
                            //Do Nothing
                        }
                        else if (hit.transform.gameObject.tag == "Ground")
                        {
                            Vector3 pos2 = new Vector3(xPos, 2, zPos);

                            Collider[] hitColliders2 = Physics.OverlapSphere(pos2, radius);
                            for (int i = 0; i < hitColliders2.Length; i++)
                            {
                                if (hitColliders2[i].transform.gameObject.tag == "Tree")
                                {
                                    break;
                                }
                                else
                                {
                                    int index;
                                    int type = (int)Random.Range(0, 10);
                                    if (type < 5)
                                    {
                                        index = 1;
                                    }
                                    else
                                    {
                                        index = 2;
                                    }
                                    Debug.Log("" + index);
                                    switch (index)
                                    {
                                        case 1:
                                            Debug.Log(pos);
                                            Debug.Log(pos2);
                                            Instantiate(tileTree, pos2, Quaternion.identity);
                                            break;
                                        case 2:
                                            Debug.Log(pos);
                                            Debug.Log(pos2);
                                            Instantiate(tileFruitTree, pos2, Quaternion.identity);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }

                }
                treePlaced = true;
            }
        }
    }

    public Vector2 GetMapSize()
    {
        Vector2 mapSize = new Vector2(columns, rows);
        return mapSize;
    }
}