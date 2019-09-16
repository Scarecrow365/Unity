using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _gridMoveTimer;
    [SerializeField] private float _borders;

    [SerializeField] private Transform snakeHead;
    [SerializeField] private GameObject _snakeTail;
    [SerializeField] private List<Transform> _tails = new List<Transform>();
    private List<Vector3Int> _lastPositionList = new List<Vector3Int>();

    private Transform target;
    private float _gridMoveTimerMax;
    private Vector3Int _gridPosition;
    private List<Vector3Int> _sides = new List<Vector3Int>();
    private Vector3Int _currentDirection;

    void Awake()
    {
        _gridMoveTimerMax = _gridMoveTimer;
        _gridPosition = Vector3Int.RoundToInt(transform.position);
        _sides.Add(new Vector3Int(0, 0, -1));
        _sides.Add(new Vector3Int(0, 0, 1));
        _sides.Add(Vector3Int.left);
        _sides.Add(Vector3Int.right);

        _lastPositionList.Add(Vector3Int.RoundToInt(transform.position));

        foreach (var tail in _tails)
            _lastPositionList.Add(Vector3Int.RoundToInt(tail.position));
    }

    void Update()
    {
        _gridMoveTimer += Time.deltaTime;

        CheckTarget();

        if (!(_gridMoveTimer >= _gridMoveTimerMax)) return;

        if (!LookAtTarget())
            Move(_sides[Random.Range(0, _sides.Count)]);
    }

    private void Move(Vector3Int direction)
    {
        Vector3Int newDirection = CheckDirection(direction);
        _gridPosition += newDirection;
        Vector3Int newGridPos = CheckBorder(_gridPosition);
        _gridPosition = newGridPos;
        _gridMoveTimer -= _gridMoveTimerMax;

        if (newGridPos != _tails[0].position)
        {
            HeadRotate(newDirection);
            Vector3Int roundedCoordinate = Vector3Int.RoundToInt(newGridPos);
            transform.position = roundedCoordinate;
            SnakeTailMove(Vector3Int.RoundToInt(transform.position));
        }
    }

    private Vector3Int CheckDirection(Vector3Int newDirection)
    {
        if (newDirection == _currentDirection * -1)
            newDirection = _currentDirection;

        _currentDirection = newDirection;
        return newDirection;
    }

    private Vector3Int CheckBorder(Vector3Int gridPos)
    {
        if (gridPos.x > _borders)
        {
            gridPos.x = (int) _borders;
            //gridPos.z += Random.Range(-1, 1);
        }

        if (gridPos.x < -_borders)
        {
            gridPos.x = (int) -_borders;
            //gridPos.z += Random.Range(-1, 1);
        }

        if (gridPos.z > _borders)
        {
            gridPos.z = (int) _borders;
            //gridPos.x += Random.Range(-1, 1);
        }

        if (gridPos.z < -_borders)
        {
            gridPos.z = (int) -_borders;
            //gridPos.x += Random.Range(-1, 1);
        }

        Debug.Log(gridPos);
        return gridPos;
    }

    private void HeadRotate(Vector3Int dir)
    {
        switch (dir.x)
        {
            case 1:
                transform.eulerAngles = new Vector3Int(0, 90, 0);
                break;
            case -1:
                transform.eulerAngles = new Vector3Int(0, -90, 0);
                break;
        }

        switch (dir.z)
        {
            case 1:
                transform.eulerAngles = new Vector3Int(0, 0, 0);
                break;
            case -1:
                transform.eulerAngles = new Vector3Int(0, 180, 0);
                break;
        }
    }

    private void SnakeTailMove(Vector3Int snakeHead)
    {
        _lastPositionList.Insert(0, snakeHead);
        _lastPositionList.RemoveAt(_lastPositionList.Count - 1);

        for (int i = 0; i < _tails.Count; i++)
            _tails[i].position = _lastPositionList[i + 1];
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Apple"))
            AddTail();
    }

    private void AddTail()
    {
        var tail = Instantiate(_snakeTail, _lastPositionList[_lastPositionList.Count - 1], Quaternion.identity,
            transform);
        _tails.Add(tail.transform);
        _lastPositionList.Add(Vector3Int.RoundToInt(tail.transform.position));
    }

    private bool LookAtTarget()
    {
        bool isTarget = false;
        var distanceX = target.position.x - transform.position.x;
        var distanceZ = target.position.z - transform.position.z;

        if (distanceX < 1 && distanceX > -1)
        {
            Move(transform.position.z > target.position.z ? new Vector3Int(0, 0, -1) : new Vector3Int(0, 0, 1));
            isTarget = true;
        }

        else if (distanceZ < 1 && distanceZ > -1)
        {
            Move(transform.position.x > target.position.x ? Vector3Int.left : Vector3Int.right);
            isTarget = true;
        }

        return isTarget;
    }

    private void CheckTarget()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Apple").GetComponent<Transform>();
    }
}
