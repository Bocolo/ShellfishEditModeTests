using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MenuTest
{
    private Menu menu;
    [OneTimeSetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        menu = go.AddComponent<Menu>();
    }
  
}
