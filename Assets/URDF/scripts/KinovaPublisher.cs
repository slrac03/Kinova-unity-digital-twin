using UnityEngine;
using Oculus.Interaction.Input;
using TMPro;
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(Button))]
    public class PoseStampedPublisher : UnityPublisher<MessageTypes.Geometry.PoseStamped>
    {
        public TextMeshProUGUI poseText;
        public GameObject RobotBaseTransform;
        protected Transform robot_tf;
        public string FrameId = "base_link";
        private bool hasPublishedDuringPinch = false;
        public Hand RHand;
        public Transform RightHand;
        private MessageTypes.Geometry.PoseStamped message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }


        private void FixedUpdate()
        {
            if (IsRightPinching())
            {
                if (!hasPublishedDuringPinch)
                {
                    UpdateMessage();
                    hasPublishedDuringPinch = true;
                }
            }
            else
            {
                hasPublishedDuringPinch = false;
            }
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.PoseStamped
            {
                header = new MessageTypes.Std.Header()
                {
                    frame_id = FrameId
                }
            };
        }
        public void OnButtonClick()
        {
            message.header.Update();
            message.pose.position.x = 0.5;
            message.pose.position.y = 0.5;
            message.pose.position.z = 0.5;
            message.pose.orientation.w = 1;
            message.pose.orientation.x = 0;
            message.pose.orientation.y = 0;
            message.pose.orientation.z = 0;
            Publish(message);
            if (poseText != null)
                {
                    poseText.text = "Home";
                }
        }
        
        private void UpdateMessage()
        {

            Vector3 handWorldPosition = RightHand.transform.position;
            if (RobotBaseTransform == null)
            {
                Debug.LogError("RobotBaseTransform not asigned");
                return;
            }
            robot_tf = RobotBaseTransform.transform;

            Vector3 localPosition = robot_tf.InverseTransformPoint(handWorldPosition);


            message.header.Update();
            message.pose.position = GetGeometryPoint(localPosition.Unity2Ros());


            message.pose.orientation.w = 1;
            message.pose.orientation.x = 0;
            message.pose.orientation.y = 0;
            message.pose.orientation.z = 0;

            Publish(message);

            if (poseText != null)
            {
                poseText.text = $"Posición relativa enviada:\n" +
                                $"({message.pose.position.x:F2}, {message.pose.position.y:F2}, {message.pose.position.z:F2})";
            }
        }


        protected MessageTypes.Geometry.Point GetGeometryPoint(Vector3 position)
        {
            MessageTypes.Geometry.Point geometryPoint = new MessageTypes.Geometry.Point();
            geometryPoint.x = position.x;
            geometryPoint.y = position.y;
            geometryPoint.z = position.z;
            return geometryPoint;
        }

        private static void GetGeometryQuaternion(Quaternion quaternion, MessageTypes.Geometry.Quaternion geometryQuaternion)
        {
            geometryQuaternion.x = quaternion.x;
            geometryQuaternion.y = quaternion.y;
            geometryQuaternion.z = quaternion.z;
            geometryQuaternion.w = quaternion.w;
        }

        private bool IsRightPinching()
        {
            return RHand != null && RHand.GetIndexFingerIsPinching();
        }
    }
}
