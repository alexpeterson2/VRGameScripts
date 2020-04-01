using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    // Declare variable for AISpawner manager script
    private AISpawner m_AIManager;

    // Declare variables for moving and turning
    private bool m_hasTarget = false;
    private bool m_isTurning;

    // Variable for the current waypoint
    private Vector3 m_wayPoint;
    // Variable for previous waypoint
    private Vector3 m_lastWaypoint = new Vector3(0f, 0f, 0f);

    // Going to use this to set the animation speed
    private Animator m_animator;
    private float m_speed;

    // Use this for initialization
    void Start()
    {
        // Get the AISpawner from its parent
        m_AIManager = transform.parent.GetComponentInParent<AISpawner>();
        m_animator = GetComponent<Animator>();

        SetUpNPC();
    }

    void SetUpNPC()
    {
        // Randomly scale each NPC
        float m_scale = Random.Range(0f, 2f);
        transform.localScale += new Vector3(m_scale * 1.5f, m_scale, m_scale);
    }

    void Update()
    {
        //Debug.Log("Has a Target: " + m_hasTarget);
        //Debug.Log("Can Find Target: " + CanFindTarget());
        //Debug.Log("Waypoint: " + m_wayPoint);
    }

    // Tells fish to swim to a random waypoint
    public void Swim()
    {
        // If we have not found a way point to move to
        // If a waypoint is found we need to move there
        if (!m_hasTarget)
        {
            m_hasTarget = CanFindTarget();
        }
        else
        {
            // Make sure we rotate the NPC to face its waypoint
            RotateNPC(m_wayPoint, m_speed);
            // Move the NPC in a straight line toward the waypoint
            transform.position = Vector3.MoveTowards(transform.position, m_wayPoint, m_speed * Time.deltaTime);
            //Debug.Log("Move Towards Waypoint!");
        }
    }

    // Tells fish to swim to specific GameObject
    public void SwimTo(Transform destination)
    {
        m_wayPoint = destination.position;
        Swim();
    }

    private bool CanFindTarget(float start = 1f, float end = 7f)
    {
        m_wayPoint = m_AIManager.RandomWaypoint();
        // Make sure we don't set the same waypoint twice
        if (m_lastWaypoint == m_wayPoint)
        {
            // Get a new waypoint
            m_wayPoint = m_AIManager.RandomWaypoint();
            return false;
        }
        else
        {
            // Set the new waypoints as the last waypoint
            m_lastWaypoint = m_wayPoint;
            // Get random speed for movement and animation
            m_speed = Random.Range(start, end);
            m_animator.speed = m_speed;
            // Set bool to true to say we found a WP
            Debug.Log("Speed: " + m_speed);
            return true;
        }
    }

    // If fish reaches waypoint reset target
    public bool WasTargetReached()
    {
        if (transform.position == m_wayPoint)
        {
            m_hasTarget = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Rotate the NPC to face new waypoint
    private void RotateNPC(Vector3 waypoint, float currentSpeed)
    {
        // Get random speed up for the turn
        float TurnSpeed = currentSpeed * Random.Range(1f, 3f);

        // Get new direction to look at for target
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), TurnSpeed * Time.deltaTime);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    // Declare variable for AISpawner manager script
    private AISpawner m_AIManager;

    // Declare variables for moving and turning
    private bool m_hasTarget = false;
    private bool m_isTurning;

    // Variable for the current waypoint
    private Vector3 m_wayPoint;
    private Vector3 m_lastWaypoint = new Vector3(0f, 0f, 0f);

    // Going to use this to set the animation speed
    private Animator m_animator;
    private float m_speed;

    // Use this for initialization
    void Start()
    {
        // Get the AISpawner from its parent
        m_AIManager = transform.parent.GetComponentInParent<AISpawner>();
        m_animator = GetComponent<Animator>();

        SetUpNPC();
    }

    void SetUpNPC()
    {
        // Randomly scale each NPC
        float m_scale = Random.Range(0f, 2f);
        transform.localScale += new Vector3(m_scale * 1.5f, m_scale, m_scale);
    }

    // Update is called once per frame
    void Update()
    {
        // If we have not found a way point to move to
        // If a waypoint is found we need to move there
        if (!m_hasTarget)
        {
            m_hasTarget = CanFindTarget();
        }
        else
        {
            // Make sure we rotate the NPC to face its waypoint
            RotateNPC(m_wayPoint, m_speed);
            // Move the NPC in a straight line toward the waypoint
            transform.position = Vector3.MoveTowards(transform.position, m_wayPoint, m_speed * Time.deltaTime);
            //Debug.Log("Move Towards Waypoint!");
        }

        // If NPC reaches waypoint reset target
        if (transform.position == m_wayPoint)
        {
            m_hasTarget = false;
        }

        //Debug.Log("Has a Target: " + m_hasTarget);
        //Debug.Log("Can Find Target: " + CanFindTarget());
        //Debug.Log("Waypoint: " + m_wayPoint);

    }

    private bool CanFindTarget(float start = 1f, float end = 7f)
    {
        m_wayPoint = m_AIManager.RandomWaypoint();
        // Make sure we don't set the same waypoint twice
        if (m_lastWaypoint == m_wayPoint)
        {
            // Get a new waypoint
            m_wayPoint = m_AIManager.RandomWaypoint();
            return false;
        }
        else
        {
            // Set the new waypoints as the last waypoint
            m_lastWaypoint = m_wayPoint;
            // Get random speed for movement and animation
            m_speed = Random.Range(start, end);
            m_animator.speed = m_speed;
            // Set bool to true to say we found a WP
            Debug.Log("Speed: " + m_speed);
            return true;
        }
    }

    public void FoundTarget()
    {
        m_hasTarget = false;
    }

    // Rotate the NPC to face new waypoint
    private void RotateNPC(Vector3 waypoint, float currentSpeed)
    {
        // Get random speed up for the turn
        float TurnSpeed = currentSpeed * Random.Range(1f, 3f);

        // Get new direction to look at for target
        Vector3 LookAt = waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookAt), TurnSpeed * Time.deltaTime);
    }
}
*/
