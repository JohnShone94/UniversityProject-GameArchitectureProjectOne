using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_MenuManager : MonoBehaviour
{
    private bool inEditMode;
    private int sizeX;
    private int sizeZ;
    private int bodiesAmount;
    private int treeAmount;

    public GameObject panelGame;
    public GameObject panelEditor;
    public Slider xSlider;
    public Slider zSlider;
    public Slider bodiesSlider;
    public Slider treesSlider;
    public Text xText;
    public Text zText;
    public Text bodiesText;
    public Text treeAmountText;
    public s_MapCreation mapCreation;
	void Start ()
    {
        inEditMode = false;

        panelGame.SetActive(true);
        panelEditor.SetActive(false);
        bodiesText.text = ("Bodies = " + bodiesSlider.minValue);
        zText.text = ("Z = " + zSlider.minValue);
        xText.text = ("X = " + xSlider.minValue);
        treeAmountText.text = ("Trees = " + treesSlider.minValue);

        sizeX =(int)xSlider.minValue;
        sizeZ = (int)zSlider.minValue;
    }
	void Update ()
    {
        treesSlider.maxValue = (int)(sizeX * sizeZ / 2);
    }

    public void SwitchMode()
    {
        inEditMode = !inEditMode;
        panelEditor.SetActive(!panelEditor.activeSelf);
        panelGame.SetActive(!panelGame.activeSelf);
    }

    public void ReloadTheMap()
    {
        sizeX = (int) xSlider.value;
        sizeZ = (int) zSlider.value;
        bodiesAmount = (int)bodiesSlider.value;
        treeAmount = (int)treesSlider.value;
        mapCreation.ReloadMap(sizeX, sizeZ, bodiesAmount, treeAmount);
    }

    public void ChangeXValue()
    {
        xText.text = ("X = " + xSlider.value);
    }
    public void ChangeYValue()
    {
        zText.text = ("Z = " + zSlider.value);
    }
    public void ChangeBodiesOfWater()
    {
        bodiesText.text = ("Bodies = " + bodiesSlider.value);
    }

    public void ChangeTreeAmount()
    {
        treeAmountText.text = ("Trees = " + treesSlider.value);
    }
}
