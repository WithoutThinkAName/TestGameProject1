using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM02Bridge:MonoBehaviour
{
    void Start()
    {
        //IRenderEngine renderEngine = new OpenGL();
        //Sphere sphere = new Sphere(renderEngine);
        //sphere.Draw();
        //Cube cube = new Cube(renderEngine);
        //cube.Draw();

        //ICharacter ch = new Soldier01();

        //ch.weapon = new WeaponRocket();
        //ch.Attack(new Vector3(1, 1, 1));

    }
}

public class IShape
{
    public string name;
    public IRenderEngine renderEngine;

    public IShape(IRenderEngine renderEngine)
    {
        this.renderEngine = renderEngine;
    }

    public void Draw()
    {
        renderEngine.Render(name);
    }
}
public abstract class IRenderEngine
{
    public abstract void Render(string name);
}


public class Sphere:IShape
{

    public Sphere(IRenderEngine re):base(re)
    {
        name = "Sphere";
    }
    //public string name = "Sphere";

    //public OpenGL openGL = new OpenGL();
    //public DirectX directX = new DirectX();

    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    directX.Render(name);
    //}
}
public class Cube:IShape
{

    public Cube(IRenderEngine re):base(re)
    {
        name = "Cube";
    }
    //public string name = "Cube";

    //public OpenGL openGL = new OpenGL();
    //public DirectX directX = new DirectX();

    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    directX.Render(name);
    //}

}
public class OpenGL:IRenderEngine
{
    
    public override void Render(string name)
    {
        Debug.Log("OpenGL模拟绘制：" + name);
    }

}
public class DirectX:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DirectX模拟绘制：" + name);
    }
}
