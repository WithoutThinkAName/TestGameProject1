using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM10Memento:MonoBehaviour
{
    void Start()
    {
        //Originator or = new Originator();

        //or.SetState("State1");
        //or.ShowState();

        //Memento me = or.CreateMemento();
        //or.SetState("State2");
        //or.ShowState();

        //or.SetMemento(me);
        //or.ShowState();

        CareTaker careTaker = new CareTaker();

        Originator or = new Originator();
        or.SetState("State1");
        or.ShowState();
        careTaker.AddMemento("v1.0", or.CreateMemento());

        or.SetState("State2");
        or.ShowState();
        careTaker.AddMemento("v2.0", or.CreateMemento());

        or.SetState("State3");
        or.ShowState();
        careTaker.AddMemento("v3.0", or.CreateMemento());

        or.SetMemento(careTaker.GetMemnto("v2.0"));
        or.ShowState();


    }
}

public class Originator
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public void ShowState()
    {
        Debug.Log("Originator State:" + mState);
    }

    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }
    public void SetMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}

public class Memento
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public string GetState()
    {
        return mState;
    }
}

public class CareTaker
{
    Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();

    public void AddMemento(string ver,Memento memento)
    {
        mMementoDict.Add(ver, memento);
    }
    public Memento GetMemnto(string ver)
    {
        if (mMementoDict.ContainsKey(ver)==false)
        {
            Debug.Log("Memento中找不到key：" + ver);
            return null;
        }
        return mMementoDict[ver];
    }
}