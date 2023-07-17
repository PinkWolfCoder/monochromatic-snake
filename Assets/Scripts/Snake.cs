using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 50f;
    public float growAmount = 0.2f;
    public GameObject tailPrefab;

    private List<GameObject> tail = new List<GameObject>();
    private bool ate = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            ate = true;
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (ate)
        {
            GameObject newTail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            tail.Insert(0, newTail);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail[tail.Count - 1].transform.position = transform.position;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }
}