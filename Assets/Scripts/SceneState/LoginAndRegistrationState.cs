using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class LoginAndRegistrationState : ISceneState
{
    public LoginAndRegistrationState(SceneStateController controller) : base("02LoginAndRegistrationScene", controller) { }


    public override void StateStart()
    {
        GameMainFacade.Instance.InitClient();
    }

    public override void StateEnd()
    {
        base.StateEnd();


    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        GameMainFacade.Instance.UpdateClient();
    }

}

