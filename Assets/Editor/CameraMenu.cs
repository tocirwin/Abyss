using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CameraMenu
{
		[MenuItem("Camera/Orthographic")]
		static public void OrthographicCamera()
		{
			Camera cam = SceneView.lastActiveSceneView.camera;
			cam.transparencySortMode = TransparencySortMode.Orthographic;
		}
		[MenuItem("Camera/Perspective")]
		static public void PerspectiveCamera()
		{
			Camera cam = SceneView.lastActiveSceneView.camera;
			cam.transparencySortMode = TransparencySortMode.Default;
		}
}
