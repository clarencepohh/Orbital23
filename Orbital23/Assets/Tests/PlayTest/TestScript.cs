using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestScript
{
    ItemCollector itemCollector;

    [SetUp]
    public void SetUp()
    {
        // Load the test scene
        SceneManager.LoadScene("maintest");

        // Get a reference to the ItemCollector script on the Shuttlecock object
        itemCollector = GameObject.FindGameObjectWithTag("Shuttlecock").GetComponent<ItemCollector>();
    } 

    [UnityTest]
    public IEnumerator OnTriggerEnter2D_CoinIncreasesScore()
    {
        // Arrange
        int initialScore = itemCollector.score;

        // Create a new coin object
        GameObject coin = new GameObject("Coin", typeof(BoxCollider2D));
        coin.tag = "Coin";

        // Act
        itemCollector.OnTriggerEnter2D(coin.GetComponent<Collider2D>());

        // Assert
        Assert.AreEqual(initialScore + 1, itemCollector.score);
        
        yield return null;
    }
}