' betterGRID
'   An alternative NZXT GRID+ Fan Controller
'   Created by Xenxier - http://xenxier.com

' Based on GRIDfan
'   Written by rizvanrp <rizvanrp@gmail.com>

Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports OpenHardwareMonitor
Imports OpenHardwareMonitor.Hardware

Public Class Form1
    ' This PC (OpenHardwareMonitor)
    Dim cp As New Computer

    ' Globals
    Dim grid_lastcommand = 0
    Dim speed_changed = False
    Dim serial_input As Byte() = New Byte(10) {}
    Dim total_voltage As Double
    Dim fan1_amps As Double
    Dim fan2_amps As Double
    Dim fan3_amps As Double
    Dim fan4_amps As Double
    Dim fan5_amps As Double
    Dim fan6_amps As Double

    ' GRID+ Init Command
    Dim grid_initcommand As Byte() = New Byte() {&HC0}

    ' FAN RPM Polling Commands
    Dim fan1_pollRPMcommand As Byte() = New Byte() {&H8A, &H1}
    Dim fan2_pollRPMcommand As Byte() = New Byte() {&H8A, &H2}
    Dim fan3_pollRPMcommand As Byte() = New Byte() {&H8A, &H3}
    Dim fan4_pollRPMcommand As Byte() = New Byte() {&H8A, &H4}
    Dim fan5_pollRPMcommand As Byte() = New Byte() {&H8A, &H5}
    Dim fan6_pollRPMcommand As Byte() = New Byte() {&H8A, &H6}

    ' FAN Voltage Polling Command
    Dim fan_pollVOLTScommand As Byte() = New Byte() {&H84, &H0}

    ' FAN Amperage Polling Command
    Dim fan1_pollAMPScommand As Byte() = New Byte() {&H85, &H1}
    Dim fan2_pollAMPScommand As Byte() = New Byte() {&H85, &H2}
    Dim fan3_pollAMPScommand As Byte() = New Byte() {&H85, &H3}
    Dim fan4_pollAMPScommand As Byte() = New Byte() {&H85, &H4}
    Dim fan5_pollAMPScommand As Byte() = New Byte() {&H85, &H5}
    Dim fan6_pollAMPScommand As Byte() = New Byte() {&H85, &H6}

    ' FAN RPM Control Commands
    ' 44 00 c0 00 00 06 00 (40%)
    ' 44 00 c0 00 00 06 50 (45%)
    ' ..
    ' 44 00 c0 00 00 0c 00 (100%)
    Dim fan_controlRPMcommand_40pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H6, &H0}
    Dim fan_controlRPMcommand_45pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H6, &H50}
    Dim fan_controlRPMcommand_50pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H7, &H0}
    Dim fan_controlRPMcommand_55pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H7, &H50}
    Dim fan_controlRPMcommand_60pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H8, &H0}
    Dim fan_controlRPMcommand_65pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H8, &H50}
    Dim fan_controlRPMcommand_70pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H9, &H0}
    Dim fan_controlRPMcommand_75pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &H9, &H50}
    Dim fan_controlRPMcommand_80pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &HA, &H0}
    Dim fan_controlRPMcommand_85pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &HA, &H50}
    Dim fan_controlRPMcommand_90pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &HB, &H0}
    Dim fan_controlRPMcommand_95pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &HB, &H50}
    Dim fan_controlRPMcommand_100pc As Byte() = New Byte() {&H44, &H0, &HC0, &H0, &H0, &HC, &H0}

    ' ini location
    Dim ini As String = Application.StartupPath + "\betterGRID.ini"

    ' Card type
    Dim card As HardwareType

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Save serial port, fan speed and polling interval
        writeIni(ini, "settings", "serialport", ComboBox_SerialPort.Text)
        writeIni(ini, "settings", "fanspeed", ComboBox_FanSpeed.Text)
        writeIni(ini, "settings", "pollinginterval", ComboBox_PollingInt.Text)
        writeIni(ini, "settings", "targettemp", TargetTemp.SelectedIndex)
        writeIni(ini, "settings", "control", AutoControlCombo.SelectedIndex)
        writeIni(ini, "settings", "temprate", TempRate.Value)
        ' Save fan names
        For i As Integer = 1 To 6
            saveFanName(i)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open OHW CP object
        cp.Open()
        cp.GPUEnabled = True
        cp.MainboardEnabled = True
        cp.CPUEnabled = True
        cp.HDDEnabled = False
        cp.RAMEnabled = False
        cp.FanControllerEnabled = False

        ' Print diagnostic report
        System.Diagnostics.Debug.Print(cp.GetReport())

        ' What type of card do we have?
        If Not (GetHWInfo(HardwareType.GpuAti, "temp") = "UKN") Then
            card = HardwareType.GpuAti
        End If

        If Not (GetHWInfo(HardwareType.GpuNvidia, "temp") = "UKN") Then
            card = HardwareType.GpuNvidia
        End If

        If AutoControlCombo.SelectedIndex = 0 Then ' Manual control
            ComboBox_FanSpeed.Enabled = True
            TargetTemp.Enabled = False
            TempRate.Enabled = False
        Else
            ComboBox_FanSpeed.Enabled = False
            TargetTemp.Enabled = True
            TempRate.Enabled = True
        End If

        ' Set COM port dropdown values
        ComboBox_SerialPort.DataSource = SerialPort.GetPortNames
        ' Set fan speed percentage values
        Dim strarray_fanspeed As String() = New String() {"40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "100"}
        ComboBox_FanSpeed.DataSource = strarray_fanspeed
        ' Set polling interval dropdown values
        Dim strarray_pollingint As String() = New String() {"200", "500", "1000", "2000", "5000"}
        ComboBox_PollingInt.DataSource = strarray_pollingint
        ' Set actual polling interval
        Timer1.Interval = ComboBox_PollingInt.Text

        ' Read config
        ComboBox_SerialPort.Text = ReadIni(ini, "settings", "serialport", "")
        ComboBox_FanSpeed.Text = ReadIni(ini, "settings", "fanspeed", "")
        ComboBox_PollingInt.Text = ReadIni(ini, "settings", "pollinginterval", "")

        TargetTemp.SelectedIndex = ReadIni(ini, "settings", "targettemp", 0)
        AutoControlCombo.SelectedIndex = ReadIni(ini, "settings", "control", 0)
        TempRate.Value = ReadIni(ini, "settings", "temprate", 1)

        ' Read fan names
        For i As Integer = 1 To 6
            readFanName(i)
        Next

        ' If the fan names are empty, fill them
        If (lbl_FAN1Name.Text = "") Then
            lbl_FAN1Name.Text = "FAN 1"
        End If

        ' Configure serial port
        Try
            ' Close serial port if already open
            If (SerialPort1.IsOpen) Then
                SerialPort1.Close()
            End If
            SerialPort1.PortName = ComboBox_SerialPort.Text
            lbl_Status.Text = "Serial Port set as " + SerialPort1.PortName.ToString + " - NO DEVICE"
        Catch ex As Exception
            lbl_Status.Text = "Unable to set Serial Port as " + SerialPort1.PortName.ToString
        End Try

        ' Connect serial port
        Try
            SerialPort1.Open()
        Catch ex As Exception
            lbl_Status.Text = "Unable to open Serial Port " + SerialPort1.PortName.ToString
        End Try

    End Sub

    Private Sub ComboBox_SerialPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_SerialPort.SelectedIndexChanged
        ' Configure serial port
        Try
            ' Close serial port if already open
            If (SerialPort1.IsOpen) Then
                SerialPort1.Close()
            End If
            SerialPort1.PortName = ComboBox_SerialPort.Text
            lbl_Status.Text = "Serial Port set as " + SerialPort1.PortName.ToString
        Catch ex As Exception
            lbl_Status.Text = "Unable to set Serial Port as " + SerialPort1.PortName.ToString
        End Try

        ' Connect to serial port
        Try
            SerialPort1.Open()
        Catch ex As Exception
            lbl_Status.Text = "Unable to open Serial Port " + SerialPort1.PortName.ToString
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Show system temps
        lbl_Sensor1Temp.Text = GetHWInfo(HardwareType.CPU, "temperature")
        lbl_Sensor2Temp.Text = GetHWInfo(card, "temperature")
        lbl_Sensor3Temp.Text = GetHWInfo(HardwareType.Mainboard, "temperature")

        ' Update fan speed based on control mode
        Dim fanspeed As Integer
        Select Case AutoControlCombo.SelectedIndex
            Case 0 ' Manual
                ' Do nothing
            Case 1 ' CPU temp
                fanspeed = Math.Round((CDbl(lbl_Sensor1Temp.Text) - CDbl(TargetTemp.Text)) / TempRate.Value)
            Case 2 ' GPU temp
                fanspeed = Math.Round((CDbl(lbl_Sensor2Temp.Text) - CDbl(TargetTemp.Text)) / TempRate.Value)
            Case 3 ' Board temp
                fanspeed = Math.Round((CDbl(lbl_Sensor3Temp.Text) - CDbl(TargetTemp.Text)) / TempRate.Value)
            Case 4 ' cpu & gpu temp
                fanspeed = Math.Round((((CDbl(lbl_Sensor1Temp.Text) + CDbl(lbl_Sensor2Temp.Text)) / 2) - CDbl(TargetTemp.Text)) / TempRate.Value)
            Case 5 ' CPU & board temp
                fanspeed = Math.Round((((CDbl(lbl_Sensor1Temp.Text) + CDbl(lbl_Sensor3Temp.Text)) / 2) - CDbl(TargetTemp.Text)) / TempRate.Value)
            Case 6 ' all
                fanspeed = Math.Round((((CDbl(lbl_Sensor1Temp.Text) + CDbl(lbl_Sensor2Temp.Text) + CDbl(lbl_Sensor3Temp.Text)) / 3) - CDbl(TargetTemp.Text)) / TempRate.Value)
        End Select

        If AutoControlCombo.SelectedIndex > 0 Then
            If fanspeed < 0 Then
                ComboBox_FanSpeed.SelectedIndex = 0
            ElseIf fanspeed > 11 Then
                ComboBox_FanSpeed.SelectedIndex = 11
            Else
                ComboBox_FanSpeed.SelectedIndex = fanspeed
            End If
        End If

        ' Check if serial port is open
        If (SerialPort1.IsOpen) Then
            Select Case grid_lastcommand
                Case 0
                    ' Not initialized -- send init command
                    Try
                        SerialPort1.Write(grid_initcommand, 0, 1)
                    Catch ex As Exception

                    End Try
                Case 1
                    ' Poll FAN1 RPM
                    ' Send FAN1 RPM Poll Command
                    Try
                        SerialPort1.Write(fan1_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 2
                    ' Poll FAN2 RPM
                    ' Send FAN2 RPM Poll Command
                    Try
                        SerialPort1.Write(fan2_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 3
                    ' Poll FAN3 RPM
                    ' Send FAN3 RPM Poll Command
                    Try
                        SerialPort1.Write(fan3_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 4
                    ' Poll FAN4 RPM
                    ' Send FAN4 RPM Poll Command
                    Try
                        SerialPort1.Write(fan4_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 5
                    ' Poll FAN5 RPM
                    ' Send FAN5 RPM Poll Command
                    Try
                        SerialPort1.Write(fan5_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 6
                    ' Poll FAN6 RPM
                    ' Send FAN6 RPM Poll Command
                    Try
                        SerialPort1.Write(fan6_pollRPMcommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 7
                    ' Poll FAN Voltage
                    ' Send FAN Voltage Polling Command
                    Try
                        SerialPort1.Write(fan_pollVOLTScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 8
                    ' Poll FAN1 Amperage
                    ' Send FAN1 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan1_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 9
                    ' Poll FAN2 Amperage
                    ' Send FAN2 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan2_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 10
                    ' Poll FAN3 Amperage
                    ' Send FAN3 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan3_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 11
                    ' Poll FAN4 Amperage
                    ' Send FAN4 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan4_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 12
                    ' Poll FAN5 Amperage
                    ' Send FAN5 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan5_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 13
                    ' Poll FAN6 Amperage
                    ' Send FAN6 Amperage Poll Command
                    Try
                        SerialPort1.Write(fan6_pollAMPScommand, 0, 2)
                    Catch ex As Exception
                    End Try
                Case 14
                    ' Send FAN Speed Configuration Command
                    Try
                        If (ComboBox_FanSpeed.Text = "40") Then SerialPort1.Write(fan_controlRPMcommand_40pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "45") Then SerialPort1.Write(fan_controlRPMcommand_45pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "50") Then SerialPort1.Write(fan_controlRPMcommand_50pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "55") Then SerialPort1.Write(fan_controlRPMcommand_55pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "60") Then SerialPort1.Write(fan_controlRPMcommand_60pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "65") Then SerialPort1.Write(fan_controlRPMcommand_65pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "70") Then SerialPort1.Write(fan_controlRPMcommand_70pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "75") Then SerialPort1.Write(fan_controlRPMcommand_75pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "80") Then SerialPort1.Write(fan_controlRPMcommand_80pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "85") Then SerialPort1.Write(fan_controlRPMcommand_85pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "90") Then SerialPort1.Write(fan_controlRPMcommand_90pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "95") Then SerialPort1.Write(fan_controlRPMcommand_95pc, 0, 7)
                        If (ComboBox_FanSpeed.Text = "100") Then SerialPort1.Write(fan_controlRPMcommand_100pc, 0, 7)
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ' Because I'm lazy.
        Me.CheckForIllegalCrossThreadCalls = False
        Try
            Select Case grid_lastcommand
                Case 0
                    ' Process grid_initcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    If (serial_input(0) = &H1F) Then
                        Me.lbl_Status.Text = "Serial Port set as " + SerialPort1.PortName.ToString + " - OK"
                        PictureBox_Status.BackColor = Color.LimeGreen
                        grid_lastcommand = 1
                    End If
                Case 1
                    ' Process fan1_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN1RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 2
                    End If
                Case 2
                    ' Process fan2_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN2RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 3
                    End If
                Case 3
                    ' Process fan3_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN3RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 4
                    End If
                Case 4
                    ' Process fan4_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN4RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 5
                    End If
                Case 5
                    ' Process fan5_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN5RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 6
                    End If
                Case 6
                    ' Process fan6_pollRPMcommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        Me.lbl_FAN6RPM.Text = BitConverter.ToInt32(serial_input, 3).ToString + " rpm"
                        grid_lastcommand = 7
                    End If
                Case 7
                    ' Process fan_pollVOLTScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        ' Pad with 0 if value less than 10
                        If (serial_input(3) < 10) Then
                            total_voltage = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            total_voltage = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 8
                    End If
                Case 8
                    ' Process fan1_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan1_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan1_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 9
                    End If
                Case 9
                    ' Process fan2_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan2_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan2_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 10
                    End If
                Case 10
                    ' Process fan3_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan3_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan3_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 11
                    End If
                Case 11
                    ' Process fan4_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan4_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan4_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 12
                    End If
                Case 12
                    ' Process fan5_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan5_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan5_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        grid_lastcommand = 13
                    End If
                Case 13
                    ' Process fan6_pollAMPScommand
                    serial_input(0) = SerialPort1.ReadByte()
                    serial_input(1) = SerialPort1.ReadByte()
                    serial_input(2) = SerialPort1.ReadByte()
                    serial_input(4) = SerialPort1.ReadByte()
                    serial_input(3) = SerialPort1.ReadByte()
                    If (serial_input(0) = &HC0 And serial_input(1) = &H0 And serial_input(2) = &H0) Then
                        If (serial_input(3) < 10) Then
                            fan6_amps = serial_input(4).ToString + ".0" + serial_input(3).ToString
                        Else
                            fan6_amps = serial_input(4).ToString + "." + serial_input(3).ToString
                        End If
                        ' Calculate and display voltage, amperage and watts
                        Me.lbl_FAN1Wattage.Text = Math.Round((total_voltage * fan1_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan1_amps.ToString + "A)"
                        Me.lbl_FAN2Wattage.Text = Math.Round((total_voltage * fan2_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan2_amps.ToString + "A)"
                        Me.lbl_FAN3Wattage.Text = Math.Round((total_voltage * fan3_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan3_amps.ToString + "A)"
                        Me.lbl_FAN4Wattage.Text = Math.Round((total_voltage * fan4_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan4_amps.ToString + "A)"
                        Me.lbl_FAN5Wattage.Text = Math.Round((total_voltage * fan5_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan5_amps.ToString + "A)"
                        Me.lbl_FAN6Wattage.Text = Math.Round((total_voltage * fan6_amps), 2).ToString + "W (" + total_voltage.ToString + "V * " + fan6_amps.ToString + "A)"
                        If (speed_changed) Then
                            grid_lastcommand = 14
                        Else
                            grid_lastcommand = 1
                        End If
                    End If
                Case 14
                    ' Process fan_controlRPMcommand return value
                    serial_input(0) = SerialPort1.ReadByte()
                    If (serial_input(0) = &H1) Then
                        Me.lbl_Status.Text = "Fan speed configured at " + ComboBox_FanSpeed.Text + "%"
                        grid_lastcommand = 1
                    Else
                        Me.lbl_Status.Text = "Unable to configure fan speed at " + ComboBox_FanSpeed.Text + "%"
                        grid_lastcommand = 1
                    End If
                    speed_changed = False
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_FanSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_FanSpeed.SelectedIndexChanged, TargetTemp.SelectedIndexChanged
        ' Toggle speed change flag
        speed_changed = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        ' Exit app
        Me.Close()
    End Sub

    Private Sub ComboBox_PollingInt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_PollingInt.SelectedIndexChanged
        ' Set actual polling interval
        Timer1.Interval = ComboBox_PollingInt.Text
    End Sub

    Private Sub newFanName(fan As Integer)
        Dim newlabel As String
        Dim fanlabel As Control = getObjectFromString("lbl_FAN" + fan.ToString() + "Name")

        ' Set if not null
        newlabel = InputBox("Enter a new name for Fan #" + fan.ToString(), "betterGRID", "FAN " + fan.ToString())

        If newlabel = "" Then
            fanlabel.Text = "FAN " + fan.ToString()
        Else
            fanlabel.Text = newlabel
        End If
    End Sub

    Private Sub saveFanName(fan As Integer)
        Dim fanlabel As Control = getObjectFromString("lbl_FAN" + fan.ToString() + "Name")
        writeIni(ini, "fans", "fan" + fan.ToString(), fanlabel.Text)
    End Sub

    Private Sub readFanName(fan As Integer)
        Dim fanlabel As Control = getObjectFromString("lbl_FAN" + fan.ToString() + "Name")
        Dim newname As String = ReadIni(ini, "fans", "fan" + fan.ToString(), "")

        If newname = "" Then
            fanlabel.Text = "FAN " + fan.ToString()
        Else
            fanlabel.Text = newname
        End If
    End Sub

    Private Function getObjectFromString(theobjectstring As String) As Control
        Dim theobject As Control = Nothing
        Dim SearchedControls = Me.Controls.Find(key:=theobjectstring, searchAllChildren:=True)
        If SearchedControls.Count = 1 Then
            ' Set control
            theobject = SearchedControls(0)
        Else
            MsgBox("Internal error! " + SearchedControls.Length.ToString() + " objects found. Expected 1.", MsgBoxStyle.Critical)
        End If

        Return theobject
    End Function

    Private Sub lbl_FAN1Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN1Name.Click
        newFanName(1)
    End Sub

    Private Sub lbl_FAN2Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN2Name.Click
        newFanName(2)
    End Sub

    Private Sub lbl_FAN3Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN3Name.Click
        newFanName(3)
    End Sub

    Private Sub lbl_FAN4Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN4Name.Click
        newFanName(4)
    End Sub

    Private Sub lbl_FAN5Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN5Name.Click
        newFanName(5)
    End Sub

    Private Sub lbl_FAN6Name_Click(sender As Object, e As EventArgs) Handles lbl_FAN6Name.Click
        newFanName(6)
    End Sub

    Private Sub Button2_Click(ByVal sneder As System.Object, ByVal e As System.EventArgs)
        'test
    End Sub

    Private Function GetHWInfo(hwtype As HardwareType, info As String, Optional getmax As Boolean = False) As String
        Try
            Dim component As Integer = GetHardwareNumber(hwtype)
            cp.Hardware(component).Update() ' Update component

            ' Loop through sub-hardware
            If cp.Hardware(GetHardwareNumber(hwtype)).SubHardware.Length > 0 Then
                For l As Integer = 0 To cp.Hardware(component).SubHardware.Length - 1
                    ' Update the sub hardware
                    cp.Hardware(component).SubHardware(l).Update()
                    ' Loop through sub hardware sensors
                    For x As Integer = 0 To cp.Hardware(component).SubHardware(l).Sensors.Length - 1
                        If cp.Hardware(component).SubHardware(l).Sensors(x).SensorType.ToString.Trim.ToLower.Contains(info.Trim.ToLower) Then
                            If getmax Then
                                Return cp.Hardware(component).SubHardware(l).Sensors(x).Max.ToString
                            Else
                                Return cp.Hardware(component).SubHardware(l).Sensors(x).Value.ToString
                            End If
                        End If
                    Next
                Next
            End If

            ' Loop through main sensors
            For i As Integer = 0 To cp.Hardware(component).Sensors.Count() - 1
                If cp.Hardware(component).Sensors(i).SensorType.ToString.Trim.ToLower.Contains(info.Trim.ToLower) Then
                    If getmax Then
                        Return cp.Hardware(component).Sensors(i).Max.ToString
                    Else
                        Return cp.Hardware(component).Sensors(i).Value.ToString
                    End If
                End If
            Next
        Catch
        End Try

        Return "UKN"
    End Function

    Private Function GetHardwareNumber(ByVal hardware As HardwareType) As Integer
        For i As Integer = 0 To cp.Hardware.Count() - 1
            If cp.Hardware(i).HardwareType = hardware Then
                Return i
            End If
        Next
        Throw New Exception
    End Function

    Private Sub AutoControlCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoControlCombo.SelectedIndexChanged

        If AutoControlCombo.SelectedIndex = 0 Then ' Manual control
            ComboBox_FanSpeed.Enabled = True
            TargetTemp.Enabled = False
            TempRate.Enabled = False
        Else
            ComboBox_FanSpeed.Enabled = False
            TargetTemp.Enabled = True
            TempRate.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim theform As AboutBox1 = New AboutBox1()
        theform.Show()
    End Sub
End Class