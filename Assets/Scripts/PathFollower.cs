using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Transform[] _places;
    [SerializeField] private float _speed = 1f;

    private Transform _allPlacesPoint;
    
    private int _currentIndexByPlaces;

    private void Start()
    {
        _places = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _places[i] = _allPlacesPoint.GetChild(i);
    }
    
    private void Update()
    {
        Transform indexByPlaces = _places[_currentIndexByPlaces];

        transform.position = Vector3.MoveTowards(transform.position, indexByPlaces.position, _speed * Time.deltaTime);

        if (transform.position == indexByPlaces.position)
            MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        _currentIndexByPlaces++;

        if (_currentIndexByPlaces == _places.Length)
            _currentIndexByPlaces = 0;

        Vector3 thisPointVector = _places[_currentIndexByPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;
    }
}