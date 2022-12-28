using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    public GameObject devDisplay;
    public GameObject hoverDisplay;
    public GameObject activeDisplay;
    public GameObject availableDisplay;

    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGridXY(int _x, int _y)
    {
        x = _x;
        y = _y;
        devDisplay.SetActive(false);
    }
}
