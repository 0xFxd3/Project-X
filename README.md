# Project X

![Project X Dashboard Preview](https://i.imgur.com/lEZcKRz.png)

**Project X** is a real-time health monitoring application developed in **C#** using **MQTT** as part of a Coventry University coursework. It connects securely to the **HiveMQ Cloud Broker** to receive and display patient health data such as temperature, oxygen levels, heart rate (BPM), and patient names. The dashboard presents a user-friendly UI for monitoring real-time values, with simulated data functionality for testing.

---

## 🚀 Features

- ✅ Real-time MQTT communication via HiveMQ Cloud
- 📡 Subscribes to key sensor topics for live health metrics
- 📤 Publishes simulated sensor data to broker for testing
- 📈 Updates Windows Forms UI dynamically based on received data
- 🛡 Secure connection over TLS (port 8883)
- 🔔 Desktop balloon notifications for status and activity updates

---

## 🛠 MQTT Topics Used

| Topic Name         | Purpose                            |
|--------------------|-------------------------------------|
| `sensor/temperature` | Monitors body temperature          |
| `sensor/oxygen`      | Tracks blood oxygen levels         |
| `sensor/bpm`         | Records heart rate (BPM)           |
| `sensor/name`        | Displays the patient's name/ID     |

These topics were carefully chosen to simulate key health indicators typically monitored in clinical or wearable health systems. Each topic represents an individual data stream processed by the MQTT protocol.

---

## 💻 Tech Stack

- **Language:** C#
- **UI Framework:** Windows Forms
- **MQTT Library:** uPLibrary.M2Mqtt
- **Broker:** HiveMQ Cloud
- **IDE:** Visual Studio

---

## 📷 App Preview

Here’s a look at the dashboard in action:

![Dashboard Preview](https://i.imgur.com/xflDNnN.png)

---

## ⚙️ How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ProjectX.git
