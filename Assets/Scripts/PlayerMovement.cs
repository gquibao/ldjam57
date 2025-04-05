using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementDelay = 1f;

    private float _xPosition;
    private float _timeElapsed;

    private bool _isForward = true;
    
    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= movementDelay)
        {
            Move();
            _timeElapsed = 0;
        }
    }

    private void Move()
    {
        if(_isForward)
        {
            _xPosition += 1;
            if (_xPosition >= GameData.ScreenXRange.y)
            {
                _isForward = false;
            }
        }
        else
        {
            _xPosition -= 1;
            if (_xPosition <= GameData.ScreenXRange.x)
            {
                _isForward = true;
            }
        }

        transform.position = new Vector2(_xPosition, GameData.PlayerY);
        RaiseDifficulty();
    }

    private void RaiseDifficulty()
    {
        movementDelay -= 0.05f;
        movementDelay = Mathf.Clamp(movementDelay, 0.1f, 1f);
    }
}
