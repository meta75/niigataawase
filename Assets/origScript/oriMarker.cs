using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class oriMarker : MonoBehaviour {
    [SerializeField]
    private Animator ani;

    public void foundanimator()
    {
        ani.Play("extend");
    }

    public void Transparency(float a)
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, a);
        }
    }

    public void Touched()
    {
        ani.SetTrigger("touched");
    }
}
