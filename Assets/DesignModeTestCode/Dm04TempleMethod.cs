using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Dm04TempleMethod:MonoBehaviour
{
    void Start()
    {
        IPeople people = new NorthPeople();
        people.Eat();
    }
}
//模板模式
public abstract class IPeople
{
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PayBill();
    }
    private void OrderFoods()
    {
        Debug.Log("点单");
    }
    public virtual void EatSomething()
    {

    }
    private void PayBill()
    {
        Debug.Log("买单");
    }
}

public class NorthPeople : IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}
public class SouthPeople : IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}