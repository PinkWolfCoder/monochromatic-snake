using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public List<Transform> tailParts = new List<Transform>();
    public float minDistance = 0.25f;
    public float speed = 1;
    public GameObject tailPrefab;

    private Transform _transform;
    private Transform _currentTailPart;
    private Transform _prevTailPart;

    private void Start()
    {
        _transform = transform;
        _currentTailPart = _transform;
        for (int i = 0; i < 10; i++)
        {
            AddTailPart();
        }
    }

    private void Update()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        float currentDistance = 0f;
        tailParts[0].position = _transform.position;
        for (int i = 1; i < tailParts.Count; i++)
        {
            Transform prevPart = tailParts[i - 1];
            Transform currentPart = tailParts[i];
            currentDistance = Vector3.Distance(prevPart.position, currentPart.position);
            float newPosZ = currentDistance > minDistance ? prevPart.position.z : currentPart.position.z;
            float newPosY = currentDistance > minDistance ? prevPart.position.y : currentPart.position.y;
            Vector3 newPos = new Vector3(prevPart.position.x, newPosY, newPosZ);
            currentPart.position = Vector3.Lerp(currentPart.position, newPos, Time.deltaTime * speed);
        }
    }

    public void AddTailPart()
    {
        _prevTailPart = _currentTailPart;
        _currentTailPart = Instantiate(tailPrefab, _prevTailPart.position, Quaternion.identity, transform).transform;
        tailParts.Add(_currentTailPart);
    }
}