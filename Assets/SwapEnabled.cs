using UnityEngine;
using System.Collections;

public class SwapEnabled : MonoBehaviour {

  public GameObject go;

	void Update () {
    if (Input.GetKeyDown(KeyCode.Q)) {
      go.SetActive(go.activeSelf == false);
    }
	}
}
