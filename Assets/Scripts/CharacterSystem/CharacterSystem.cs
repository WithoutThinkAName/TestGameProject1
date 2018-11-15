using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 人物角色系统
/// </summary>
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();//敌人列表
    private List<ICharacter> mSoldiers = new List<ICharacter>();//士兵列表

    /// <summary>
    /// 添加敌人
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }
    /// <summary>
    /// 移除敌人
    /// </summary>
    /// <param name="enemy"></param>
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }
    /// <summary>
    /// 添加士兵
    /// </summary>
    /// <param name="soldier"></param>
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    /// <summary>
    /// 移除士兵
    /// </summary>
    /// <param name="soldier"></param>
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public override void Update()
    {
        RemoveCharacterIsKilled(mEnemys);
        RemoveCharacterIsKilled(mSoldiers);

        UpdateEnemy();
        UpdateSoldier();
    }
    /// <summary>
    /// 每帧运行士兵行动
    /// </summary>
    public void UpdateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
        }
    }
    /// <summary>
    /// 每帧运行敌人行动
    /// </summary>
    public void UpdateSoldier()
    {
        foreach (ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateFSMAI(mEnemys);
        }
    }
    /// <summary>
    /// 移除列表中死亡的人物角色
    /// </summary>
    /// <param name="characters"></param>
    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestory = new List<ICharacter>();
        foreach (ICharacter character in characters)
        {
            if (character.isKilled)
            {
                canDestory.Add(character);
            }
        }
        foreach (ICharacter character in canDestory)
        {
            character.Release();
            characters.Remove(character);
        }
    }
    /// <summary>
    /// 运行访问者
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (ICharacter character in mEnemys)
        {
            character.RunVisitor(visitor);
        }
        foreach (ICharacter character in mSoldiers)
        {
            character.RunVisitor(visitor);
        }
    }
}

