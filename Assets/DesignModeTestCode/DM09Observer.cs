using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM09Observer:MonoBehaviour
{
    void Start()
    {
        //WearthStation ws = new WearthStation();
        //BillboardA a = new BillboardA();
        //BillboardB b = new BillboardB();

        //ws.UpdateInfo(a, b);

        ConcreteSubject1 sub1 = new ConcreteSubject1();

        ConcreteObserver1 ob1 = new ConcreteObserver1(sub1);
        ConcreteObserver2 ob2 = new ConcreteObserver2(sub1);

        sub1.RegisterObserver(ob1);
        sub1.RegisterObserver(ob2);

        sub1.subjectState = "温度：-10";
    }

}

//class WearthStation
//{
//    public void UpdateInfo(BillboardA a,BillboardB b)
//    {
//        a.Show();
//        b.Show();
//    }
//}

//class BillboardA
//{
//    public void Show()
//    {
//        Debug.Log("A版信息");
//    }
//}
//class BillboardB
//{
//    public void Show()
//    {
//        Debug.Log("B版信息");
//    }
//}

public abstract class Sunject
{
    List<Observer> mObservers = new List<Observer>();

    public void RegisterObserver(Observer ob)
    {
        mObservers.Add(ob);
    }
    public void RemoveObserver(Observer ob)
    {
        mObservers.Remove(ob);
    }
    public void NotifyObserver()
    {
        foreach (Observer ob in mObservers)
        {
            ob.OBUpdate();
        }
    }
}

public class ConcreteSubject1 : Sunject
{
    private string mSubjectState;
    public string subjectState
    {
        set
        {
            mSubjectState = value;
            NotifyObserver();
        }
        get
        {
            return mSubjectState;
        }
    }
}

public abstract class Observer
{
    public abstract void OBUpdate();
}

public class ConcreteObserver1 : Observer
{
    public ConcreteSubject1 mSub;

    public ConcreteObserver1(ConcreteSubject1 sub)
    {
        mSub = sub;
    }

    public override void OBUpdate()
    {
        Debug.Log("Observer1更新显示" + mSub.subjectState);
    }
}

public class ConcreteObserver2 : Observer
{
    public ConcreteSubject1 mSub;

    public ConcreteObserver2(ConcreteSubject1 sub)
    {
        mSub = sub;
    }

    public override void OBUpdate()
    {
        Debug.Log("Observer2更新显示" + mSub.subjectState);
    }
}