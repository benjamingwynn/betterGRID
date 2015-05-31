<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lbl_Configuration = New System.Windows.Forms.Label()
        Me.lbl_SerialPort = New System.Windows.Forms.Label()
        Me.ComboBox_SerialPort = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lbl_FAN1Name = New System.Windows.Forms.Label()
        Me.ComboBox_FanSpeed = New System.Windows.Forms.ComboBox()
        Me.lbl_FanSpeed = New System.Windows.Forms.Label()
        Me.lbl_RPM = New System.Windows.Forms.Label()
        Me.lbl_Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN1RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN1Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN2Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN2RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN2Name = New System.Windows.Forms.Label()
        Me.lbl_FAN3Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN3RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN3Name = New System.Windows.Forms.Label()
        Me.lbl_FAN4Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN4RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN4Name = New System.Windows.Forms.Label()
        Me.lbl_FAN5Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN5RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN5Name = New System.Windows.Forms.Label()
        Me.lbl_FAN6Wattage = New System.Windows.Forms.Label()
        Me.lbl_FAN6RPM = New System.Windows.Forms.Label()
        Me.lbl_FAN6Name = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.ComboBox_PollingInt = New System.Windows.Forms.ComboBox()
        Me.lbl_PollingInt = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox_Status = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Sensor1Name = New System.Windows.Forms.Label()
        Me.lbl_Sensor1Temp = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Sensor2Temp = New System.Windows.Forms.Label()
        Me.AutoControlCombo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TargetTemp = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TempRate = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_Sensor3Temp = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Configuration
        '
        Me.lbl_Configuration.AutoSize = True
        Me.lbl_Configuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Configuration.Location = New System.Drawing.Point(17, 9)
        Me.lbl_Configuration.Name = "lbl_Configuration"
        Me.lbl_Configuration.Size = New System.Drawing.Size(132, 13)
        Me.lbl_Configuration.TabIndex = 0
        Me.lbl_Configuration.Text = "Program Configuration"
        '
        'lbl_SerialPort
        '
        Me.lbl_SerialPort.AutoSize = True
        Me.lbl_SerialPort.Location = New System.Drawing.Point(17, 32)
        Me.lbl_SerialPort.Name = "lbl_SerialPort"
        Me.lbl_SerialPort.Size = New System.Drawing.Size(61, 13)
        Me.lbl_SerialPort.TabIndex = 1
        Me.lbl_SerialPort.Text = "Serial Port :"
        '
        'ComboBox_SerialPort
        '
        Me.ComboBox_SerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_SerialPort.FormattingEnabled = True
        Me.ComboBox_SerialPort.Location = New System.Drawing.Point(128, 29)
        Me.ComboBox_SerialPort.Name = "ComboBox_SerialPort"
        Me.ComboBox_SerialPort.Size = New System.Drawing.Size(116, 21)
        Me.ComboBox_SerialPort.TabIndex = 2
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 4800
        Me.SerialPort1.ReadTimeout = 1000
        Me.SerialPort1.WriteTimeout = 1000
        '
        'lbl_Name
        '
        Me.lbl_Name.AutoSize = True
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Name.Location = New System.Drawing.Point(17, 237)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Name.TabIndex = 3
        Me.lbl_Name.Text = "Name"
        '
        'lbl_FAN1Name
        '
        Me.lbl_FAN1Name.AutoSize = True
        Me.lbl_FAN1Name.Location = New System.Drawing.Point(17, 257)
        Me.lbl_FAN1Name.Name = "lbl_FAN1Name"
        Me.lbl_FAN1Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN1Name.TabIndex = 4
        Me.lbl_FAN1Name.Text = "FAN 1"
        '
        'ComboBox_FanSpeed
        '
        Me.ComboBox_FanSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBox_FanSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_FanSpeed.FormattingEnabled = True
        Me.ComboBox_FanSpeed.Location = New System.Drawing.Point(133, 134)
        Me.ComboBox_FanSpeed.Name = "ComboBox_FanSpeed"
        Me.ComboBox_FanSpeed.Size = New System.Drawing.Size(116, 21)
        Me.ComboBox_FanSpeed.TabIndex = 6
        '
        'lbl_FanSpeed
        '
        Me.lbl_FanSpeed.AutoSize = True
        Me.lbl_FanSpeed.Location = New System.Drawing.Point(17, 137)
        Me.lbl_FanSpeed.Name = "lbl_FanSpeed"
        Me.lbl_FanSpeed.Size = New System.Drawing.Size(65, 13)
        Me.lbl_FanSpeed.TabIndex = 5
        Me.lbl_FanSpeed.Text = "Fan Speed :"
        '
        'lbl_RPM
        '
        Me.lbl_RPM.AutoSize = True
        Me.lbl_RPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RPM.Location = New System.Drawing.Point(110, 237)
        Me.lbl_RPM.Name = "lbl_RPM"
        Me.lbl_RPM.Size = New System.Drawing.Size(34, 13)
        Me.lbl_RPM.TabIndex = 7
        Me.lbl_RPM.Text = "RPM"
        '
        'lbl_Wattage
        '
        Me.lbl_Wattage.AutoSize = True
        Me.lbl_Wattage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wattage.Location = New System.Drawing.Point(216, 237)
        Me.lbl_Wattage.Name = "lbl_Wattage"
        Me.lbl_Wattage.Size = New System.Drawing.Size(42, 13)
        Me.lbl_Wattage.TabIndex = 8
        Me.lbl_Wattage.Text = "Power"
        '
        'lbl_FAN1RPM
        '
        Me.lbl_FAN1RPM.AutoSize = True
        Me.lbl_FAN1RPM.Location = New System.Drawing.Point(110, 257)
        Me.lbl_FAN1RPM.Name = "lbl_FAN1RPM"
        Me.lbl_FAN1RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN1RPM.TabIndex = 9
        Me.lbl_FAN1RPM.Text = "0 rpm"
        '
        'lbl_FAN1Wattage
        '
        Me.lbl_FAN1Wattage.AutoSize = True
        Me.lbl_FAN1Wattage.Location = New System.Drawing.Point(216, 257)
        Me.lbl_FAN1Wattage.Name = "lbl_FAN1Wattage"
        Me.lbl_FAN1Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN1Wattage.TabIndex = 10
        Me.lbl_FAN1Wattage.Text = "0.000 watts"
        '
        'lbl_FAN2Wattage
        '
        Me.lbl_FAN2Wattage.AutoSize = True
        Me.lbl_FAN2Wattage.Location = New System.Drawing.Point(216, 275)
        Me.lbl_FAN2Wattage.Name = "lbl_FAN2Wattage"
        Me.lbl_FAN2Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN2Wattage.TabIndex = 13
        Me.lbl_FAN2Wattage.Text = "0.000 watts"
        '
        'lbl_FAN2RPM
        '
        Me.lbl_FAN2RPM.AutoSize = True
        Me.lbl_FAN2RPM.Location = New System.Drawing.Point(110, 275)
        Me.lbl_FAN2RPM.Name = "lbl_FAN2RPM"
        Me.lbl_FAN2RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN2RPM.TabIndex = 12
        Me.lbl_FAN2RPM.Text = "0 rpm"
        '
        'lbl_FAN2Name
        '
        Me.lbl_FAN2Name.AutoSize = True
        Me.lbl_FAN2Name.Location = New System.Drawing.Point(17, 275)
        Me.lbl_FAN2Name.Name = "lbl_FAN2Name"
        Me.lbl_FAN2Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN2Name.TabIndex = 11
        Me.lbl_FAN2Name.Text = "FAN 2"
        '
        'lbl_FAN3Wattage
        '
        Me.lbl_FAN3Wattage.AutoSize = True
        Me.lbl_FAN3Wattage.Location = New System.Drawing.Point(216, 293)
        Me.lbl_FAN3Wattage.Name = "lbl_FAN3Wattage"
        Me.lbl_FAN3Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN3Wattage.TabIndex = 16
        Me.lbl_FAN3Wattage.Text = "0.000 watts"
        '
        'lbl_FAN3RPM
        '
        Me.lbl_FAN3RPM.AutoSize = True
        Me.lbl_FAN3RPM.Location = New System.Drawing.Point(110, 293)
        Me.lbl_FAN3RPM.Name = "lbl_FAN3RPM"
        Me.lbl_FAN3RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN3RPM.TabIndex = 15
        Me.lbl_FAN3RPM.Text = "0 rpm"
        '
        'lbl_FAN3Name
        '
        Me.lbl_FAN3Name.AutoSize = True
        Me.lbl_FAN3Name.Location = New System.Drawing.Point(17, 293)
        Me.lbl_FAN3Name.Name = "lbl_FAN3Name"
        Me.lbl_FAN3Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN3Name.TabIndex = 14
        Me.lbl_FAN3Name.Text = "FAN 3"
        '
        'lbl_FAN4Wattage
        '
        Me.lbl_FAN4Wattage.AutoSize = True
        Me.lbl_FAN4Wattage.Location = New System.Drawing.Point(216, 311)
        Me.lbl_FAN4Wattage.Name = "lbl_FAN4Wattage"
        Me.lbl_FAN4Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN4Wattage.TabIndex = 19
        Me.lbl_FAN4Wattage.Text = "0.000 watts"
        '
        'lbl_FAN4RPM
        '
        Me.lbl_FAN4RPM.AutoSize = True
        Me.lbl_FAN4RPM.Location = New System.Drawing.Point(110, 311)
        Me.lbl_FAN4RPM.Name = "lbl_FAN4RPM"
        Me.lbl_FAN4RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN4RPM.TabIndex = 18
        Me.lbl_FAN4RPM.Text = "0 rpm"
        '
        'lbl_FAN4Name
        '
        Me.lbl_FAN4Name.AutoSize = True
        Me.lbl_FAN4Name.Location = New System.Drawing.Point(17, 311)
        Me.lbl_FAN4Name.Name = "lbl_FAN4Name"
        Me.lbl_FAN4Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN4Name.TabIndex = 17
        Me.lbl_FAN4Name.Text = "FAN 4"
        '
        'lbl_FAN5Wattage
        '
        Me.lbl_FAN5Wattage.AutoSize = True
        Me.lbl_FAN5Wattage.Location = New System.Drawing.Point(216, 329)
        Me.lbl_FAN5Wattage.Name = "lbl_FAN5Wattage"
        Me.lbl_FAN5Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN5Wattage.TabIndex = 22
        Me.lbl_FAN5Wattage.Text = "0.000 watts"
        '
        'lbl_FAN5RPM
        '
        Me.lbl_FAN5RPM.AutoSize = True
        Me.lbl_FAN5RPM.Location = New System.Drawing.Point(110, 329)
        Me.lbl_FAN5RPM.Name = "lbl_FAN5RPM"
        Me.lbl_FAN5RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN5RPM.TabIndex = 21
        Me.lbl_FAN5RPM.Text = "0 rpm"
        '
        'lbl_FAN5Name
        '
        Me.lbl_FAN5Name.AutoSize = True
        Me.lbl_FAN5Name.Location = New System.Drawing.Point(17, 329)
        Me.lbl_FAN5Name.Name = "lbl_FAN5Name"
        Me.lbl_FAN5Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN5Name.TabIndex = 20
        Me.lbl_FAN5Name.Text = "FAN 5"
        '
        'lbl_FAN6Wattage
        '
        Me.lbl_FAN6Wattage.AutoSize = True
        Me.lbl_FAN6Wattage.Location = New System.Drawing.Point(216, 347)
        Me.lbl_FAN6Wattage.Name = "lbl_FAN6Wattage"
        Me.lbl_FAN6Wattage.Size = New System.Drawing.Size(62, 13)
        Me.lbl_FAN6Wattage.TabIndex = 25
        Me.lbl_FAN6Wattage.Text = "0.000 watts"
        '
        'lbl_FAN6RPM
        '
        Me.lbl_FAN6RPM.AutoSize = True
        Me.lbl_FAN6RPM.Location = New System.Drawing.Point(110, 347)
        Me.lbl_FAN6RPM.Name = "lbl_FAN6RPM"
        Me.lbl_FAN6RPM.Size = New System.Drawing.Size(33, 13)
        Me.lbl_FAN6RPM.TabIndex = 24
        Me.lbl_FAN6RPM.Text = "0 rpm"
        '
        'lbl_FAN6Name
        '
        Me.lbl_FAN6Name.AutoSize = True
        Me.lbl_FAN6Name.Location = New System.Drawing.Point(17, 347)
        Me.lbl_FAN6Name.Name = "lbl_FAN6Name"
        Me.lbl_FAN6Name.Size = New System.Drawing.Size(37, 13)
        Me.lbl_FAN6Name.TabIndex = 23
        Me.lbl_FAN6Name.Text = "FAN 6"
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(12, 498)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Status.TabIndex = 26
        Me.lbl_Status.Text = "xxxx"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(209, 498)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Exit.TabIndex = 27
        Me.btn_Exit.Text = "Exit"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'ComboBox_PollingInt
        '
        Me.ComboBox_PollingInt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_PollingInt.FormattingEnabled = True
        Me.ComboBox_PollingInt.Location = New System.Drawing.Point(128, 56)
        Me.ComboBox_PollingInt.Name = "ComboBox_PollingInt"
        Me.ComboBox_PollingInt.Size = New System.Drawing.Size(116, 21)
        Me.ComboBox_PollingInt.TabIndex = 29
        '
        'lbl_PollingInt
        '
        Me.lbl_PollingInt.AutoSize = True
        Me.lbl_PollingInt.Location = New System.Drawing.Point(17, 59)
        Me.lbl_PollingInt.Name = "lbl_PollingInt"
        Me.lbl_PollingInt.Size = New System.Drawing.Size(82, 13)
        Me.lbl_PollingInt.TabIndex = 28
        Me.lbl_PollingInt.Text = "Polling Interval :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "msec"
        '
        'PictureBox_Status
        '
        Me.PictureBox_Status.BackColor = System.Drawing.Color.Red
        Me.PictureBox_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox_Status.Location = New System.Drawing.Point(253, 35)
        Me.PictureBox_Status.Name = "PictureBox_Status"
        Me.PictureBox_Status.Size = New System.Drawing.Size(10, 10)
        Me.PictureBox_Status.TabIndex = 32
        Me.PictureBox_Status.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "GRID+ Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 394)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sensor Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(158, 394)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Temperature (C)"
        '
        'lbl_Sensor1Name
        '
        Me.lbl_Sensor1Name.AutoSize = True
        Me.lbl_Sensor1Name.Location = New System.Drawing.Point(14, 416)
        Me.lbl_Sensor1Name.Name = "lbl_Sensor1Name"
        Me.lbl_Sensor1Name.Size = New System.Drawing.Size(92, 13)
        Me.lbl_Sensor1Name.TabIndex = 33
        Me.lbl_Sensor1Name.Text = "CPU Temperature"
        '
        'lbl_Sensor1Temp
        '
        Me.lbl_Sensor1Temp.AutoSize = True
        Me.lbl_Sensor1Temp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Sensor1Temp.Location = New System.Drawing.Point(158, 416)
        Me.lbl_Sensor1Temp.Name = "lbl_Sensor1Temp"
        Me.lbl_Sensor1Temp.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Sensor1Temp.TabIndex = 33
        Me.lbl_Sensor1Temp.Text = "???"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 435)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "GPU Temperature"
        '
        'lbl_Sensor2Temp
        '
        Me.lbl_Sensor2Temp.AutoSize = True
        Me.lbl_Sensor2Temp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Sensor2Temp.Location = New System.Drawing.Point(158, 435)
        Me.lbl_Sensor2Temp.Name = "lbl_Sensor2Temp"
        Me.lbl_Sensor2Temp.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Sensor2Temp.TabIndex = 33
        Me.lbl_Sensor2Temp.Text = "???"
        '
        'AutoControlCombo
        '
        Me.AutoControlCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AutoControlCombo.FormattingEnabled = True
        Me.AutoControlCombo.Items.AddRange(New Object() {"Manual Control", "CPU Temperature", "GPU Temperature", "Mobo Temperature", "CPU & GPU Avg Temp", "CPU & Mobo Avg Temp", "All Avg Temperatures"})
        Me.AutoControlCombo.Location = New System.Drawing.Point(133, 107)
        Me.AutoControlCombo.Name = "AutoControlCombo"
        Me.AutoControlCombo.Size = New System.Drawing.Size(156, 21)
        Me.AutoControlCombo.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Setting:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(255, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "°C"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 374)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "System Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Target Temperature:"
        '
        'TargetTemp
        '
        Me.TargetTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.TargetTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TargetTemp.FormattingEnabled = True
        Me.TargetTemp.Items.AddRange(New Object() {"0", "5", "10", "15", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70"})
        Me.TargetTemp.Location = New System.Drawing.Point(133, 161)
        Me.TargetTemp.Name = "TargetTemp"
        Me.TargetTemp.Size = New System.Drawing.Size(116, 21)
        Me.TargetTemp.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(255, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "%"
        '
        'TempRate
        '
        Me.TempRate.Location = New System.Drawing.Point(133, 188)
        Me.TempRate.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TempRate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TempRate.Name = "TempRate"
        Me.TempRate.Size = New System.Drawing.Size(116, 20)
        Me.TempRate.TabIndex = 34
        Me.TempRate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 454)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Motherboard Temperature"
        '
        'lbl_Sensor3Temp
        '
        Me.lbl_Sensor3Temp.AutoSize = True
        Me.lbl_Sensor3Temp.Location = New System.Drawing.Point(158, 454)
        Me.lbl_Sensor3Temp.Name = "lbl_Sensor3Temp"
        Me.lbl_Sensor3Temp.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Sensor3Temp.TabIndex = 33
        Me.lbl_Sensor3Temp.Text = "???"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Temperature Step:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Control Configuration"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(255, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(18, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "°C"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(209, 469)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "About"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 533)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TempRate)
        Me.Controls.Add(Me.lbl_Sensor2Temp)
        Me.Controls.Add(Me.lbl_Sensor1Temp)
        Me.Controls.Add(Me.lbl_Sensor3Temp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_Sensor1Name)
        Me.Controls.Add(Me.PictureBox_Status)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AutoControlCombo)
        Me.Controls.Add(Me.ComboBox_PollingInt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbl_PollingInt)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.lbl_FAN6Wattage)
        Me.Controls.Add(Me.lbl_FAN6RPM)
        Me.Controls.Add(Me.lbl_FAN6Name)
        Me.Controls.Add(Me.lbl_FAN5Wattage)
        Me.Controls.Add(Me.lbl_FAN5RPM)
        Me.Controls.Add(Me.lbl_FAN5Name)
        Me.Controls.Add(Me.lbl_FAN4Wattage)
        Me.Controls.Add(Me.lbl_FAN4RPM)
        Me.Controls.Add(Me.lbl_FAN4Name)
        Me.Controls.Add(Me.lbl_FAN3Wattage)
        Me.Controls.Add(Me.lbl_FAN3RPM)
        Me.Controls.Add(Me.lbl_FAN3Name)
        Me.Controls.Add(Me.lbl_FAN2Wattage)
        Me.Controls.Add(Me.lbl_FAN2RPM)
        Me.Controls.Add(Me.lbl_FAN2Name)
        Me.Controls.Add(Me.lbl_FAN1Wattage)
        Me.Controls.Add(Me.lbl_FAN1RPM)
        Me.Controls.Add(Me.lbl_Wattage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_RPM)
        Me.Controls.Add(Me.TargetTemp)
        Me.Controls.Add(Me.ComboBox_FanSpeed)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbl_FanSpeed)
        Me.Controls.Add(Me.lbl_FAN1Name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_Name)
        Me.Controls.Add(Me.ComboBox_SerialPort)
        Me.Controls.Add(Me.lbl_SerialPort)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbl_Configuration)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "betterGRID"
        CType(Me.PictureBox_Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Configuration As System.Windows.Forms.Label
    Friend WithEvents lbl_SerialPort As System.Windows.Forms.Label
    Friend WithEvents ComboBox_SerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN1Name As System.Windows.Forms.Label
    Friend WithEvents ComboBox_FanSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_FanSpeed As System.Windows.Forms.Label
    Friend WithEvents lbl_RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN1Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN2Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN2RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN2Name As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN3Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN3RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN3Name As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN4Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN4RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN4Name As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN5Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN5RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN5Name As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN6Wattage As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN6RPM As System.Windows.Forms.Label
    Friend WithEvents lbl_FAN6Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbl_FAN1RPM As System.Windows.Forms.Label
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
    Friend WithEvents ComboBox_PollingInt As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_PollingInt As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Status As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Sensor1Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Sensor1Temp As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Sensor2Temp As System.Windows.Forms.Label
    Friend WithEvents AutoControlCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TargetTemp As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TempRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Sensor3Temp As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
