using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSet {

	[Test]
	public void TestSetSimplePasses() {
        // Use the Assert class to test conditions.
        Assert.That(2+2 == 4);
	}

    // Validar que exista un objeto con el tag Player.
    [Test]
    public void validarQueNoCambieElTagPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        Debug.Log(playerObject);

        Assert.That( playerObject != null );
    }


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator TestSetWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
