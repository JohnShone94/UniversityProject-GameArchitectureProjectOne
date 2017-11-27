using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_MenuManager : MonoBehaviour
{
    private int sizeX;
    private int sizeZ;
    private int bodiesAmount;
    private int treeAmount;

    public GameObject panelGame;
    public Slider xSlider;
    public Slider zSlider;
    public Slider bodiesSlider;
    public Slider treesSlider;
    public Text xText;
    public Text zText;
    public Text bodiesText;
    public Text treeAmountText;
    public s_MapCreation mapCreation;

    public void LoadTheMap()
    {
        sizeX = (int) xSlider.value;
        sizeZ = (int) zSlider.value;
        bodiesAmount = (int)bodiesSlider.value;
        treeAmount = (int)treesSlider.value;
        mapCreation.LoadMap(sizeX, sizeZ, bodiesAmount, treeAmount);
        panelGame.SetActive(false);
    }

    public void ChangeXValue()
    {
        xText.text = ("X Tiles = " + xSlider.value);
        treesSlider.maxValue = (int)(xSlider.value * zSlider.value / 10);
        bodiesSlider.maxValue = (int)(xSlider.value * zSlider.value / 25);
    }
    public void ChangeYValue()
    {
        zText.text = ("Z Tiles = " + zSlider.value);
        treesSlider.maxValue = (int)(xSlider.value * zSlider.value / 10);
        bodiesSlider.maxValue = (int)(xSlider.value * zSlider.value / 25);
    }
    public void ChangeBodiesOfWater()
    {
        bodiesText.text = ("Bodies of water = " + bodiesSlider.value);
    }

    public void ChangeTreeAmount()
    {
        treeAmountText.text = ("Trees = " + treesSlider.value);
    }

    void Start()
    {
        panelGame.SetActive(true);
        bodiesText.text = ("Bodies of water = " + bodiesSlider.minValue);
        zText.text = ("Z Tiles = " + zSlider.minValue);
        xText.text = ("X Tiles = " + xSlider.minValue);
        treeAmountText.text = ("Trees = " + treesSlider.minValue);
        treesSlider.maxValue = (int)(xSlider.value * zSlider.value / 10);
        bodiesSlider.maxValue = (int)(xSlider.value * zSlider.value / 100);
    }
}
