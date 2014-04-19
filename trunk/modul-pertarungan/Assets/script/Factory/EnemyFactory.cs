using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class EnemyFactory : AbstractFactory
    {
        public List<GameObject> enemies;
        public List<GameObject> enemiesplace;
        private GameObject enemy;
        public override void CreateEnemy(string ObjectName, int place)
        {
            enemies = GameManager.Instance().Enemies;
            enemy = enemies.Find(item => item.name == ObjectName);
            Debug.Log(GameManager.Instance().Enemies.Count);
            Debug.Log(enemiesplace[place].name);
            GameObject obj =Instantiate(enemy, enemiesplace[place].transform.position, Quaternion.identity) as GameObject;
            GameManager.Instance().Enemies.Remove(enemy);
            GameManager.Instance().Enemies.Add(obj);
            
        }
    }
}
