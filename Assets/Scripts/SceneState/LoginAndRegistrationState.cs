using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class LoginAndRegistrationState : ISceneState
{
    public LoginAndRegistrationState(SceneStateController controller) : base("02LoginAndRegistrationScene", controller) { }


    public override void StateStart()
    {
        base.StateStart();
        mMainFacade.ShowUIPanel(UIPanelType.LoginBackgroundUI);
        mMainFacade.PlayBackgroundSound(AudioSystem.Sound_Bg_Moderate);
    }

 
   


}

