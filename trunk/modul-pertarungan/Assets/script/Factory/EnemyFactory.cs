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
        public override void CreateEnemy(string objectName, int place)
        {
            enemies = GameManager.Instance().Enemies;
            enemy = enemies.Find(item => item.name == objectName);
            Debug.Log(enemiesplace[place].name);
            var obj =Instantiate(enemy, enemiesplace[place].transform.position, Quaternion.identity) as GameObject;
            GameManager.Instance().Enemies.Remove(enemy);
            GameManager.Instance().Enemies.Add(obj);
            
        }
    }
}
