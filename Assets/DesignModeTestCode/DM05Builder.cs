﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM05Builder:MonoBehaviour
{
    void Start()
    {
        IBuilder fatBuilder = new FatPersonBuilder();
        IBuilder thinBuilder = new ThinPersonBuilder();

        Person fatPerson = Director.Construct(fatBuilder);
        fatPerson.Show();
    }
}

class Person
{
    List<string> parts = new List<string>();
    public void AddPart(string part)
    {
        parts.Add(part);
    }
    public void Show()
    {
        foreach (string part in parts)
        {
            Debug.Log(part);
        }
    }
}
class FatPerson : Person { }
class ThinPerson : Person { }

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFace();
    Person GetResult();
}

class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new FatPerson();
    }

    public void AddBody()
    {
        person.AddPart("胖人的身体");
    }

    public void AddFace()
    {
        person.AddPart("胖人的脸");
    }

    public void AddHand()
    {
        person.AddPart("胖人的手");
    }

    public void AddHead()
    {
        person.AddPart("胖人的头");
    }

    public Person GetResult()
    {
        return person;
    }
}

class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new FatPerson();
    }

    public void AddBody()
    {
        person.AddPart("瘦人的身体");
    }

    public void AddFace()
    {
        person.AddPart("瘦人的脸");
    }

    public void AddHand()
    {
        person.AddPart("瘦人的手");
    }

    public void AddHead()
    {
        person.AddPart("瘦人的头");
    }

    public Person GetResult()
    {
        return person;
    }
}

class Director
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddFace();
        builder.AddHand();
        builder.AddHead();
        return builder.GetResult();
    }
}