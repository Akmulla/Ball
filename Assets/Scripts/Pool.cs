﻿using UnityEngine;

public class Pool : MonoBehaviour
{
    //public string objName;
    private GameObject[] stck;
    private int tos;
    public GameObject obj;
    public int size;

    public void Awake() 
    {
        stck = new GameObject[size];
        tos = size;
        for (int i = 0 ; i < size ; i++)
        {
			stck[i] = ((GameObject)Instantiate(obj, new Vector3(0.0f,0.0f,-15.0f), Quaternion.identity));
            stck[i].GetComponent<ToPoolOnExit>().pool = this;
            stck[i].SetActive(false);
        }
    }

    public GameObject Activate(Vector3 pos, Quaternion rot)
    {
        GameObject obj = Pop();
        if (obj != null)
        {
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
        }
        return (obj);
    }


    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
        Push(obj);
    }

    public void Push(GameObject obj)
    {
        if (tos >= stck.Length)
        {
            Debug.Log(obj.ToString() + ": Стек заполнен");
			Destroy (obj);
            return;
        }
        stck[tos] = obj;
        tos++;
    }

    public GameObject Pop()
    {
        if (tos <= 0)
        {
            Debug.Log(obj.ToString()+": Стек пуст");
            return null;
        }
        tos--;
        return stck[tos];
    }



}
