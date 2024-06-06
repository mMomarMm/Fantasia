using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using System;

public class DiceRoll : MonoBehaviour
{
    public LayerMask layerMask;
    public bool hasRolled;
    [SerializeField] float rayDist;
    public Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!hasRolled && rb.velocity == Vector3.zero) doRays();
    }
    int doRays()
    {
        int rolled = 1;
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 dir = transform.GetChild(i).position - transform.position;
            dir.Normalize();
            if (Physics.Raycast(transform.position, dir, rayDist, layerMask))
            {
                //Debug.DrawRay(transform.position, dir * rayDist, Color.blue);
                rolled = 20 - i;
                break;
            }
        }
        print("rolled " + rolled);
        hasRolled = true;
        return rolled;
    }
}