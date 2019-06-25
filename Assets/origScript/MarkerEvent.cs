using Kudan.AR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerEvent : MonoBehaviour {

    public void FoundMarker(Trackable t)
    {
        try
        {
            GameObject g = transform.Find(t.name).transform.Find("Coll").gameObject;
            g.GetComponent<oriMarker>().foundanimator();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex.Message);
            Debug.Log(ex.StackTrace);
        }
    }

    public void LostMarker(Trackable t)
    {
        try
        {
            GameObject g = transform.Find(t.name).transform.Find("Coll").gameObject;
            if (g.tag == "Cities")
            {
                g.GetComponent<CitiesMarkerEvent>().cut();
            }
            else if(g.tag == "genre")
            {
                g.GetComponent<GenreMarkerEvent>().Cutting();
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex.Message);
            Debug.Log(ex.StackTrace);
        }

    }
}
