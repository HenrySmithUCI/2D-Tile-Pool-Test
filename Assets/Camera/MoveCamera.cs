using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

  public float maxScrollOut;
  public float minScrollOut;
  public float scrollSpeed;
  public float minMoveSpeed;
  public float maxMoveSpeed;
  public float minXPos;
  public float minYPos;
  public float maxXPos;
  public float maxYPos;

  private float moveSpeed;

  private new Camera camera;


	// Use this for initialization
	void Start () {
    camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetKey(KeyCode.LeftShift)) {
      moveSpeed = maxMoveSpeed;
    }
    else {
      moveSpeed = minMoveSpeed;
    }

    float verticalChange = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime * camera.orthographicSize;
    float horizontalChange = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime * camera.orthographicSize;
    float scrollChange = Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed;

    Vector3 newPos = transform.position + new Vector3(horizontalChange, verticalChange);
    newPos.x = Mathf.Clamp(newPos.x, minXPos, maxXPos);
    newPos.y = Mathf.Clamp(newPos.y, minYPos, maxYPos);
    transform.position = newPos;
    camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + scrollChange, minScrollOut, maxScrollOut);
  }
}
