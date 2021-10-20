using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollowerAndSpawner : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        
        public float[] distancesTravelled;
        public bool[] activeCars;

        public GameObject[] vehicles;

        void Start() {
            distancesTravelled = new float[vehicles.Length];
            activeCars = new bool[vehicles.Length];

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update() {
            StartCoroutine(followPath(vehicles[0]));

            // int carIndex = Random.Range(0, vehicles.Length);
            // GameObject currentCar = vehicles[carIndex];
            // GameObject currentCar;

            // if (pathCreator != null)
            // {
            //     for (int i = 0; i < vehicles.Length; i++) {
            //         currentCar = vehicles[i];
            //         distanceTravelled += speed * Time.deltaTime;
            //         currentCar.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //         currentCar.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            //     }
            // }
        }

        private void followPath(int object) {
            distanceTravelled += speed * Time.deltaTime;
            object.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            object.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}