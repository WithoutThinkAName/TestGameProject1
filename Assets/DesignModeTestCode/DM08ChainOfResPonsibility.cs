using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM08ChainOfResPonsibility:MonoBehaviour
{
    void Start()
    {
        char problem = 'c';

        DMHandleA handleA = new DMHandleA();
        DMHandleB handleB = new DMHandleB();
        DMHandleC handleC = new DMHandleC();
        //handleA.nextHandle = handleB;

        handleA.SetNextHandler(handleB).SetNextHandler(handleC);

        handleA.Handle(problem);
    }
}

public abstract class IDMHandler
{
    protected IDMHandler mNextHandle = null;
    public IDMHandler nextHandle { set { mNextHandle = value; } }

    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        mNextHandle = handler;
        return mNextHandle;
    }

    public virtual void Handle(char problem) { }
}


class DMHandleA:IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem=='a')
        {
            Debug.Log("处理完了A问题。");
        }
        else
        {
            if (mNextHandle!=null)
            {
                mNextHandle.Handle(problem);
            }
        }
       
    }
}
class DMHandleB:IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
        {
            Debug.Log("处理完了B问题。");
        }
        else
        {
            if (mNextHandle != null)
            {
                mNextHandle.Handle(problem);
            }
        }
    }
}
class DMHandleC : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
        {
            Debug.Log("处理完了C问题。");
        }
        else
        {
            if (mNextHandle != null)
            {
                mNextHandle.Handle(problem);
            }
        }
    }
}