using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions
{
    public static Vector2 RotateVector(Vector2 v, float angle) {
        // Convert the rotation angle from degrees to radians
        float rotationAngleRadians = angle * Mathf.Deg2Rad;

        // Calculate the new rotated vector
        float newX = v.x * Mathf.Cos(rotationAngleRadians) - v.y * Mathf.Sin(rotationAngleRadians);
        float newY = v.x * Mathf.Sin(rotationAngleRadians) + v.y * Mathf.Cos(rotationAngleRadians);

        return new Vector2(newX, newY);
    }

    public static float FlatDistance(Vector3 v1, Vector3 v2) {
        return Vector2.Distance(new Vector2(v1.x, v1.z), new Vector2(v2.x, v2.z));
    }

    public static Vector2 FlatDirection(Vector3 v1, Vector3 v2) {
        return new Vector2(v1.x - v2.x, v1.z - v2.z).normalized;
    }
}
