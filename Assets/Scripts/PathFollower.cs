using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Transform[] _arrayPlaces;
    [SerializeField] private float _speed = 1f;

    [SerializeField] private Transform _allPlacesPoint;
    
    private int _indexPlacesInArray;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }
    
    private void Update()
    {
        Transform IndexByArray = _arrayPlaces[_indexPlacesInArray];

        transform.position = Vector3.MoveTowards(transform.position, IndexByArray.position, _speed * Time.deltaTime);

        if (transform.position == IndexByArray.position)
            MoveToNextPoint();
    }

    private Vector3 MoveToNextPoint()
    {
        _indexPlacesInArray++;

        if (_indexPlacesInArray == _arrayPlaces.Length)
            _indexPlacesInArray = 0;

        Vector3 thisPointVector = _arrayPlaces[_indexPlacesInArray].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}