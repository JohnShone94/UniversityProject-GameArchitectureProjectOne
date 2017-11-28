using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_MapEditor : MonoBehaviour
{
    private int rows;
    private int columns;
    private int currentTrees;
    private int currentWater;
    private int maxTrees;
    private int maxWater;

    public bool bTileGrass;
    public bool bTileWater;
    public bool bTileTree;
    public bool bTileFruitTree;
    public bool bRemoveObject;

    public GameObject tileGrass;
    public GameObject tileWater;
    public GameObject tileTree;
    public GameObject tileFruitTree;

    public GameObject startCanvas;
    public GameObject editorCanvas;

    public s_RunRayCast rayCast;


    public void btnSmall()
    {
        rows = 30;
        columns = 30;
        maxTrees = (columns * rows) / 10;
        maxWater = (columns * rows) / 25;

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Vector3 pos = new Vector3(c, 1, r);
                Instantiate(tileGrass, pos, transform.rotation);
            }
        }
        startCanvas.SetActive(false);
    }

    public void btnMedium()
    {
        rows = 60;
        columns = 60;
        maxTrees = (columns * rows) / 10;
        maxWater = (columns * rows) / 25;

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Vector3 pos = new Vector3(c, 1, r);
                Instantiate(tileGrass, pos, transform.rotation);
            }
        }
        startCanvas.SetActive(false);
    }

    public void btnLarge()
    {
        rows = 90;
        columns = 90;
        maxTrees = (columns * rows) / 10;
        maxWater = (columns * rows) / 25;

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Vector3 pos = new Vector3(c, 1, r);
                Instantiate(tileGrass, pos, transform.rotation);
            }
        }
        startCanvas.SetActive(false);
    }

    void Start()
    {
        startCanvas.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(bTileGrass)
            {
                if(rayCast.FindWhatIsAtCursorLocation().tag == "Ground")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Tree")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Water")
                {
                    Vector3 pos = new Vector3(rayCast.FindWhatIsAtCursorLocation().transform.position.x, 1, rayCast.FindWhatIsAtCursorLocation().transform.position.z);
                    Destroy(rayCast.FindWhatIsAtCursorLocation());
                    Instantiate(tileGrass, pos, transform.rotation);
                    currentWater--;
                }
            }

            if (bTileWater)
            {
                if (rayCast.FindWhatIsAtCursorLocation().tag == "Ground")
                {
                    if(currentWater <= maxWater)
                    {
                        Vector3 pos = new Vector3(rayCast.FindWhatIsAtCursorLocation().transform.position.x, 1, rayCast.FindWhatIsAtCursorLocation().transform.position.z);
                        Destroy(rayCast.FindWhatIsAtCursorLocation());
                        Instantiate(tileWater, pos, transform.rotation);
                        currentWater++;
                    }
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Tree")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Water")
                {
                    //Do nothing.
                }
            }

            if (bTileTree)
            {
                if (rayCast.FindWhatIsAtCursorLocation().tag == "Ground")
                {
                    if (currentTrees <= maxTrees)
                    {
                        Vector3 pos = new Vector3(rayCast.FindWhatIsAtCursorLocation().transform.position.x, 2, rayCast.FindWhatIsAtCursorLocation().transform.position.z);
                        Destroy(rayCast.FindWhatIsAtCursorLocation());
                        Instantiate(tileTree, pos, transform.rotation);
                        currentTrees++;
                    }
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Tree")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Water")
                {
                    //Do Nothing.
                }
            }

            if (bTileFruitTree)
            {
                if (rayCast.FindWhatIsAtCursorLocation().tag == "Ground")
                {
                    if (currentTrees <= maxTrees)
                    {
                        Vector3 pos = new Vector3(rayCast.FindWhatIsAtCursorLocation().transform.position.x, 2, rayCast.FindWhatIsAtCursorLocation().transform.position.z);
                        Destroy(rayCast.FindWhatIsAtCursorLocation());
                        Instantiate(tileFruitTree, pos, transform.rotation);
                        currentTrees++;
                    }
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Tree")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Water")
                {
                    //Do Nothing.
                }
            }

            if (bRemoveObject)
            {
                if (rayCast.FindWhatIsAtCursorLocation().tag == "Ground")
                {
                    //Do Nothing.
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Tree")
                {
                    Destroy(rayCast.FindWhatIsAtCursorLocation());
                    currentTrees--;
                }
                else if (rayCast.FindWhatIsAtCursorLocation().tag == "Water")
                {
                    //Do Nothing.
                }
            }

        }
    }
}
