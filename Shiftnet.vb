﻿Public Class Shiftnet
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 820   'replace with minimum size
    Public minimumsizeheight As Integer = 600  'replace with minimum size

    Public loadsitenow As Boolean = False

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()

        ShiftOSDesktop.pnlpanelbuttonshiftnet.SendToBack() 'modfiy to proper name
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshiftnet, ShiftOSDesktop.tbshiftneticon, ShiftOSDesktop.tbshiftnettext, True) 'modify to proper name
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Make terminal appear
        If e.KeyCode = Keys.T AndAlso e.Control Then
            Terminal.Show()
            Terminal.Visible = True
            Terminal.BringToFront()
        End If

        'Movable Windows
        If ShiftOSDesktop.boughtmovablewindows = True Then
            If e.KeyCode = Keys.A AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X - ShiftOSDesktop.movablewindownumber, Me.Location.Y)
            End If
            If e.KeyCode = Keys.D AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X + ShiftOSDesktop.movablewindownumber, Me.Location.Y)
            End If
            If e.KeyCode = Keys.W AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y - ShiftOSDesktop.movablewindownumber)
            End If
            If e.KeyCode = Keys.S AndAlso e.Control Then
                e.Handled = True
                Me.Location = New Point(Me.Location.X, Me.Location.Y + ShiftOSDesktop.movablewindownumber)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User moved " & Me.Name & " to " & Me.Location.ToString & " with " & e.KeyCode.ToString & Environment.NewLine
        End If
    End Sub

    Private Sub titlebar_MouseDown(sender As Object, e As MouseEventArgs) Handles titlebar.MouseDown, lbtitletext.MouseDown, pnlicon.MouseDown, pgtoplcorner.MouseDown, pgtoprcorner.MouseDown
        ' Handle Draggable Windows
        If ShiftOSDesktop.boughtdraggablewindows = True Then
            If e.Button = MouseButtons.Left Then
                titlebar.Capture = False
                lbtitletext.Capture = False
                pnlicon.Capture = False
                pgtoplcorner.Capture = False
                pgtoprcorner.Capture = False
                Const WM_NCLBUTTONDOWN As Integer = &HA1S
                Const HTCAPTION As Integer = 2
                Dim msg As Message = _
                    Message.Create(Me.Handle, WM_NCLBUTTONDOWN, _
                        New IntPtr(HTCAPTION), IntPtr.Zero)
                Me.DefWndProc(msg)
            End If
            ShiftOSDesktop.log = ShiftOSDesktop.log & My.Computer.Clock.LocalTime & " User dragged " & Me.Name & " to " & Me.Location.ToString & Environment.NewLine
        End If
    End Sub

    Public Sub setupborders()
        If ShiftOSDesktop.boughtwindowborders = False Then
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            Me.Size = New Size(Me.Width - pgleft.Width - pgright.Width, Me.Height - pgbottom.Height)
        End If
    End Sub

    Private Sub closebutton_Click(sender As Object, e As EventArgs) Handles closebutton.Click
        Me.Close()
    End Sub

    Private Sub closebutton_MouseEnter(sender As Object, e As EventArgs) Handles closebutton.MouseEnter, closebutton.MouseUp
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(1)
    End Sub

    Private Sub closebutton_MouseLeave(sender As Object, e As EventArgs) Handles closebutton.MouseLeave
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0)
    End Sub

    Private Sub closebutton_MouseDown(sender As Object, e As EventArgs) Handles closebutton.MouseDown
        closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(2)
    End Sub

    Private Sub minimizebutton_Click(sender As Object, e As EventArgs) Handles minimizebutton.Click
        ShiftOSDesktop.minimizeprogram(Me)
    End Sub

    Private Sub titlebar_MouseEnter(sender As Object, e As EventArgs) Handles titlebar.MouseEnter, titlebar.MouseUp, lbtitletext.MouseEnter, pnlicon.MouseEnter, closebutton.MouseEnter, rollupbutton.MouseEnter
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(1)
    End Sub

    Private Sub titlebar_MouseLeave(sender As Object, e As EventArgs) Handles titlebar.MouseLeave, lbtitletext.MouseLeave, pnlicon.MouseLeave, closebutton.MouseLeave, rollupbutton.MouseLeave
        If ShiftOSDesktop.skinimages(3) = ShiftOSDesktop.skinimages(4) Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0)
    End Sub

    Private Sub rollupbutton_Click(sender As Object, e As EventArgs) Handles rollupbutton.Click
        rollupanddown()
    End Sub

    Private Sub rollupbutton_MouseEnter(sender As Object, e As EventArgs) Handles rollupbutton.MouseEnter, rollupbutton.MouseUp
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(1)
    End Sub

    Private Sub rollupbutton_MouseLeave(sender As Object, e As EventArgs) Handles rollupbutton.MouseLeave
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0)
    End Sub

    Private Sub rollupbutton_MouseDown(sender As Object, e As EventArgs) Handles rollupbutton.MouseDown
        rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(2)
    End Sub

    Public Sub setuptitlebar()

        If Me.Height = Me.titlebar.Height Then pgleft.Show() : pgbottom.Show() : pgright.Show() : Me.Height = rolldownsize : needtorollback = True
        pgleft.Width = ShiftOSDesktop.windowbordersize
        pgright.Width = ShiftOSDesktop.windowbordersize
        pgbottom.Height = ShiftOSDesktop.windowbordersize
        titlebar.Height = ShiftOSDesktop.titlebarheight

        If justopened = True Then
            Me.Size = New Size(820, 600) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
            Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
            oldbordersize = ShiftOSDesktop.windowbordersize
            oldtitlebarheight = ShiftOSDesktop.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                Me.Hide()
                Me.Size = New Size(Me.Width, Me.Height - oldtitlebarheight + 30)
                Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize)
                oldbordersize = ShiftOSDesktop.windowbordersize
                oldtitlebarheight = ShiftOSDesktop.titlebarheight
                Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
                Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
                rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                Me.Show()
            End If
        End If

        If ShiftOSDesktop.showwindowcorners = True Then
            pgtoplcorner.Show()
            pgtoprcorner.Show()
            pgtoprcorner.Width = ShiftOSDesktop.titlebarcornerwidth
            pgtoplcorner.Width = ShiftOSDesktop.titlebarcornerwidth
        Else
            pgtoplcorner.Hide()
            pgtoprcorner.Hide()
        End If

        If ShiftOSDesktop.boughttitlebar = False Then
            titlebar.Hide()
            Me.Size = New Size(Me.Width, Me.Size.Height - titlebar.Height)
        End If

        If ShiftOSDesktop.boughttitletext = False Then
            lbtitletext.Hide()
        Else
            lbtitletext.Font = New Font(ShiftOSDesktop.titletextfont, ShiftOSDesktop.titletextsize, ShiftOSDesktop.titletextstyle)
            lbtitletext.Text = ShiftOSDesktop.shiftnetname 'Remember to change to name of program!!!!
            lbtitletext.Show()
        End If

        If ShiftOSDesktop.boughtclosebutton = False Then
            closebutton.Hide()
        Else
            closebutton.BackColor = ShiftOSDesktop.closebuttoncolour
            closebutton.Height = ShiftOSDesktop.closebuttonheight
            closebutton.Width = ShiftOSDesktop.closebuttonwidth
            closebutton.Show()
        End If

        If ShiftOSDesktop.boughtrollupbutton = False Then
            rollupbutton.Hide()
        Else
            rollupbutton.BackColor = ShiftOSDesktop.rollupbuttoncolour
            rollupbutton.Height = ShiftOSDesktop.rollupbuttonheight
            rollupbutton.Width = ShiftOSDesktop.rollupbuttonwidth
            rollupbutton.Show()
        End If

        If ShiftOSDesktop.boughtminimizebutton = False Then
            minimizebutton.Hide()
        Else
            minimizebutton.BackColor = ShiftOSDesktop.minimizebuttoncolour
            minimizebutton.Height = ShiftOSDesktop.minimizebuttonheight
            minimizebutton.Width = ShiftOSDesktop.minimizebuttonwidth
            minimizebutton.Show()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside + pgtoplcorner.Width, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        End If

        If ShiftOSDesktop.boughtknowledgeinputicon = True Then
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.shiftneticontitlebar  'Replace with the correct icon for the program.
        End If

    End Sub

    Public Sub rollupanddown()
        If Me.Height = Me.titlebar.Height Then
            pgleft.Show()
            pgbottom.Show()
            pgright.Show()
            Me.Height = rolldownsize
            Me.MinimumSize = New Size(minimumsizewidth, minimumsizeheight)
        Else
            Me.MinimumSize = New Size(0, 0)
            pgleft.Hide()
            pgbottom.Hide()
            pgright.Hide()
            rolldownsize = Me.Height
            Me.Height = Me.titlebar.Height
        End If
    End Sub

    Public Sub resettitlebar()
        If ShiftOSDesktop.boughtwindowborders = True Then
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        Else
            closebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.closebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - closebutton.Size.Width, ShiftOSDesktop.closebuttontop)
            rollupbutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.rollupbuttonside - pgtoplcorner.Width - pgtoprcorner.Width - rollupbutton.Size.Width, ShiftOSDesktop.rollupbuttontop)
            minimizebutton.Location = New Point(titlebar.Size.Width - ShiftOSDesktop.minimizebuttonside - pgtoplcorner.Width - pgtoprcorner.Width - minimizebutton.Size.Width, ShiftOSDesktop.minimizebuttontop)
            Select Case ShiftOSDesktop.titletextposition
                Case "Left"
                    lbtitletext.Location = New Point(ShiftOSDesktop.titletextside + pgtoplcorner.Width, ShiftOSDesktop.titletexttop)
                Case "Centre"
                    lbtitletext.Location = New Point((titlebar.Width / 2) - lbtitletext.Width / 2, ShiftOSDesktop.titletexttop)
            End Select
            lbtitletext.ForeColor = ShiftOSDesktop.titletextcolour
        End If
    End Sub

    Private Sub pullside_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullside.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        resettitlebar()
    End Sub

    Private Sub pullbottom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pullbottom.Tick
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub pullbs_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pullbs.Tick
        Me.Width = Cursor.Position.X - Me.Location.X
        Me.Height = Cursor.Position.Y - Me.Location.Y
        resettitlebar()
    End Sub

    Private Sub Rightpull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Start()
        End If
    End Sub

    Private Sub RightCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeWE
        End If
    End Sub

    Private Sub bottomCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottom.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNS
        End If
    End Sub

    Private Sub CornerCursorOn_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgbottomrcorner.MouseEnter
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.SizeNWSE
        End If
    End Sub

    Private Sub SizeCursoroff_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles pgright.MouseLeave, pgbottom.MouseLeave, pgbottomrcorner.MouseLeave
        If ShiftOSDesktop.boughtresizablewindows = True Then
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub rightpull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgright.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullside.Stop()
        End If
    End Sub

    Private Sub bottompull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Start()
        End If
    End Sub

    Private Sub buttompull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottom.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbottom.Stop()
        End If
    End Sub

    Private Sub bspull_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseDown
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Start()
        End If
    End Sub

    Private Sub bspull_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pgbottomrcorner.MouseUp
        If ShiftOSDesktop.boughtresizablewindows = True Then
            pullbs.Stop()
        End If
    End Sub

    Public Sub setskin()
        If ShiftOSDesktop.skinclosebutton(0) Is Nothing Then  Else closebutton.BackgroundImage = ShiftOSDesktop.skinclosebutton(0).Clone
        closebutton.BackgroundImageLayout = ShiftOSDesktop.skinclosebuttonstyle
        If ShiftOSDesktop.skintitlebar(0) Is Nothing Then  Else titlebar.BackgroundImage = ShiftOSDesktop.skintitlebar(0).Clone
        titlebar.BackgroundImageLayout = ShiftOSDesktop.skintitlebarstyle
        If ShiftOSDesktop.skinrollupbutton(0) Is Nothing Then  Else rollupbutton.BackgroundImage = ShiftOSDesktop.skinrollupbutton(0).Clone
        rollupbutton.BackgroundImageLayout = ShiftOSDesktop.skinrollupbuttonstyle
        If ShiftOSDesktop.skintitlebarleftcorner(0) Is Nothing Then  Else pgtoplcorner.BackgroundImage = ShiftOSDesktop.skintitlebarleftcorner(0).Clone
        pgtoplcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarleftcornerstyle
        If ShiftOSDesktop.skintitlebarrightcorner(0) Is Nothing Then  Else pgtoprcorner.BackgroundImage = ShiftOSDesktop.skintitlebarrightcorner(0).Clone
        pgtoprcorner.BackgroundImageLayout = ShiftOSDesktop.skintitlebarrightcornerstyle
        If ShiftOSDesktop.skinminimizebutton(0) Is Nothing Then  Else minimizebutton.BackgroundImage = ShiftOSDesktop.skinminimizebutton(0).Clone
        minimizebutton.BackgroundImageLayout = ShiftOSDesktop.skinminimizebuttonstyle

        'remove background colour when image is present
        If closebutton.BackgroundImage Is Nothing Then  Else closebutton.BackColor = Color.Transparent
        If titlebar.BackgroundImage Is Nothing Then  Else titlebar.BackColor = Color.Transparent
        If rollupbutton.BackgroundImage Is Nothing Then  Else rollupbutton.BackColor = Color.Transparent
        If pgtoplcorner.BackgroundImage Is Nothing Then  Else pgtoplcorner.BackColor = Color.Transparent
        If pgtoprcorner.BackgroundImage Is Nothing Then  Else pgtoprcorner.BackColor = Color.Transparent
        If minimizebutton.BackgroundImage Is Nothing Then  Else minimizebutton.BackColor = Color.Transparent

        Me.TransparencyKey = ShiftOSDesktop.globaltransparencycolour
    End Sub

    Private Sub Clock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen - 1
        Me.Hide()
        ShiftOSDesktop.setuppanelbuttons()
    End Sub

    'end of general setup

    Private Sub txtlocation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtlocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadsitenow = True
        End If
    End Sub

    Private Sub hideallsites()
        pnlmainsiteappscape.Hide()
        appscapehomepage.Hide()
        appscapeaudioplayerinfopage.Hide()
    End Sub

    Private Sub opensite(ByVal mainsite As Panel, ByVal page As Panel, ByVal site As String)
        hideallsites()
        mainsite.Show()
        mainsite.BringToFront()
        mainsite.Dock = DockStyle.Fill
        page.Show()
        page.BringToFront()
        page.Dock = DockStyle.Fill
        txtlocation.Clear()
        txtlocation.Text = site
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        hideallsites()
        txtlocation.Text = ""
    End Sub

    Private Sub tmrloadsite_Tick(sender As Object, e As EventArgs) Handles tmrloadsite.Tick
        If loadsitenow = True Then
            txtlocation.Text = Replace$(txtlocation.Text, vbCrLf, "")
            Select Case txtlocation.Text
                Case "shiftnet.main.appscape/home.rnp"
                    opensite(pnlmainsiteappscape, appscapehomepage, "shiftnet.main.appscape/home.rnp")
                    setupappscapeaccountinfo()
                Case "shiftnet.main.appscape/audioplayerinfo.rnp"
                    opensite(pnlmainsiteappscape, appscapeaudioplayerinfopage, "shiftnet.main.appscape/audioplayerinfo.rnp")
                Case "shiftnet.main.appscape/videoplayerinfo.rnp"
                    opensite(pnlmainsiteappscape, appscapevideoplayerinfopage, "shiftnet.main.appscape/videoplayerinfo.rnp")
                Case "shiftnet.main.appscape/calculatorinfo.rnp"
                    opensite(pnlmainsiteappscape, appscapecalculatorinfopage, "shiftnet.main.appscape/calculatorinfo.rnp")
                Case "shiftnet.main.appscape/webbrowserinfo.rnp"
                    opensite(pnlmainsiteappscape, appscapewebbrowserinfopage, "shiftnet.main.appscape/webbrowserinfo.rnp")
            End Select
            loadsitenow = False
            btnhome.Focus()
        End If
    End Sub

    'Appscape Website functions

    Public Sub setupappscapeaccountinfo()
        lbappscapehello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
        lbappscapeaudioplayerinfohello.Text = "Hello " & ShiftOSDesktop.username & " - Your Account Contains " & FormatNumber(Math.Round(ShiftOSDesktop.bitnotebalanceappscape, 5), 5) & " BTN"
    End Sub

    Private Sub btnaudioplayerinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.MouseEnter
        btnaudioplayerinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnaudioplayerinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.MouseLeave
        btnaudioplayerinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnvideolayerinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.MouseEnter
        btnvideoplayerinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnvideoplayerinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.MouseLeave
        btnvideoplayerinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnwebbrowserinfo_MouseEnter(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.MouseEnter
        btnwebbrowserinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnwebbrowserinfo_MouseLeave(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.MouseLeave
        btnwebbrowserinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btncalculatorinfo_MouseEnter(sender As Object, e As EventArgs) Handles btncalculatorinfo.MouseEnter
        btncalculatorinfo.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btncalculatorinfo_MouseLeave(sender As Object, e As EventArgs) Handles btncalculatorinfo.MouseLeave
        btncalculatorinfo.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnmoresoftware1info_MouseEnter(sender As Object, e As EventArgs) Handles btnmoresoftware1info.MouseEnter
        btnmoresoftware1info.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnmoresoftware1info_MouseLeave(sender As Object, e As EventArgs) Handles btnmoresoftware1info.MouseLeave
        btnmoresoftware1info.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnmoresoftware2info_MouseEnter(sender As Object, e As EventArgs) Handles btnmoresoftware2info.MouseEnter
        btnmoresoftware2info.BackgroundImage = My.Resources.appscapeinfobuttonpressed
    End Sub

    Private Sub btnmoresoftware2info_MouseLeave(sender As Object, e As EventArgs) Handles btnmoresoftware2info.MouseLeave
        btnmoresoftware2info.BackgroundImage = My.Resources.appscapeinfobutton
    End Sub

    Private Sub btnbuyaudioplayer_MouseEnter(sender As Object, e As EventArgs) Handles btnbuyaudioplayer.MouseEnter
        btnbuyaudioplayer.BackgroundImage = My.Resources.appscapeaudioplayerpricepressed
    End Sub

    Private Sub btnbuyaudioplayer_MouseLeave(sender As Object, e As EventArgs) Handles btnbuyaudioplayer.MouseLeave
        btnbuyaudioplayer.BackgroundImage = My.Resources.appscapeaudioplayerprice
    End Sub

    Private Sub btnbuyvideoplayer_MouseEnter(sender As Object, e As EventArgs) Handles btnbuyvideoplayer.MouseEnter
        btnbuyvideoplayer.BackgroundImage = My.Resources.appscapevideoplayerpricepressed
    End Sub

    Private Sub btnbuyvideoplayer_MouseLeave(sender As Object, e As EventArgs) Handles btnbuyvideoplayer.MouseLeave
        btnbuyvideoplayer.BackgroundImage = My.Resources.appscapevideoplayerprice
    End Sub

    Private Sub btnbuywebbrowser_MouseEnter(sender As Object, e As EventArgs) Handles btnbuywebbrowser.MouseEnter
        btnbuywebbrowser.BackgroundImage = My.Resources.appscapewebbrowserpricepressed
    End Sub

    Private Sub btnbuywebbrowser_MouseLeave(sender As Object, e As EventArgs) Handles btnbuywebbrowser.MouseLeave
        btnbuywebbrowser.BackgroundImage = My.Resources.appscapewebbrowserprice
    End Sub

    Private Sub btnbuycalculator_MouseEnter(sender As Object, e As EventArgs) Handles btnbuycalculator.MouseEnter
        btnbuycalculator.BackgroundImage = My.Resources.appscapecalculatorpricepressed
    End Sub

    Private Sub btnbuycalculator_MouseLeave(sender As Object, e As EventArgs) Handles btnbuycalculator.MouseLeave
        btnbuycalculator.BackgroundImage = My.Resources.appscapecalculatorprice
    End Sub

    Private Sub btnbuymoresoftware1_MouseEnter(sender As Object, e As EventArgs) Handles btnbuymoresoftware1.MouseEnter
        btnbuymoresoftware1.BackgroundImage = My.Resources.appscapeundefinedpricepressed
    End Sub

    Private Sub btnbuymoresoftware1_MouseLeave(sender As Object, e As EventArgs) Handles btnbuymoresoftware1.MouseLeave
        btnbuymoresoftware1.BackgroundImage = My.Resources.appscapeundefinedprice
    End Sub

    Private Sub btnbuymoresoftware2_MouseEnter(sender As Object, e As EventArgs) Handles btnbuymoresoftware2.MouseEnter
        btnbuymoresoftware2.BackgroundImage = My.Resources.appscapeundefinedpricepressed
    End Sub

    Private Sub btnbuymoresoftware2_MouseLeave(sender As Object, e As EventArgs) Handles btnbuymoresoftware2.MouseLeave
        btnbuymoresoftware2.BackgroundImage = My.Resources.appscapeundefinedprice
    End Sub

    Private Sub btnaudioplayerinfoback_Click(sender As Object, e As EventArgs) Handles btnaudioplayerinfoback.Click
        opensite(pnlmainsiteappscape, appscapehomepage, "shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnaudioplayerinfo_Click(sender As Object, e As EventArgs) Handles btnaudioplayerinfo.Click
        opensite(pnlmainsiteappscape, appscapeaudioplayerinfopage, "shiftnet.main.appscape/audioplayerinfo.rnp")
    End Sub

    Private Sub btnvideoplayerinfoback_Click(sender As Object, e As EventArgs) Handles btnvideoplayerinfoback.Click
        opensite(pnlmainsiteappscape, appscapehomepage, "shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnvideoplayerinfo_Click(sender As Object, e As EventArgs) Handles btnvideoplayerinfo.Click
        opensite(pnlmainsiteappscape, appscapevideoplayerinfopage, "shiftnet.main.appscape/videoplayerinfo.rnp")
    End Sub

    Private Sub btncalculatorinfoback_Click(sender As Object, e As EventArgs) Handles btncalculatorinfoback.Click
        opensite(pnlmainsiteappscape, appscapehomepage, "shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btncalculatorinfo_Click(sender As Object, e As EventArgs) Handles btncalculatorinfo.Click
        opensite(pnlmainsiteappscape, appscapecalculatorinfopage, "shiftnet.main.appscape/calculatorinfo.rnp")
    End Sub

    Private Sub btnwebbrowserinfoback_Click(sender As Object, e As EventArgs) Handles btnwebbrowserinfoback.Click
        opensite(pnlmainsiteappscape, appscapehomepage, "shiftnet.main.appscape/home.rnp")
    End Sub

    Private Sub btnwebbrowserinfo_Click(sender As Object, e As EventArgs) Handles btnwebbrowserinfo.Click
        opensite(pnlmainsiteappscape, appscapewebbrowserinfopage, "shiftnet.main.appscape/webbrowserinfo.rnp")
    End Sub
End Class