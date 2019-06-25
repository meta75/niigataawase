using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GenreMarkerEvent : oriMarker
{
    private bool di;
    private int co;
    private GameObject it;
    private Transform e1, e2;
    private CitiesMarkerEvent pc;
    [SerializeField]
    private GameObject[] items = new GameObject[4];

    // Use this for initialization
    void Start()
    {
        e1 = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (di)
        {
            float mid = 0.5f;
            it.transform.position = Vector3.Lerp(e1.position, e2.position, mid);
            it.transform.rotation = Quaternion.Lerp(e1.rotation, e2.rotation, mid);
        }
    }

    //Colliderが触れてる間
    void OnTriggerStay(Collider col)
    {
        if (!di && col.tag == "Cities")
        {
            try
            {
                CitiesMarkerEvent c = col.GetComponent<CitiesMarkerEvent>();
                if (items[c.Num] == null)
                {
                    Debug.Log("itemに設定されてないよ");
                    return;
                }
                if (!c.Con)
                {
                    float tra = 0.0f;
                    Transparency(tra);
                    c.Transparency(tra);
                    it = items[c.Num];
                    it.SetActive(true);
                    e2 = col.transform;
                    di = true;
                    c.Con = true;
                    c.OS = gameObject;
                    pc = c;
                    co = col.GetInstanceID();
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Log(ex.Message);
                Debug.Log(ex.StackTrace);
            }
        }
    }

    //Colliderが触れるのをやめたとき
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Cities" &&  col.GetInstanceID() == co)
        {
            Cutting();
        }
    }

    public void Cutting()
    {
        if (pc != null)
        {
            float opa = 1.0f;
            Transparency(opa);
            pc.Transparency(opa);
            Touched();
            pc.Touched();
            it.SetActive(false);
            it = null;
            e2 = null;
            di = false;
            pc.Con = false;
            pc.OS = null;
            pc = null;
            co = 0;
        }
    }
}
