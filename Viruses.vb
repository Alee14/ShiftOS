﻿Module Viruses
    'Zero Varibles
    Public WithEvents zerogravitytimer As New Timer
    Public zerogravity As Boolean = True
    Public zerogravitythreatlevel As Integer = 1
    Public zerogravityxspeed(20) As Integer
    Public zerogravityyspeed(20) As Integer
    Public zerogravityspeedth1 = 1
    Public zerogravityspeedth2 = 2
    Public zerogravityspeedth3 = 4
    Public zerogravityspeedth4 = 8


    'Mouse Trap Varibles
    Public WithEvents mousetraptimer As New Timer
    Public WithEvents cooldowntraptimer As New Timer
    Public mousetrap As Boolean = True
    Public mousetrapthreatlevel As Integer = 1
    Public mousetraped As Boolean = False
    Public bangstoescape As Integer = 20
    Public trappedwindow As Integer = 0
    Public bangvelocity As Integer
    Public bangforceneeded As Integer = 30
    Public trapcooldown As Integer = 20
    Public trap1 As Boolean = False
    Public trap2 As Boolean = False
    Public trap3 As Boolean = False
    Public trap4 As Boolean = False
    Public alreadytrapped As Boolean = False
    Public trappedprogram As Form
    Public bangstoescapeth1 As Integer = 20
    Public bangstoescapeth2 As Integer = 40
    Public bangstoescapeth3 As Integer = 60
    Public bangstoescapeth4 As Integer = 80
    Public bangforceneeded1 As Integer = 30
    Public bangforceneeded2 As Integer = 50
    Public bangforceneeded3 As Integer = 80
    Public bangforceneeded4 As Integer = 120
    Public trapcooldown1 As Integer = 60
    Public trapcooldown2 As Integer = 30
    Public trapcooldown3 As Integer = 15
    Public trapcooldown4 As Integer = 10

    'Beeper Varibles
    Public WithEvents beepertimer As New Timer
    Public beeper As Boolean = True
    Public beeperthreatlevel As Integer = 1
    Public beepercountdown As Integer
    Dim ResourceFilePath As String
    Dim soundplayer As AxWMPLib.AxWindowsMediaPlayer
    Dim beeperinterval As Integer = 5

    'Zero Virus
    Public Sub setupzerovirus()
        setupzerogravityspeeds()
        zerogravitytimer.Start()
        zerogravitytimer.Interval = 20
    End Sub

    Public Sub setupzerogravityspeeds()
        For i = 0 To 20
            If i Mod 2 <> 0 Then
                Select Case zerogravitythreatlevel
                    Case 1
                        zerogravityxspeed(i) = zerogravityspeedth1
                        zerogravityyspeed(i) = zerogravityspeedth1
                    Case 2
                        zerogravityxspeed(i) = zerogravityspeedth2
                        zerogravityyspeed(i) = zerogravityspeedth2
                    Case 3
                        zerogravityxspeed(i) = zerogravityspeedth3
                        zerogravityyspeed(i) = zerogravityspeedth3
                    Case 4
                        zerogravityxspeed(i) = zerogravityspeedth4
                        zerogravityyspeed(i) = zerogravityspeedth4
                End Select

            Else
                Select Case zerogravitythreatlevel
                    Case 1
                        zerogravityxspeed(i) = -zerogravityspeedth1
                        zerogravityyspeed(i) = -zerogravityspeedth1
                    Case 2
                        zerogravityxspeed(i) = -zerogravityspeedth2
                        zerogravityyspeed(i) = -zerogravityspeedth2
                    Case 3
                        zerogravityxspeed(i) = -zerogravityspeedth3
                        zerogravityyspeed(i) = -zerogravityspeedth3
                    Case 4
                        zerogravityxspeed(i) = -zerogravityspeedth4
                        zerogravityyspeed(i) = -zerogravityspeedth4
                End Select
            End If
        Next
    End Sub

    Public Sub floatingwindows() Handles zerogravitytimer.Tick
        If Knowledge_Input.Visible = True Then calculatelocations(Knowledge_Input, 0)
        If Shiftorium.Visible = True Then calculatelocations(Shiftorium, 1)
        If Clock.Visible = True Then calculatelocations(Clock, 2)
        If Shifter.Visible = True Then calculatelocations(Shifter, 3)
        If Colour_Picker.Visible = True Then calculatelocations(Colour_Picker, 4)
        If infobox.Visible = True Then calculatelocations(infobox, 5)
        If Pong.Visible = True Then calculatelocations(Pong, 6)
        If File_Skimmer.Visible = True Then calculatelocations(File_Skimmer, 7)
        If File_Opener.Visible = True Then calculatelocations(File_Opener, 8)
        If File_Saver.Visible = True Then calculatelocations(File_Saver, 9)
        If TextPad.Visible = True Then calculatelocations(TextPad, 10)
        If Graphic_Picker.Visible = True Then calculatelocations(Graphic_Picker, 11)
        If Skin_Loader.Visible = True Then calculatelocations(Skin_Loader, 12)
        If ArtPad.Visible = True Then calculatelocations(ArtPad, 13)
        If Calculator.Visible = True Then calculatelocations(Calculator, 14)
        If Audio_Player.Visible = True Then calculatelocations(Audio_Player, 15)
        If Web_Browser.Visible = True Then calculatelocations(Web_Browser, 16)
        If Video_Player.Visible = True Then calculatelocations(Video_Player, 17)
        If Name_Changer.Visible = True Then calculatelocations(Name_Changer, 18)
        If Icon_Manager.Visible = True Then calculatelocations(Icon_Manager, 19)
        If Terminal.Visible = True Then calculatelocations(Terminal, 20)
    End Sub

    Public Sub calculatelocations(ByVal program As Form, ByVal number As Integer)
        If zerogravityxspeed(number) > 0 Then
            If (program.Location.X + program.Size.Width) > Screen.PrimaryScreen.Bounds.Width Then
                zerogravityxspeed(number) = zerogravityxspeed(number) * -1
            End If
        End If
        If zerogravityxspeed(number) < 0 Then
            If program.Location.X < 0 Then
                zerogravityxspeed(number) = zerogravityxspeed(number) * -1
            End If
        End If
        If zerogravityyspeed(number) > 0 Then
            If (program.Location.Y + program.Size.Height) > Screen.PrimaryScreen.Bounds.Height Then
                zerogravityyspeed(number) = zerogravityyspeed(number) * -1
            End If
        End If
        If zerogravityyspeed(number) < 0 Then
            If program.Location.Y < 0 Then
                zerogravityyspeed(number) = zerogravityyspeed(number) * -1
            End If
        End If
        program.Location = New Point(program.Location.X + zerogravityxspeed(number), program.Location.Y + zerogravityyspeed(number))
    End Sub

    Public Sub removezerovirus()
        zerogravitytimer.Stop()
        Viruses.zerogravity = False
    End Sub

    'Mouse Trap Virus
    Public Sub setupmousetrapvirus()
        mousetraptimer.Start()
        mousetraptimer.Interval = 20
        cooldowntraptimer.Start()
        cooldowntraptimer.Interval = 1000
        Select Case mousetrapthreatlevel
            Case 1
                trapcooldown = trapcooldown1
                bangforceneeded = bangforceneeded1
                bangstoescape = bangstoescapeth1
            Case 2
                trapcooldown = trapcooldown2
                bangforceneeded = bangforceneeded2
                bangstoescape = bangstoescapeth2
            Case 3
                trapcooldown = trapcooldown3
                bangforceneeded = bangforceneeded3
                bangstoescape = bangstoescapeth3
            Case 4
                trapcooldown = trapcooldown4
                bangforceneeded = bangforceneeded4
                bangstoescape = bangstoescapeth4
        End Select

    End Sub

    Public Sub seeifcantrap(ByVal sender As Object, ByVal e As EventArgs) Handles cooldowntraptimer.Tick
        If trapcooldown < 0 Then
            mousetraped = True
        Else
            trapcooldown = trapcooldown - 1
        End If
    End Sub

    Public Sub trapmouse(ByVal sender As Object, ByVal e As EventArgs) Handles mousetraptimer.Tick
        If mousetraped = True Then
            If alreadytrapped = False Then detectprogramtotrap(Knowledge_Input)
            If alreadytrapped = False Then detectprogramtotrap(Shiftorium)
            If alreadytrapped = False Then detectprogramtotrap(Clock)
            If alreadytrapped = False Then detectprogramtotrap(Shifter)
            If alreadytrapped = False Then detectprogramtotrap(Colour_Picker)
            If alreadytrapped = False Then detectprogramtotrap(infobox)
            If alreadytrapped = False Then detectprogramtotrap(Pong)
            If alreadytrapped = False Then detectprogramtotrap(File_Skimmer)
            If alreadytrapped = False Then detectprogramtotrap(File_Opener)
            If alreadytrapped = False Then detectprogramtotrap(File_Saver)
            If alreadytrapped = False Then detectprogramtotrap(TextPad)
            If alreadytrapped = False Then detectprogramtotrap(Graphic_Picker)
            If alreadytrapped = False Then detectprogramtotrap(Skin_Loader)
            If alreadytrapped = False Then detectprogramtotrap(ArtPad)
            If alreadytrapped = False Then detectprogramtotrap(Calculator)
            If alreadytrapped = False Then detectprogramtotrap(Audio_Player)
            If alreadytrapped = False Then detectprogramtotrap(Web_Browser)
            If alreadytrapped = False Then detectprogramtotrap(Video_Player)
            If alreadytrapped = False Then detectprogramtotrap(Name_Changer)
            If alreadytrapped = False Then detectprogramtotrap(Icon_Manager)
            If alreadytrapped = False Then detectprogramtotrap(Terminal)

            If trappedprogram Is Nothing Then  Else trapmouseinprogram(trappedprogram)
            If bangstoescape < 0 Then
                mousetraped = False
                Select Case mousetrapthreatlevel
                    Case 1
                        trapcooldown = trapcooldown1
                        bangstoescape = bangstoescapeth1
                    Case 2
                        trapcooldown = trapcooldown2
                        bangstoescape = bangstoescapeth2
                    Case 3
                        trapcooldown = trapcooldown3
                        bangstoescape = bangstoescapeth3
                    Case 4
                        trapcooldown = trapcooldown4
                        bangstoescape = bangstoescapeth4
                End Select
                alreadytrapped = False
                trappedprogram = Nothing
            End If
        End If
    End Sub

    Private Sub detectprogramtotrap(ByVal program As Form)
        If program.Visible = True Then
            If Cursor.Position.X < program.Location.X + program.Width - ShiftOSDesktop.windowbordersize Then
                trap1 = True
            End If
            If Cursor.Position.X > program.Location.X + ShiftOSDesktop.windowbordersize Then
                trap2 = True
            End If
            If Cursor.Position.Y > program.Location.Y + ShiftOSDesktop.titlebarheight Then
                trap3 = True
            End If
            If Cursor.Position.Y < program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize Then
                trap4 = True
            End If
            If trap1 = True AndAlso trap2 = True AndAlso trap3 = True AndAlso trap4 = True Then
                alreadytrapped = True
                trappedprogram = program
            End If
        End If
        trap1 = False
        trap2 = False
        trap3 = False
        trap4 = False
    End Sub

    Public Sub trapmouseinprogram(ByVal program As Form)
        If Cursor.Position.X > program.Location.X + program.Width - ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.X - (program.Location.X + program.Width - ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(program.Location.X + program.Width - ShiftOSDesktop.windowbordersize, Cursor.Position.Y)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.X < program.Location.X + ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.X - (program.Location.X + ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(program.Location.X + ShiftOSDesktop.windowbordersize, Cursor.Position.Y)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.Y < program.Location.Y + ShiftOSDesktop.titlebarheight Then
            bangvelocity = Math.Abs(Cursor.Position.Y - (program.Location.Y + ShiftOSDesktop.titlebarheight))
            Cursor.Position = New Point(Cursor.Position.X, program.Location.Y + ShiftOSDesktop.titlebarheight)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
        If Cursor.Position.Y > program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize Then
            bangvelocity = Math.Abs(Cursor.Position.Y - (program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize))
            Cursor.Position = New Point(Cursor.Position.X, program.Location.Y + program.Height - ShiftOSDesktop.windowbordersize)
            If bangvelocity > bangforceneeded Then bangstoescape = bangstoescape - 1
        End If
    End Sub

    Public Sub removemousetrapvirus()
        Viruses.mousetrap = False
        mousetraptimer.Stop()
        mousetraped = False
        cooldowntraptimer.Stop()
    End Sub

    'Beeper Virus
    Public Sub setupbeepervirus()
        setupbeeperintervals()
        'If System.Diagnostics.Debugger.IsAttached() Then
        '    ResourceFilePath = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        'Else
        '    ResourceFilePath = Application.StartupPath & "\resources\"
        'End If
        beepertimer.Start()
        beepertimer.Interval = 500
        beepercountdown = beeperinterval
    End Sub

    Private Sub setupbeeperintervals()
        Select Case beeperthreatlevel
            Case 1 : beeperinterval = 60
            Case 2 : beeperinterval = 24
            Case 3 : beeperinterval = 8
            Case 4 : beeperinterval = 1
        End Select
    End Sub

    Public Sub beepermakesound(ByVal sender As Object, ByVal e As EventArgs) Handles beepertimer.Tick
        If beepercountdown = 0 Then
            My.Computer.Audio.Play(My.Resources._3beepvirus, AudioPlayMode.Background)
            beepercountdown = beeperinterval
        Else
            beepercountdown = beepercountdown - 1
        End If
    End Sub

    Public Sub removebeepervirus()
        Viruses.beeper = False
        beepertimer.Stop()
    End Sub
End Module
