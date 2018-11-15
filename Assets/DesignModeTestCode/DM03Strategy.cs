using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM03Strategy:MonoBehaviour
{
    void Start()
    {
        StrategyContext con = new StrategyContext();
        con.strategy = new ConcreteStrategyA();

        con.Cal();
    }
}

public class StrategyContext
{
    public IStrategy strategy;
    public void Cal()
    {
        strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}
public class ConcreteStrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("策略：A");
    }
}
public class ConcreteStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("策略：B");
    }
}