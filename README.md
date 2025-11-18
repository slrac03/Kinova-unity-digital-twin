# Digital Twin of the Kinova Gen3 Robotic Arm (Unity + Quest 3 + ROS)

This repository contains the Unity project used to build an interactive **XR digital twin** of the **Kinova Gen3 robotic arm**, featuring real-time manipulation through **hand-tracking gestures** on the Meta Quest 3 and optional interaction through an **NLP-based virtual assistant**.

The system was designed for **educational and training purposes**, allowing students to safely explore robotics concepts without directly operating the physical robot.

## System used with this [ROS repository](https://github.com/slrac03/kinova-ros-noetic-slrac) hosted in a VM with Ubuntu 20.04

## Features

- **Full digital twin** of the Kinova Gen3 (URDF-based kinematics).
- **Real-time XR manipulation** using hand-tracking (grab → move → release).
- **Inverse kinematics control** for safe and intuitive manipulation.
- **External ROS integration** (bidirectional communication).
- **NLP virtual assistant** to guide users inside XR.
- **Tutorial spanish scene** with narrated instructions and an interactive onboarding system.


##  Versions

- Windows 11
- [**Unity** v2022.3.22f1](https://unity.com/download)
- [**Meta XR All-In-One**](https://assetstore.unity.com/packages/tools/integration/meta-xr-all-in-one-sdk-269657?srsltid=AfmBOoq_KGW-tMJ287MBGtIBhsgGdB6YfXydnOWB1-GvhpkA8cPBzRze)
- [**ROS–Unity Communication**](https://github.com/siemens/ros-sharp)
- [**URDF importer system**](https://github.com/Unity-Technologies/URDF-Importer)

### UNITY
  - Clone this repo with ```git clone https://github.com/slrac03/kinova-ros-noetic-slrac.git```
  - in Unity Hub **Add project from disk** and select the current version
  - There's a *RosConnectorObject* inside a empty GameObject **ROS**, this is the one you'll be able to config to make the connections.
  - Inside RosBridgeServerUrl make sure it's ```ws://192.168.1.11:9090``` writed and using ```Newtonsoft_JSON``` with ```Web Socket Sharp``` protocol

## Follow this video to [connect the Quest3](https://www.youtube.com/watch?v=T6Y0rV_1GQc), make sure [developer mode](https://developers.meta.com/horizon/documentation/native/android/mobile-device-setup/) in the Meta Account is active

