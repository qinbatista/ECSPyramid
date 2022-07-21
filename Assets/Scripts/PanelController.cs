using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Units;
    public TextMeshProUGUI FPS;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisplayValue()
    {
        FPS.text = "Average FPS:" + Mathf.Ceil(GameManager.averageFPS).ToString();;
        Units.text = "Unit:" + GameManager.ObjectsCount;
    }
}
