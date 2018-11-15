using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 人物角色建造者流程目录
/// </summary>
public class CharacterBuilderDirector
{
    /// <summary>
    /// 根据方法流程建造完整人物角色对象
    /// 获取属性值
    /// 克隆角色人物游戏物体
    /// 克隆角色武器游戏物体
    /// 添加入角色系统统一管理
    /// 返还创建完成人物对象
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddIncharacterSystem();
        return builder.GetResult();
    }
}

