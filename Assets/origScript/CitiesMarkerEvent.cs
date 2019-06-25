using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesMarkerEvent : oriMarker
{
    [SerializeField]
    private int num;
    public int Num
    {
        get { return this.num; }
    }

    private bool con;
    public bool Con
    {
        set { this.con = value; }
        get { return this.con; }
    }

    private GameObject oS;
    public GameObject OS
    {
        set { this.oS = value; }
        get { return this.oS; }
    }

    public void cut()
    {
        if (oS != null)
        {
            oS.GetComponent<GenreMarkerEvent>().Cutting();
        }
    }

}
