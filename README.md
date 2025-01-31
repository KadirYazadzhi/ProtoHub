# 🔌 ProtoHub - Multi-Protocol Authentication Tool 🚀

ProtoHub is a **console-based tool** for quickly authenticating to various network protocols. It supports multiple authentication methods and provides a **clean** and **efficient** interface for penetration testers, ethical hackers, and system administrators.  

🔹 **Supports 9 popular protocols**  
🔹 **IPv4 & IPv6 validation**  
🔹 **Simple and intuitive CLI interface**  
🔹 **Automated command execution**  


## 🛠️ Features

✅ **Multi-Protocol Support**  
Authenticate with **SMB, RDP, SSH, FTP, Telnet, VNC, MySQL, PostgreSQL, and HTTP Basic Auth.**  

✅ **IP Validation**  
Ensures that only valid **IPv4 and IPv6** addresses are used.  

✅ **Cross-Platform Compatibility**  
Runs on **Windows & Linux** without modification.  

✅ **Automated Command Execution**  
Executes authentication commands dynamically based on user input.  


## 📌 Supported Protocols

| #  | Protocol       | Command Execution Format |
|----|--------------|-------------------------|
| 1️⃣ | **SMB**       | `smbclient //IP/share -U user%pass` |
| 2️⃣ | **RDP**       | `xfreerdp /v:IP /u:user /p:pass` |
| 3️⃣ | **SSH**       | `ssh user@IP` |
| 4️⃣ | **FTP**       | `ftp IP` |
| 5️⃣ | **Telnet**    | `telnet IP` |
| 6️⃣ | **VNC**       | `vncviewer IP -Password pass` |
| 7️⃣ | **MySQL**     | `mysql -h IP -u user -pPass` |
| 8️⃣ | **PostgreSQL**| `psql -h IP -U user -d postgres -W pass` |
| 9️⃣ | **HTTP Basic Auth** | `curl -u user:pass http://IP` |


## 🚀 Installation & Usage

### 🔹 1. Clone the repository  
```bash
git clone https://github.com/yourusername/protohub.git
cd protohub
```

### 🔹 2. Compile & Run
  #### 🖥️ Windows
  ````
  csc ProtoHub.cs
  ProtoHub.exe
  ````
  
  #### 🐧 Linux
  ```
  mcs ProtoHub.cs
  mono ProtoHub.exe
  ```

## ⚠️ Disclaimer
This tool is intended for ethical hacking, penetration testing, and security research purposes only.
Use only on networks where you have explicit permission. 🚨
## 🛠️ Contributing 🤝

We welcome contributions from the community! Whether it's **fixing a bug**, **adding a new feature**, or **improving documentation**, your help is greatly appreciated.  

### 🔹 How to Contribute  
1. **Fork the repository** 📌  
   Click the "Fork" button on GitHub to create a copy of this repository under your account.  

2. **Clone the project** 💻  
   ```bash
   git clone https://github.com/yourusername/protohub.git
   cd protohub
   ```

3. Create a new branch 🌱
    ```bash
    git checkout -b feature-yourfeature
    ```

4. Make changes & commit 🛠️
  - Keep your code clean and well-documented.
  - Follow the existing code style and structure.
  - Commit with a meaningful message:
    ```bash
        git commit -m "Added feature: XYZ"
    ```

5. Push & Submit a Pull Request 🚀
    ```bash
    git push origin feature-yourfeature
    ```
  - Go to the original repository on GitHub.
  - Click "New Pull Request" and describe your changes.

## 📄 License 🔓

ProtoHub is **open-source software** licensed under the **MIT License**.

### ⚖️ What does this mean?
- ✅ You are free to use, modify, and distribute this software.
- ✅ You can use it for both personal and commercial projects.
- ❌ You cannot hold the author liable for any damages or misuse.
  
---

🌟 If you like this project, consider giving it a star! ⭐
