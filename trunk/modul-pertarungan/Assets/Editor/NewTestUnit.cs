using System.Collections.Generic;
using ModelModulPertarungan;
using ModulPertarungan;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

public class NewTestUnit 
{

    [Test]
    public void DamageReceiverFireTest()
    {
        Sorcerer sorcerer= new Sorcerer();
        sorcerer.MaxHealth = 200;
        sorcerer.CurrentHealth = 200;
        sorcerer.HandCapacity = 2;
        sorcerer.MaxSoulPoints = 30;
        sorcerer.CurrentSoulPoints = 20;
        WarlockAction action = new WarlockAction();
        action.Character = sorcerer;
        action.ReceiveDamage(action.Character, new WindCard(), 100);
        Assert.LessOrEqual(action.Character.CurrentHealth,150);
        action.ReceiveDamage(action.Character, new WaterCard(), 50);
        Assert.LessOrEqual(action.Character.CurrentHealth,100);
      

    }

    [Test]
    public void TestCardEffectProtocol()
    {   Sorcerer sorcerer= new Sorcerer();
        sorcerer.MaxHealth = 200;
        sorcerer.CurrentHealth = 200;
        sorcerer.HandCapacity = 2;
        sorcerer.MaxSoulPoints = 30;
        sorcerer.CurrentSoulPoints = 20;
        GameObject action= new GameObject();
        action.AddComponent("WarlockAction");
        action.GetComponent<WarlockAction>().Character = sorcerer;
        GameManager.Instance().AddPlayer(action);
        GameManager.Instance().AddEnemy(action);
        Invoker invoke = new Invoker();
        invoke.AddCommand(new CardExecuteCommand("SplitFire","enemy"));
        invoke.RunCommand();
        GameObject.DestroyImmediate(action);
    }

    [Test]
    public void TestEndPhaseProtocol()
    {
        Sorcerer sorcerer = new Sorcerer();
        sorcerer.MaxHealth = 200;
        sorcerer.CurrentHealth = 200;
        sorcerer.HandCapacity = 2;
        sorcerer.MaxSoulPoints = 30;
        sorcerer.Name = "agil";
        sorcerer.CurrentSoulPoints = 20;
        sorcerer.DeckList= new List<string>()
        {
            {"SplitFire"},
            {"TidalWave"}
        };
        GameObject action = new GameObject();
        action.AddComponent("WarlockAction");
        action.GetComponent<WarlockAction>().Character = sorcerer;
        action.GetComponent<WarlockAction>().HandSize = 3;
        GameManager.Instance().AddPlayer(action);
        GameManager.Instance().AddEnemy(action);
        GameManager.Instance().CurrentPawn = action;
        Invoker invoke = new Invoker();
        invoke.AddCommand(new EndPhaseCommand(new BattleStateManager()));
        GameObject.DestroyImmediate(action);
    }

}
