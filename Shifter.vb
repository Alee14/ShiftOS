﻿Public Class Shifter
    Public rolldownsize As Integer
    Public oldbordersize As Integer
    Public oldtitlebarheight As Integer
    Public justopened As Boolean = False
    Public needtorollback As Boolean = False
    Public minimumsizewidth As Integer = 0
    Public minimumsizeheight As Integer = 0

    Public skinlines(200) As String

    Public titlebarcolour As Color
    Public windowbordercolour As Color
    Public windowbordersize As Integer
    Public titlebarheight As Integer
    Public closebuttoncolour As Color
    Public closebuttonheight As Integer
    Public closebuttonwidth As Integer
    Public closebuttonside As Integer
    Public closebuttontop As Integer
    Public titletextcolour As Color
    Public titletexttop As Integer
    Public titletextside As Integer
    Public titletextsize As Integer
    Public titletextfont As String
    Public titletextstyle As FontStyle
    Public desktoppanelcolour As Color
    Public desktopbackgroundcolour As Color
    Public desktoppanelheight As Integer
    Public desktoppanelposition As String
    Public clocktextcolour As Color
    Public clockbackgroundcolor As Color
    Public panelclocktexttop As Integer
    Public panelclocktextsize As Integer
    Public panelclocktextfont As String
    Public panelclocktextstyle As FontStyle
    Public applauncherbuttoncolour As Color
    Public applauncherbuttonclickedcolour As Color
    Public applauncherbackgroundcolour As Color
    Public applaunchermouseovercolour As Color
    Public applicationsbuttontextcolour As Color
    Public applicationbuttonheight As Integer
    Public applicationbuttontextsize As Integer
    Public applicationbuttontextfont As String
    Public applicationbuttontextstyle As FontStyle
    Public applicationlaunchername As String
    Public titletextposition As String
    Public rollupbuttoncolour As Color
    Public rollupbuttonheight As Integer
    Public rollupbuttonwidth As Integer
    Public rollupbuttonside As Integer
    Public rollupbuttontop As Integer
    Public titlebariconside As Integer
    Public titlebaricontop As Integer
    Public showwindowcorners As Boolean
    Public titlebarcornerwidth As Integer
    Public titlebarrightcornercolour As Color
    Public titlebarleftcornercolour As Color
    Public applaunchermenuholderwidth As Integer = 100
    Public windowborderleftcolour As Color
    Public windowborderrightcolour As Color
    Public windowborderbottomcolour As Color
    Public windowborderbottomrightcolour As Color
    Public windowborderbottomleftcolour As Color
    Public panelbuttonicontop As Integer
    Public panelbuttoniconside As Integer
    Public panelbuttoniconsize As Integer
    Public panelbuttonheight As Integer
    Public panelbuttonwidth As Integer
    Public panelbuttoncolour As Color
    Public panelbuttontextcolour As Color
    Public panelbuttontextsize As Integer
    Public panelbuttontextfont As String
    Public panelbuttontextstyle As FontStyle
    Public panelbuttontextside As Integer
    Public panelbuttontexttop As Integer
    Public panelbuttongap As Integer
    Public panelbuttonfromtop As Integer
    Public panelbuttoninitialgap As Integer
    Public minimizebuttoncolour As Color
    Public minimizebuttonheight As Integer
    Public minimizebuttonwidth As Integer
    Public minimizebuttonside As Integer
    Public minimizebuttontop As Integer

    'skins
    Public shifterskinimages(100) As String
    Public skinclosebutton(2) As Image
    Public skinclosebuttonstyle As ImageLayout
    Public shifterskintitlebar(2) As Image
    Public skintitlebarstyle As ImageLayout
    Public skindesktopbackground(2) As Image
    Public skindesktopbackgroundstyle As ImageLayout
    Public skinrollupbutton(2) As Image
    Public skinrollupbuttonstyle As ImageLayout
    Public skintitlebarrightcorner(2) As Image
    Public skintitlebarrightcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skintitlebarleftcorner(2) As Image
    Public skintitlebarleftcornerstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppanel(2) As Image
    Public skindesktoppanelstyle As ImageLayout = ImageLayout.Stretch
    Public skindesktoppaneltime(2) As Image
    Public skindesktoppaneltimestyle As ImageLayout = ImageLayout.Stretch
    Public skinapplauncherbutton(2) As Image
    Public skinapplauncherbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderleft(2) As Image
    Public skinwindowborderleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderright(2) As Image
    Public skinwindowborderrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottom(2) As Image
    Public skinwindowborderbottomstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomright(2) As Image
    Public skinwindowborderbottomrightstyle As ImageLayout = ImageLayout.Stretch
    Public skinwindowborderbottomleft(2) As Image
    Public skinwindowborderbottomleftstyle As ImageLayout = ImageLayout.Stretch
    Public skinpanelbutton(2) As Image
    Public skinpanelbuttonstyle As ImageLayout = ImageLayout.Stretch
    Public skinminimizebutton(2) As Image
    Public skinminimizebuttonstyle As ImageLayout = ImageLayout.Stretch

    Public customizationtimepoints As Integer
    Public customizationsdone As Integer
    Public customizationpointsearned As Integer
    Dim bmp As Bitmap

    Private Sub Template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        justopened = True
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        setskin()
        setupbuttons()
        initialsetup()
        determinevisibleobjects()
        setuppreshifterstuff()
        AddFonts()

        ShiftOSDesktop.pnlpanelbuttonshifter.SendToBack()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setpanelbuttonappearnce(ShiftOSDesktop.pnlpanelbuttonshifter, ShiftOSDesktop.tbshiftericon, ShiftOSDesktop.tbshiftertext, True)
        ShiftOSDesktop.programsopen = ShiftOSDesktop.programsopen + 1

        'Display the shifter intro
        pnlshifterintro.Location = New Point(133, 6)
        pnlshifterintro.Size = New Size(458, 297)
        pnlshifterintro.Show()
        pnlshifterintro.BringToFront()

        'Display window intro
        pnlwindowsintro.Show()
        pnlwindowsintro.Size = New Size(317, 134)
        pnlwindowsintro.Location = New Point(136, 159)
        pnlwindowsintro.BringToFront()

        'Display desktop intro
        pnldesktopintro.Show()
        pnldesktopintro.Size = New Size(317, 134)
        pnldesktopintro.Location = New Point(136, 159)
        pnldesktopintro.BringToFront()
    End Sub

    Public Sub loadclone()
        setuptitlebar()
        setupborders()
        ShiftOSDesktop.setcolours()
        setskin()
        setupbuttons()
        initialsetup()
        determinevisibleobjects()
        setuppreshifterstuff()
        AddFonts()
    End Sub

    Private Sub ShiftOSDesktop_keydown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, btnapplauncher.KeyDown, btnapply.KeyDown, btnborders.KeyDown, btnbuttons.KeyDown, btndesktop.KeyDown, btndesktopitself.KeyDown, btndesktoppanel.KeyDown, btnicons.KeyDown, btnpanelclock.KeyDown, btnprograms.KeyDown, btntitlebar.KeyDown, btntitletext.KeyDown, btnwindows.KeyDown


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
            Me.Size = New Size(600, 339) 'put the default size of your window here
            Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
            Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
            oldbordersize = ShiftOSDesktop.windowbordersize
            oldtitlebarheight = ShiftOSDesktop.titlebarheight
            justopened = False
        Else
            If Me.Visible = True Then
                'Me.Hide()
                Me.Size = New Size(Me.Width, Me.Height - oldtitlebarheight + 30)
                Me.Size = New Size(Me.Width - oldbordersize - oldbordersize, Me.Height - oldbordersize)
                oldbordersize = ShiftOSDesktop.windowbordersize
                oldtitlebarheight = ShiftOSDesktop.titlebarheight
                Me.Size = New Size(Me.Width, Me.Height + ShiftOSDesktop.titlebarheight - 30)
                Me.Size = New Size(Me.Width + ShiftOSDesktop.windowbordersize + ShiftOSDesktop.windowbordersize, Me.Height + ShiftOSDesktop.windowbordersize)
                rolldownsize = Me.Height
                If needtorollback = True Then Me.Height = titlebar.Height : pgleft.Hide() : pgbottom.Hide() : pgright.Hide()
                'Me.Show()
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
            lbtitletext.Text = ShiftOSDesktop.shiftername
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

        If ShiftOSDesktop.boughtshiftericon = True Then
            pnlicon.Visible = True
            pnlicon.Location = New Point(ShiftOSDesktop.titlebariconside, ShiftOSDesktop.titlebaricontop)
            pnlicon.Size = New Size(ShiftOSDesktop.titlebariconsize, ShiftOSDesktop.titlebariconsize)
            pnlicon.Image = ShiftOSDesktop.shiftericontitlebar 'Replace with the correct icon for the program.
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

    Private Sub initialsetup()
        titlebarcolour = ShiftOSDesktop.titlebarcolour
        windowbordercolour = ShiftOSDesktop.windowbordercolour
        windowbordersize = ShiftOSDesktop.windowbordersize
        titlebarheight = ShiftOSDesktop.titlebarheight
        closebuttoncolour = ShiftOSDesktop.closebuttoncolour
        closebuttonheight = ShiftOSDesktop.closebuttonheight
        closebuttonwidth = ShiftOSDesktop.closebuttonwidth
        closebuttontop = ShiftOSDesktop.closebuttontop
        closebuttonside = ShiftOSDesktop.closebuttonside
        titletextcolour = ShiftOSDesktop.titletextcolour
        titletexttop = ShiftOSDesktop.titletexttop
        titletextside = ShiftOSDesktop.titletextside
        titletextsize = ShiftOSDesktop.titletextsize
        titletextfont = ShiftOSDesktop.titletextfont
        titletextstyle = ShiftOSDesktop.titletextstyle
        desktoppanelcolour = ShiftOSDesktop.desktoppanelcolour
        desktopbackgroundcolour = ShiftOSDesktop.desktopbackgroundcolour
        desktoppanelheight = ShiftOSDesktop.desktoppanelheight
        desktoppanelposition = ShiftOSDesktop.desktoppanelposition
        clocktextcolour = ShiftOSDesktop.clocktextcolour
        clockbackgroundcolor = ShiftOSDesktop.clockbackgroundcolor
        panelclocktexttop = ShiftOSDesktop.panelclocktexttop
        panelclocktextsize = ShiftOSDesktop.panelclocktextsize
        panelclocktextfont = ShiftOSDesktop.panelclocktextfont
        panelclocktextstyle = ShiftOSDesktop.panelclocktextstyle
        applauncherbuttoncolour = ShiftOSDesktop.applauncherbuttoncolour
        applauncherbuttonclickedcolour = ShiftOSDesktop.applauncherbuttonclickedcolour
        applauncherbackgroundcolour = ShiftOSDesktop.applauncherbackgroundcolour
        applaunchermouseovercolour = ShiftOSDesktop.applaunchermouseovercolour
        applicationsbuttontextcolour = ShiftOSDesktop.applicationsbuttontextcolour
        applicationbuttonheight = ShiftOSDesktop.applicationbuttonheight
        applicationbuttontextsize = ShiftOSDesktop.applicationbuttontextsize
        applicationbuttontextfont = ShiftOSDesktop.applicationbuttontextfont
        applicationbuttontextstyle = ShiftOSDesktop.applicationbuttontextstyle
        applicationlaunchername = ShiftOSDesktop.applicationlaunchername
        titletextposition = ShiftOSDesktop.titletextposition
        rollupbuttoncolour = ShiftOSDesktop.rollupbuttoncolour
        rollupbuttonheight = ShiftOSDesktop.rollupbuttonheight
        rollupbuttonwidth = ShiftOSDesktop.rollupbuttonwidth
        rollupbuttonside = ShiftOSDesktop.rollupbuttonside
        rollupbuttontop = ShiftOSDesktop.rollupbuttontop
        titlebariconside = ShiftOSDesktop.titlebariconside
        titlebaricontop = ShiftOSDesktop.titlebaricontop
        titlebarcornerwidth = ShiftOSDesktop.titlebarcornerwidth
        titlebarrightcornercolour = ShiftOSDesktop.titlebarrightcornercolour
        titlebarleftcornercolour = ShiftOSDesktop.titlebarleftcornercolour
        showwindowcorners = ShiftOSDesktop.showwindowcorners
        applaunchermenuholderwidth = ShiftOSDesktop.applaunchermenuholderwidth
        windowborderleftcolour = ShiftOSDesktop.windowborderleftcolour
        windowborderrightcolour = ShiftOSDesktop.windowborderrightcolour
        windowborderbottomcolour = ShiftOSDesktop.windowborderbottomcolour
        windowborderbottomrightcolour = ShiftOSDesktop.windowborderbottomrightcolour
        windowborderbottomleftcolour = ShiftOSDesktop.windowborderbottomleftcolour
        panelbuttonicontop = ShiftOSDesktop.panelbuttonicontop
        panelbuttoniconside = ShiftOSDesktop.panelbuttoniconside
        panelbuttoniconsize = ShiftOSDesktop.panelbuttoniconsize
        panelbuttoniconsize = ShiftOSDesktop.panelbuttoniconsize
        panelbuttonheight = ShiftOSDesktop.panelbuttonheight
        panelbuttonwidth = ShiftOSDesktop.panelbuttonwidth
        panelbuttoncolour = ShiftOSDesktop.panelbuttoncolour
        panelbuttontextcolour = ShiftOSDesktop.panelbuttontextcolour
        panelbuttontextsize = ShiftOSDesktop.panelbuttontextsize
        panelbuttontextfont = ShiftOSDesktop.panelbuttontextfont
        panelbuttontextstyle = ShiftOSDesktop.panelbuttontextstyle
        panelbuttontextside = ShiftOSDesktop.panelbuttontextside
        panelbuttontexttop = ShiftOSDesktop.panelbuttontexttop
        panelbuttongap = ShiftOSDesktop.panelbuttongap
        panelbuttonfromtop = ShiftOSDesktop.panelbuttonfromtop
        panelbuttoninitialgap = ShiftOSDesktop.panelbuttoninitialgap
        minimizebuttoncolour = ShiftOSDesktop.minimizebuttoncolour
        minimizebuttonheight = ShiftOSDesktop.minimizebuttonheight
        minimizebuttonwidth = ShiftOSDesktop.minimizebuttonwidth
        minimizebuttonside = ShiftOSDesktop.minimizebuttonside
        minimizebuttontop = ShiftOSDesktop.minimizebuttontop

        'skins
        Array.Copy(ShiftOSDesktop.skinimages, shifterskinimages, shifterskinimages.Length)

        If ShiftOSDesktop.skinclosebutton(0) Is Nothing Then  Else skinclosebutton(0) = ShiftOSDesktop.skinclosebutton(0).Clone
        If ShiftOSDesktop.skinclosebutton(1) Is Nothing Then  Else skinclosebutton(1) = ShiftOSDesktop.skinclosebutton(1).Clone
        If ShiftOSDesktop.skinclosebutton(2) Is Nothing Then  Else skinclosebutton(2) = ShiftOSDesktop.skinclosebutton(2).Clone
        skinclosebuttonstyle = ShiftOSDesktop.skinclosebuttonstyle

        If ShiftOSDesktop.skintitlebar(0) Is Nothing Then  Else shifterskintitlebar(0) = ShiftOSDesktop.skintitlebar(0).Clone
        If ShiftOSDesktop.skintitlebar(1) Is Nothing Then  Else shifterskintitlebar(1) = ShiftOSDesktop.skintitlebar(1).Clone
        If ShiftOSDesktop.skintitlebar(2) Is Nothing Then  Else shifterskintitlebar(2) = ShiftOSDesktop.skintitlebar(2).Clone
        skintitlebarstyle = ShiftOSDesktop.skintitlebarstyle

        If ShiftOSDesktop.skindesktopbackground(0) Is Nothing Then  Else skindesktopbackground(0) = ShiftOSDesktop.skindesktopbackground(0).Clone
        If ShiftOSDesktop.skindesktopbackground(1) Is Nothing Then  Else skindesktopbackground(1) = ShiftOSDesktop.skindesktopbackground(1).Clone
        If ShiftOSDesktop.skindesktopbackground(2) Is Nothing Then  Else skindesktopbackground(2) = ShiftOSDesktop.skindesktopbackground(2).Clone
        skindesktopbackgroundstyle = ShiftOSDesktop.skindesktopbackgroundstyle

        If ShiftOSDesktop.skinrollupbutton(0) Is Nothing Then  Else skinrollupbutton(0) = ShiftOSDesktop.skinrollupbutton(0).Clone
        If ShiftOSDesktop.skinrollupbutton(1) Is Nothing Then  Else skinrollupbutton(1) = ShiftOSDesktop.skinrollupbutton(1).Clone
        If ShiftOSDesktop.skinrollupbutton(2) Is Nothing Then  Else skinrollupbutton(2) = ShiftOSDesktop.skinrollupbutton(2).Clone
        skinrollupbuttonstyle = ShiftOSDesktop.skinrollupbuttonstyle

        If ShiftOSDesktop.skintitlebarrightcorner(0) Is Nothing Then  Else skintitlebarrightcorner(0) = ShiftOSDesktop.skintitlebarrightcorner(0).Clone
        If ShiftOSDesktop.skintitlebarrightcorner(1) Is Nothing Then  Else skintitlebarrightcorner(1) = ShiftOSDesktop.skintitlebarrightcorner(1).Clone
        If ShiftOSDesktop.skintitlebarrightcorner(2) Is Nothing Then  Else skintitlebarrightcorner(2) = ShiftOSDesktop.skintitlebarrightcorner(2).Clone
        skintitlebarrightcornerstyle = ShiftOSDesktop.skintitlebarrightcornerstyle

        If ShiftOSDesktop.skintitlebarleftcorner(0) Is Nothing Then  Else skintitlebarleftcorner(0) = ShiftOSDesktop.skintitlebarleftcorner(0).Clone
        If ShiftOSDesktop.skintitlebarleftcorner(1) Is Nothing Then  Else skintitlebarleftcorner(1) = ShiftOSDesktop.skintitlebarleftcorner(1).Clone
        If ShiftOSDesktop.skintitlebarleftcorner(2) Is Nothing Then  Else skintitlebarleftcorner(2) = ShiftOSDesktop.skintitlebarleftcorner(2).Clone
        skintitlebarleftcornerstyle = ShiftOSDesktop.skintitlebarleftcornerstyle

        If ShiftOSDesktop.skindesktoppanel(0) Is Nothing Then  Else skindesktoppanel(0) = ShiftOSDesktop.skindesktoppanel(0).Clone
        If ShiftOSDesktop.skindesktoppanel(1) Is Nothing Then  Else skindesktoppanel(1) = ShiftOSDesktop.skindesktoppanel(1).Clone
        If ShiftOSDesktop.skindesktoppanel(2) Is Nothing Then  Else skindesktoppanel(2) = ShiftOSDesktop.skindesktoppanel(2).Clone
        skindesktoppanelstyle = ShiftOSDesktop.skindesktoppanelstyle

        If ShiftOSDesktop.skindesktoppaneltime(0) Is Nothing Then  Else skindesktoppaneltime(0) = ShiftOSDesktop.skindesktoppaneltime(0).Clone
        If ShiftOSDesktop.skindesktoppaneltime(1) Is Nothing Then  Else skindesktoppaneltime(1) = ShiftOSDesktop.skindesktoppaneltime(1).Clone
        If ShiftOSDesktop.skindesktoppaneltime(2) Is Nothing Then  Else skindesktoppaneltime(2) = ShiftOSDesktop.skindesktoppaneltime(2).Clone
        skindesktoppaneltimestyle = ShiftOSDesktop.skindesktoppaneltimestyle

        If ShiftOSDesktop.skinapplauncherbutton(0) Is Nothing Then  Else skinapplauncherbutton(0) = ShiftOSDesktop.skinapplauncherbutton(0).Clone
        If ShiftOSDesktop.skinapplauncherbutton(1) Is Nothing Then  Else skinapplauncherbutton(1) = ShiftOSDesktop.skinapplauncherbutton(1).Clone
        If ShiftOSDesktop.skinapplauncherbutton(2) Is Nothing Then  Else skinapplauncherbutton(2) = ShiftOSDesktop.skinapplauncherbutton(2).Clone
        skinapplauncherbuttonstyle = ShiftOSDesktop.skinapplauncherbuttonstyle

        If ShiftOSDesktop.skinwindowborderleft(0) Is Nothing Then  Else skinwindowborderleft(0) = ShiftOSDesktop.skinwindowborderleft(0).Clone
        If ShiftOSDesktop.skinwindowborderleft(1) Is Nothing Then  Else skinwindowborderleft(1) = ShiftOSDesktop.skinwindowborderleft(1).Clone
        If ShiftOSDesktop.skinwindowborderleft(2) Is Nothing Then  Else skinwindowborderleft(2) = ShiftOSDesktop.skinwindowborderleft(2).Clone
        skinwindowborderleftstyle = ShiftOSDesktop.skinwindowborderleftstyle

        If ShiftOSDesktop.skinwindowborderright(0) Is Nothing Then  Else skinwindowborderright(0) = ShiftOSDesktop.skinwindowborderright(0).Clone
        If ShiftOSDesktop.skinwindowborderright(1) Is Nothing Then  Else skinwindowborderright(1) = ShiftOSDesktop.skinwindowborderright(1).Clone
        If ShiftOSDesktop.skinwindowborderright(2) Is Nothing Then  Else skinwindowborderright(2) = ShiftOSDesktop.skinwindowborderright(2).Clone
        skinwindowborderrightstyle = ShiftOSDesktop.skinwindowborderrightstyle

        If ShiftOSDesktop.skinwindowborderbottom(0) Is Nothing Then  Else skinwindowborderbottom(0) = ShiftOSDesktop.skinwindowborderbottom(0).Clone
        If ShiftOSDesktop.skinwindowborderbottom(1) Is Nothing Then  Else skinwindowborderbottom(1) = ShiftOSDesktop.skinwindowborderbottom(1).Clone
        If ShiftOSDesktop.skinwindowborderbottom(2) Is Nothing Then  Else skinwindowborderbottom(2) = ShiftOSDesktop.skinwindowborderbottom(2).Clone
        skinwindowborderbottomstyle = ShiftOSDesktop.skinwindowborderbottomstyle

        If ShiftOSDesktop.skinwindowborderbottomright(0) Is Nothing Then  Else skinwindowborderbottomright(0) = ShiftOSDesktop.skinwindowborderbottomright(0).Clone
        If ShiftOSDesktop.skinwindowborderbottomright(1) Is Nothing Then  Else skinwindowborderbottomright(1) = ShiftOSDesktop.skinwindowborderbottomright(1).Clone
        If ShiftOSDesktop.skinwindowborderbottomright(2) Is Nothing Then  Else skinwindowborderbottomright(2) = ShiftOSDesktop.skinwindowborderbottomright(2).Clone
        skinwindowborderbottomrightstyle = ShiftOSDesktop.skinwindowborderbottomrightstyle

        If ShiftOSDesktop.skinwindowborderbottomleft(0) Is Nothing Then  Else skinwindowborderbottomleft(0) = ShiftOSDesktop.skinwindowborderbottomleft(0).Clone
        If ShiftOSDesktop.skinwindowborderbottomleft(1) Is Nothing Then  Else skinwindowborderbottomleft(1) = ShiftOSDesktop.skinwindowborderbottomleft(1).Clone
        If ShiftOSDesktop.skinwindowborderbottomleft(2) Is Nothing Then  Else skinwindowborderbottomleft(2) = ShiftOSDesktop.skinwindowborderbottomleft(2).Clone
        skinwindowborderbottomleftstyle = ShiftOSDesktop.skinwindowborderbottomleftstyle

        If ShiftOSDesktop.skinpanelbutton(0) Is Nothing Then  Else skinpanelbutton(0) = ShiftOSDesktop.skinpanelbutton(0).Clone
        If ShiftOSDesktop.skinpanelbutton(1) Is Nothing Then  Else skinpanelbutton(1) = ShiftOSDesktop.skinpanelbutton(1).Clone
        If ShiftOSDesktop.skinpanelbutton(2) Is Nothing Then  Else skinpanelbutton(2) = ShiftOSDesktop.skinpanelbutton(2).Clone
        skinpanelbuttonstyle = ShiftOSDesktop.skinpanelbuttonstyle

        If ShiftOSDesktop.skinminimizebutton(0) Is Nothing Then  Else skinminimizebutton(0) = ShiftOSDesktop.skinminimizebutton(0).Clone
        If ShiftOSDesktop.skinminimizebutton(1) Is Nothing Then  Else skinminimizebutton(1) = ShiftOSDesktop.skinminimizebutton(1).Clone
        If ShiftOSDesktop.skinminimizebutton(2) Is Nothing Then  Else skinminimizebutton(2) = ShiftOSDesktop.skinminimizebutton(2).Clone
        skinminimizebuttonstyle = ShiftOSDesktop.skinminimizebuttonstyle
    End Sub

    Public Sub determinevisibleobjects()
        If ShiftOSDesktop.boughttitlebar = True Then pretitlebar.Show() Else pretitlebar.Hide()
        If ShiftOSDesktop.boughtwindowborders = True Then
            prepgright.Show()
            prepgleft.Show()
            prepgbottom.Show()
        Else
            prepgright.Hide()
            prepgleft.Hide()
            prepgbottom.Hide()
        End If
        If ShiftOSDesktop.boughtclosebutton = True Then preclosebutton.Show() Else preclosebutton.Hide()
        If ShiftOSDesktop.boughttitletext = True Then pretitletext.Show() Else pretitletext.Hide()
        If ShiftOSDesktop.boughtdesktoppanel = True Then predesktoppanel.Show() Else predesktoppanel.Hide()
        If ShiftOSDesktop.boughtdesktoppanelclock = True Then prepaneltimetext.Show() Else prepaneltimetext.Hide()
        If ShiftOSDesktop.boughtapplaunchermenu = True Then preapplaunchermenuholder.Show() Else preapplaunchermenuholder.Hide()
        If ShiftOSDesktop.boughtrollupbutton = True Then prerollupbutton.Show() Else prerollupbutton.Hide()
        If ShiftOSDesktop.boughtknowledgeinputicon = True Then prepnlicon.Show() Else prepnlicon.Hide()
        If ShiftOSDesktop.boughtpanelbuttons = True Then prepnlpanelbutton.Show() Else prepnlpanelbutton.Hide()
        If ShiftOSDesktop.boughtminimizebutton = True Then preminimizebutton.Show() Else preminimizebutton.Hide()
    End Sub

    Public Sub setupbuttons()
        If ShiftOSDesktop.boughttitlebar = True Then
            btntitlebar.Text = "Title Bar"
        Else
            btntitlebar.Text = "???"
        End If
        If ShiftOSDesktop.boughttitletext = True Then
            btntitletext.Text = "Title Text"
        Else
            btntitletext.Text = "???"
        End If
        If ShiftOSDesktop.boughtclosebutton = True OrElse ShiftOSDesktop.boughtrollupbutton = True Then
            btnbuttons.Text = "Buttons"
            combobuttonoption.Items.Clear()
            If ShiftOSDesktop.boughtclosebutton = True Then combobuttonoption.Items.Add("Close Button")
            If ShiftOSDesktop.boughtrollupbutton = True Then combobuttonoption.Items.Add("Roll Up Button")
            If ShiftOSDesktop.boughtminimizebutton = True Then combobuttonoption.Items.Add("Minimize Button")
        Else
            btnbuttons.Text = "???"
        End If
        If ShiftOSDesktop.boughtwindowborders = True Then
            btnborders.Text = "Borders"
        Else
            btnborders.Text = "???"
        End If
        If ShiftOSDesktop.boughtdesktoppanel = True Then
            btndesktoppanel.Text = "Desktop Panel"
        Else
            btndesktoppanel.Text = "???"
        End If
        If ShiftOSDesktop.boughtapplaunchermenu = True Then
            btnapplauncher.Text = "App Launcher"
        Else
            btnapplauncher.Text = "???"
        End If
        If ShiftOSDesktop.boughtdesktoppanelclock = True Then
            btnpanelclock.Text = "Panel Clock"
        Else
            btnpanelclock.Text = "???"
        End If
        If ShiftOSDesktop.boughtpanelbuttons = True Then
            btnpanelbuttons.Show()
        Else
            btnpanelbuttons.Hide()
        End If
        If ShiftOSDesktop.boughtknowledgeinputicon Then
            Label78.Show()
            Label79.Show()
            Label80.Show()
            Label81.Show()
            txticonfromside.Show()
            txticonfromtop.Show()
        Else
            Label78.Hide()
            Label79.Hide()
            Label80.Hide()
            Label81.Hide()
            txticonfromside.Hide()
            txticonfromtop.Hide()
        End If
    End Sub

    Public Sub setuppreshifterstuff()
        pretitlebar.BackColor = titlebarcolour
        prepgtoplcorner.BackColor = titlebarcolour
        prepgtoprcorner.BackColor = titlebarcolour
        prepgleft.BackColor = windowborderleftcolour
        prepgright.BackColor = windowborderrightcolour
        prepgbottom.BackColor = windowborderbottomcolour
        prepgbottomlcorner.BackColor = windowborderbottomleftcolour
        prepgbottomrcorner.BackColor = windowborderbottomrightcolour
        pretitlebar.Height = titlebarheight
        preclosebutton.BackColor = closebuttoncolour
        preclosebutton.Height = closebuttonheight
        preclosebutton.Width = closebuttonwidth
        prepgleft.Width = windowbordersize
        prepgright.Width = windowbordersize
        prepgbottom.Height = windowbordersize
        preminimizebutton.BackColor = minimizebuttoncolour
        preminimizebutton.Height = minimizebuttonheight
        preminimizebutton.Width = minimizebuttonwidth
        Select Case titletextposition
            Case "Left"
                pretitletext.Location = New Point(titletextside, titletexttop)
            Case "Centre"
                pretitletext.Location = New Point((pretitlebar.Width / 2) - pretitletext.Width / 2, titletexttop)
        End Select
        pretitletext.ForeColor = titletextcolour

        On Error Resume Next
        pretitletext.Font = New Font(titletextfont, titletextsize, titletextstyle)

        pnldesktoppreview.BackColor = desktopbackgroundcolour
        predesktoppanel.Height = desktoppanelheight
        setclocktime()
        prepaneltimetext.ForeColor = clocktextcolour
        pretimepanel.BackColor = clockbackgroundcolor
        prepaneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
        prepaneltimetext.Location = New Point()
        pretimepanel.Size = New Size(prepaneltimetext.Width + 3, pretimepanel.Height)
        prepaneltimetext.Location = New Point(0, panelclocktexttop)
        ApplicationsToolStripMenuItem.Text = applicationlaunchername
        ApplicationsToolStripMenuItem.Font = New Font(applicationbuttontextfont, applicationbuttontextsize, applicationbuttontextstyle)
        preapplaunchermenuholder.Size = ApplicationsToolStripMenuItem.Size
        ToolStripManager.Renderer = New MyPreviewToolStripRenderer()
        'ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = ShiftOSDesktop.applauncherbuttoncolour
        ApplicationsToolStripMenuItem.BackColor = Color.Transparent
        ApplicationsToolStripMenuItem.ForeColor = applicationsbuttontextcolour
        preapplaunchermenuholder.Height = applicationbuttonheight
        predesktopappmenu.Height = applicationbuttonheight
        ApplicationsToolStripMenuItem.Height = applicationbuttonheight
        prerollupbutton.BackColor = rollupbuttoncolour
        prerollupbutton.Height = rollupbuttonheight
        prerollupbutton.Width = rollupbuttonwidth
        predesktoppanel.BackColor = desktoppanelcolour
        pnldesktoppreview.BackColor = desktopbackgroundcolour
        prepnlicon.Location = New Point(titlebariconside, titlebaricontop)
        prepgtoplcorner.BackColor = titlebarleftcornercolour
        prepgtoprcorner.BackColor = titlebarrightcornercolour
        prepgtoplcorner.Width = titlebarcornerwidth
        prepgtoprcorner.Width = titlebarcornerwidth

        If ShiftOSDesktop.boughtpanelbuttons = True Then prepnlpanelbutton.Show()
        pretbicon.Location = New Point(panelbuttoniconside, panelbuttonicontop)
        pretbicon.Size = New Size(panelbuttoniconsize, panelbuttoniconsize)
        prepnlpanelbutton.Size = New Size(panelbuttonwidth, panelbuttonheight)
        prepnlpanelbutton.BackColor = panelbuttoncolour
        If skinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackgroundImage = skinpanelbutton(0)
        prepnlpanelbutton.BackgroundImageLayout = skinpanelbuttonstyle
        pretbctext.ForeColor = panelbuttontextcolour
        pretbctext.Font = New Font(panelbuttontextfont, panelbuttontextsize, panelbuttontextstyle)
        pretbctext.Location = New Point(panelbuttontextside, panelbuttontexttop)
        prepnlpanelbuttonholder.Padding = New Padding(panelbuttoninitialgap, 0, 0, 0)
        prepnlpanelbutton.Margin = New Padding(0, panelbuttonfromtop, panelbuttongap, 0)
        If skinpanelbutton(0) Is Nothing Then  Else prepnlpanelbutton.BackColor = Color.Transparent

        Select Case desktoppanelposition
            Case "Top"
                predesktoppanel.Dock = DockStyle.Top
                predesktopappmenu.Dock = DockStyle.Top
            Case "Bottom"
                predesktoppanel.Dock = DockStyle.Bottom
                predesktopappmenu.Dock = DockStyle.Bottom
        End Select

        If skindesktoppanel(0) Is Nothing Then
            predesktoppanel.BackColor = desktoppanelcolour
            predesktoppanel.BackgroundImage = Nothing
        Else
            predesktoppanel.BackgroundImage = skindesktoppanel(0)
            predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
            predesktoppanel.BackColor = Color.Transparent
        End If

        If ShiftOSDesktop.boughtdesktoppanelclock = True Then
            setclocktime()
            prepaneltimetext.ForeColor = clocktextcolour
            If skindesktoppaneltime(0) Is Nothing Then
                pretimepanel.BackColor = clockbackgroundcolor
                pretimepanel.BackgroundImage = Nothing
            Else
                pretimepanel.BackColor = Color.Transparent
                If skindesktoppaneltime(0) Is Nothing Then  Else pretimepanel.BackgroundImage = skindesktoppaneltime(0)
                pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
            End If
            prepaneltimetext.Font = New Font(panelclocktextfont, panelclocktextsize, panelclocktextstyle)
            pretimepanel.Size = New Size(prepaneltimetext.Width + 3, pretimepanel.Height)
            prepaneltimetext.Location = New Point(0, panelclocktexttop)
            pretimepanel.Show()
        Else
            pretimepanel.Hide()
        End If

        If showwindowcorners = True Then
            cboxtitlebarcorners.CheckState = CheckState.Checked
        Else
            cboxtitlebarcorners.CheckState = CheckState.Unchecked
        End If

        If cboxtitlebarcorners.CheckState = CheckState.Checked Then
            prepgtoplcorner.Show()
            prepgtoprcorner.Show()
            pnltitlebarleftcornercolour.Show()
            pnltitlebarrightcornercolour.Show()
            txttitlebarcornerwidth.Show()
            lbcornerwidth.Show()
            lbcornerwidthpx.Show()
            lbleftcornercolor.Show()
            lbrightcornercolor.Show()
        Else
            prepgtoplcorner.Hide()
            prepgtoprcorner.Hide()
            pnltitlebarleftcornercolour.Hide()
            pnltitlebarrightcornercolour.Hide()
            txttitlebarcornerwidth.Hide()
            lbcornerwidth.Hide()
            lbcornerwidthpx.Hide()
            lbleftcornercolor.Hide()
            lbrightcornercolor.Hide()
        End If

        If cbindividualbordercolours.CheckState = CheckState.Checked Then
            Label73.Show()
            Label74.Show()
            Label75.Show()
            Label76.Show()
            Label77.Show()
            pnlborderleftcolour.Show()
            pnlborderrightcolour.Show()
            pnlborderbottomcolour.Show()
            pnlborderbottomrightcolour.Show()
            pnlborderbottomleftcolour.Show()
        Else
            Label73.Hide()
            Label74.Hide()
            Label75.Hide()
            Label76.Hide()
            Label77.Hide()
            pnlborderleftcolour.Hide()
            pnlborderrightcolour.Hide()
            pnlborderbottomcolour.Hide()
            pnlborderbottomrightcolour.Hide()
            pnlborderbottomleftcolour.Hide()
        End If

        If ShiftOSDesktop.boughtwindowborders = True Then
            preclosebutton.Location = New Point(pretitlebar.Size.Width - closebuttonside - preclosebutton.Size.Width, closebuttontop)
            prerollupbutton.Location = New Point(pretitlebar.Size.Width - rollupbuttonside - prerollupbutton.Size.Width, rollupbuttontop)
            preminimizebutton.Location = New Point(pretitlebar.Size.Width - minimizebuttonside - preminimizebutton.Size.Width, minimizebuttontop)
        Else
            preclosebutton.Location = New Point(pretitlebar.Size.Width - closebuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - preclosebutton.Size.Width, closebuttontop)
            prerollupbutton.Location = New Point(pretitlebar.Size.Width - rollupbuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - prerollupbutton.Size.Width, rollupbuttontop)
            preminimizebutton.Location = New Point(pretitlebar.Size.Width - minimizebuttonside - prepgtoplcorner.Width - prepgtoprcorner.Width - preminimizebutton.Size.Width, minimizebuttontop)
        End If

        preapplaunchermenuholder.Width = applaunchermenuholderwidth
        predesktopappmenu.Width = applaunchermenuholderwidth
        ApplicationsToolStripMenuItem.Width = applaunchermenuholderwidth

        If skinapplauncherbutton(0) Is Nothing Then
            ApplicationsToolStripMenuItem.BackgroundImage = Nothing
            ApplicationsToolStripMenuItem.BackColor = applauncherbuttoncolour
        Else
            ApplicationsToolStripMenuItem.BackColor = Color.Transparent
            predesktopappmenu.BackColor = Color.Transparent
            ApplicationsToolStripMenuItem.BackgroundImage = skinapplauncherbutton(0)
            ApplicationsToolStripMenuItem.Text = ""
        End If

        pnltitlebarcolour.BackColor = titlebarcolour
        pnlbordercolour.BackColor = windowbordercolour
        pnlclosebuttoncolour.BackColor = closebuttoncolour
        pnltitletextcolour.BackColor = titletextcolour
        pnldesktoppanelcolour.BackColor = desktoppanelcolour
        pnldesktopcolour.BackColor = desktopbackgroundcolour
        pnlpanelclocktextcolour.BackColor = clocktextcolour
        pnlclockbackgroundcolour.BackColor = clockbackgroundcolor
        pnlmaintextcolour.BackColor = applicationsbuttontextcolour
        pnlmainbuttoncolour.BackColor = applauncherbuttoncolour
        pnlmainbuttonactivated.BackColor = applauncherbuttonclickedcolour
        pnlmenuitemscolour.BackColor = applauncherbackgroundcolour
        pnlmenuitemsmouseover.BackColor = applaunchermouseovercolour
        pnlrollupbuttoncolour.BackColor = rollupbuttoncolour
        pnltitlebarleftcornercolour.BackColor = titlebarleftcornercolour
        pnltitlebarrightcornercolour.BackColor = titlebarrightcornercolour
        pnlborderleftcolour.BackColor = windowborderleftcolour
        pnlborderrightcolour.BackColor = windowborderrightcolour
        pnlborderbottomcolour.BackColor = windowborderbottomcolour
        pnlborderbottomrightcolour.BackColor = windowborderbottomrightcolour
        pnlborderbottomleftcolour.BackColor = windowborderbottomleftcolour
        pnlminimizebuttoncolour.BackColor = minimizebuttoncolour
        pnlpanelbuttoncolour.BackColor = panelbuttoncolour
        pnlpanelbuttontextcolour.BackColor = panelbuttontextcolour

        'skins
        preclosebutton.BackgroundImage = skinclosebutton(0)
        preclosebutton.BackgroundImageLayout = skinclosebuttonstyle
        pretitlebar.BackgroundImage = shifterskintitlebar(0)
        pretitlebar.BackgroundImageLayout = skintitlebarstyle
        pnldesktoppreview.BackgroundImage = skindesktopbackground(0)
        pnldesktoppreview.BackgroundImageLayout = skindesktopbackgroundstyle
        pnlmainbuttoncolour.BackgroundImage = skinapplauncherbutton(0)
        pnlmainbuttoncolour.BackgroundImageLayout = skinapplauncherbuttonstyle
        prerollupbutton.BackgroundImage = skinrollupbutton(0)
        prerollupbutton.BackgroundImageLayout = skinrollupbuttonstyle
        prepgtoprcorner.BackgroundImage = skintitlebarrightcorner(0)
        prepgtoprcorner.BackgroundImageLayout = skintitlebarrightcornerstyle
        prepgtoplcorner.BackgroundImage = skintitlebarleftcorner(0)
        prepgtoplcorner.BackgroundImageLayout = skintitlebarleftcornerstyle
        predesktoppanel.BackgroundImage = skindesktoppanel(0)
        predesktoppanel.BackgroundImageLayout = skindesktoppanelstyle
        pretimepanel.BackgroundImage = skindesktoppaneltime(0)
        pretimepanel.BackgroundImageLayout = skindesktoppaneltimestyle
        prepgleft.BackgroundImage = skinwindowborderleft(0)
        prepgleft.BackgroundImageLayout = skinwindowborderleftstyle
        prepgright.BackgroundImage = skinwindowborderright(0)
        prepgright.BackgroundImageLayout = skinwindowborderrightstyle
        prepgbottom.BackgroundImage = skinwindowborderbottom(0)
        prepgbottom.BackgroundImageLayout = skinwindowborderbottomstyle
        prepgbottomlcorner.BackgroundImage = skinwindowborderbottomleft(0)
        prepgbottomlcorner.BackgroundImageLayout = skinwindowborderbottomleftstyle
        prepgbottomrcorner.BackgroundImage = skinwindowborderbottomright(0)
        prepgbottomrcorner.BackgroundImageLayout = skinwindowborderbottomrightstyle
        prepgbottomlcorner.Height = windowbordersize
        prepgbottomrcorner.Height = windowbordersize
        preminimizebutton.BackgroundImage = skinminimizebutton(0)
        preminimizebutton.BackgroundImageLayout = skinminimizebuttonstyle

        'invisible backgrounds
        If preclosebutton.BackgroundImage Is Nothing Then  Else preclosebutton.BackColor = Color.Transparent
        If pretitlebar.BackgroundImage Is Nothing Then  Else pretitlebar.BackColor = Color.Transparent
        If prerollupbutton.BackgroundImage Is Nothing Then  Else prerollupbutton.BackColor = Color.Transparent
        If prepgtoplcorner.BackgroundImage Is Nothing Then  Else prepgtoplcorner.BackColor = Color.Transparent
        If prepgtoprcorner.BackgroundImage Is Nothing Then  Else prepgtoprcorner.BackColor = Color.Transparent
        If prepnlpanelbutton.BackgroundImage Is Nothing Then  Else prepnlpanelbutton.BackColor = Color.Transparent
        If preminimizebutton.BackgroundImage Is Nothing Then  Else preminimizebutton.BackColor = Color.Transparent

        'pallet skins
        pnlclosebuttoncolour.BackgroundImage = skinclosebutton(0)
        pnltitlebarcolour.BackgroundImage = shifterskintitlebar(0)
        pnldesktopcolour.BackgroundImage = skindesktopbackground(0)
        pnlrollupbuttoncolour.BackgroundImage = skinrollupbutton(0)
        pnltitlebarrightcornercolour.BackgroundImage = skintitlebarrightcorner(0)
        pnltitlebarleftcornercolour.BackgroundImage = skintitlebarleftcorner(0)
        pnldesktoppanelcolour.BackgroundImage = skindesktoppanel(0)
        pnlclockbackgroundcolour.BackgroundImage = skindesktoppaneltime(0)
        pnlborderbottomcolour.BackgroundImage = skinwindowborderbottom(0)
        pnlborderleftcolour.BackgroundImage = skinwindowborderleft(0)
        pnlborderrightcolour.BackgroundImage = skinwindowborderright(0)
        pnlborderbottomrightcolour.BackgroundImage = skinwindowborderbottomright(0)
        pnlborderbottomleftcolour.BackgroundImage = skinwindowborderbottomleft(0)
        pnlminimizebuttoncolour.BackgroundImage = skinminimizebutton(0)
        pnlpanelbuttoncolour.BackgroundImage = skinpanelbutton(0)

        txttitlebarheight.Text = titlebarheight
        txtclosebuttonheight.Text = closebuttonheight
        txtclosebuttonwidth.Text = closebuttonwidth
        txtclosebuttonfromtop.Text = closebuttontop
        txtclosebuttonfromside.Text = closebuttonside
        txtbordersize.Text = windowbordersize
        txttitletexttop.Text = titletexttop
        txttitletextside.Text = titletextside
        txttitletextsize.Text = titletextsize
        combotitletextfont.Text = titletextfont
        txtdesktoppanelheight.Text = desktoppanelheight
        combodesktoppanelposition.Text = desktoppanelposition
        comboclocktextfont.Text = panelclocktextfont
        txtclocktextsize.Text = panelclocktextsize
        txtclocktextfromtop.Text = panelclocktexttop
        txtappbuttonlabel.Text = applicationlaunchername
        txtapplicationsbuttonheight.Text = applicationbuttonheight
        txtappbuttontextsize.Text = applicationbuttontextsize
        comboappbuttontextfont.Text = applicationbuttontextfont
        txtrollupbuttonheight.Text = rollupbuttonheight
        txtrollupbuttonwidth.Text = rollupbuttonwidth
        txtrollupbuttontop.Text = rollupbuttontop
        txtrollupbuttonside.Text = rollupbuttonside
        txttitlebarcornerwidth.Text = titlebarcornerwidth
        txtapplauncherwidth.Text = applaunchermenuholderwidth
        txticonfromside.Text = titlebariconside
        txticonfromtop.Text = titlebaricontop
        txtpanelbuttoninitalgap.Text = panelbuttoninitialgap
        txtpanelbuttontop.Text = panelbuttonfromtop
        txtpanelbuttonwidth.Text = panelbuttonwidth
        txtpanelbuttonheight.Text = panelbuttonheight
        txtpanelbuttongap.Text = panelbuttongap
        cbpanelbuttonfont.Text = panelbuttontextfont
        txtpaneltextbuttonsize.Text = panelbuttontextsize
        cbpanelbuttontextstyle.Text = panelbuttontextstyle
        txtpanelbuttontextside.Text = panelbuttontextside
        txtpanelbuttontexttop.Text = panelbuttontexttop
        txtpanelbuttoniconsize.Text = panelbuttoniconsize
        txtpanelbuttoniconsize.Text = panelbuttoniconsize
        txtpanelbuttoniconside.Text = panelbuttoniconside
        txtpanelbuttonicontop.Text = panelbuttonicontop

        txtminimizebuttonheight.Text = minimizebuttonheight
        txtminimizebuttonwidth.Text = minimizebuttonwidth
        txtminimizebuttontop.Text = minimizebuttontop
        txtminimizebuttonside.Text = minimizebuttonside


        Select Case titletextstyle
            Case FontStyle.Bold
                combotitletextstyle.Text = "Bold"
            Case FontStyle.Italic
                combotitletextstyle.Text = "Italic"
            Case FontStyle.Regular
                combotitletextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                combotitletextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                combotitletextstyle.Text = "Underline"
        End Select

        Select Case panelclocktextstyle
            Case FontStyle.Bold
                comboclocktextstyle.Text = "Bold"
            Case FontStyle.Italic
                comboclocktextstyle.Text = "Italic"
            Case FontStyle.Regular
                comboclocktextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                comboclocktextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                comboclocktextstyle.Text = "Underline"
        End Select

        Select Case applicationbuttontextstyle
            Case FontStyle.Bold
                comboappbuttontextstyle.Text = "Bold"
            Case FontStyle.Italic
                comboappbuttontextstyle.Text = "Italic"
            Case FontStyle.Regular
                comboappbuttontextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                comboappbuttontextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                comboappbuttontextstyle.Text = "Underline"
        End Select

        Select Case panelbuttontextstyle
            Case FontStyle.Bold
                cbpanelbuttontextstyle.Text = "Bold"
            Case FontStyle.Italic
                cbpanelbuttontextstyle.Text = "Italic"
            Case FontStyle.Regular
                cbpanelbuttontextstyle.Text = "Regular"
            Case FontStyle.Strikeout
                cbpanelbuttontextstyle.Text = "Strikeout"
            Case FontStyle.Underline
                cbpanelbuttontextstyle.Text = "Underline"
        End Select

        Select Case titletextposition
            Case "Left"
                combotitletextposition.Text = "Left"
            Case "Centre"
                combotitletextposition.Text = "Centre"
        End Select

        If combotitletextposition.Text = "Centre" Then
            txttitletextside.Visible = False
        Else
            txttitletextside.Visible = True
        End If

        customizationsdone = customizationsdone + 1
    End Sub

    Private Sub AddFonts()
        ' Get the installed fonts collection.
        Dim allFonts As New Drawing.Text.InstalledFontCollection

        ' Get an array of the system's font familiies.
        Dim fontFamilies() As FontFamily = allFonts.Families()

        ' Display the font families.
        For Each myFont As FontFamily In fontFamilies
            combotitletextfont.Items.Add(myFont.Name)
            comboclocktextfont.Items.Add(myFont.Name)
            comboappbuttontextfont.Items.Add(myFont.Name)
            cbpanelbuttonfont.Items.Add(myFont.Name)
        Next 'font_family
    End Sub

    Private Sub btnapply_Click(sender As Object, e As EventArgs) Handles btnapply.Click
        If Skin_Loader.Visible = True Then
            infobox.title = "Shifter - Error"
            infobox.textinfo = "It appears that the Skin Loader application is currently open." & Environment.NewLine & Environment.NewLine & "Due to system stability issues you must close it before applying your changes!"
            infobox.Show()
        Else
            applysettings()
        End If

    End Sub

    Public Sub applysettings()
        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        saveskintocurrentskin()

        'quick fixes
        If titlebarheight > 500 Then
            titlebarheight = 500
            txttitlebarheight.Text = "500"
        End If

        If windowbordersize > 500 Then
            windowbordersize = 500
            txtbordersize.Text = "500"
        End If

        If desktoppanelheight > 500 Then
            desktoppanelheight = 500
            txtdesktoppanelheight.Text = "500"
        End If

        ShiftOSDesktop.titlebarcolour = titlebarcolour
        ShiftOSDesktop.windowbordercolour = windowbordercolour
        ShiftOSDesktop.windowbordersize = windowbordersize
        ShiftOSDesktop.titlebarheight = titlebarheight
        ShiftOSDesktop.closebuttoncolour = closebuttoncolour
        ShiftOSDesktop.closebuttonheight = closebuttonheight
        ShiftOSDesktop.closebuttonwidth = closebuttonwidth
        ShiftOSDesktop.closebuttontop = closebuttontop
        ShiftOSDesktop.closebuttonside = closebuttonside
        ShiftOSDesktop.titletextcolour = titletextcolour
        ShiftOSDesktop.titletexttop = titletexttop
        ShiftOSDesktop.titletextside = titletextside
        ShiftOSDesktop.titletextsize = titletextsize
        ShiftOSDesktop.titletextfont = titletextfont
        ShiftOSDesktop.titletextstyle = titletextstyle
        ShiftOSDesktop.desktoppanelcolour = desktoppanelcolour
        ShiftOSDesktop.desktopbackgroundcolour = desktopbackgroundcolour
        ShiftOSDesktop.desktoppanelheight = desktoppanelheight
        ShiftOSDesktop.desktoppanelposition = desktoppanelposition
        ShiftOSDesktop.clocktextcolour = clocktextcolour
        ShiftOSDesktop.clockbackgroundcolor = clockbackgroundcolor
        ShiftOSDesktop.panelclocktexttop = panelclocktexttop
        ShiftOSDesktop.panelclocktextsize = panelclocktextsize
        ShiftOSDesktop.panelclocktextfont = panelclocktextfont
        ShiftOSDesktop.panelclocktextstyle = panelclocktextstyle
        ShiftOSDesktop.applauncherbuttoncolour = applauncherbuttoncolour
        ShiftOSDesktop.applauncherbuttonclickedcolour = applauncherbuttonclickedcolour
        ShiftOSDesktop.applauncherbackgroundcolour = applauncherbackgroundcolour
        ShiftOSDesktop.applaunchermouseovercolour = applaunchermouseovercolour
        ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = Color.Transparent
        ShiftOSDesktop.applicationsbuttontextcolour = applicationsbuttontextcolour
        ShiftOSDesktop.applicationbuttonheight = applicationbuttonheight
        ShiftOSDesktop.applicationbuttontextsize = applicationbuttontextsize
        ShiftOSDesktop.applicationbuttontextfont = applicationbuttontextfont
        ShiftOSDesktop.applicationbuttontextstyle = applicationbuttontextstyle
        ShiftOSDesktop.applicationlaunchername = applicationlaunchername
        ShiftOSDesktop.titletextposition = titletextposition
        ShiftOSDesktop.rollupbuttoncolour = rollupbuttoncolour
        ShiftOSDesktop.rollupbuttonheight = rollupbuttonheight
        ShiftOSDesktop.rollupbuttonwidth = rollupbuttonwidth
        ShiftOSDesktop.rollupbuttonside = rollupbuttonside
        ShiftOSDesktop.rollupbuttontop = rollupbuttontop
        ShiftOSDesktop.titlebariconside = titlebariconside
        ShiftOSDesktop.titlebaricontop = titlebaricontop
        ShiftOSDesktop.showwindowcorners = showwindowcorners
        ShiftOSDesktop.titlebarcornerwidth = titlebarcornerwidth
        ShiftOSDesktop.titlebarrightcornercolour = titlebarrightcornercolour
        ShiftOSDesktop.titlebarleftcornercolour = titlebarleftcornercolour
        ShiftOSDesktop.applaunchermenuholderwidth = applaunchermenuholderwidth
        ShiftOSDesktop.windowborderleftcolour = windowborderleftcolour
        ShiftOSDesktop.windowborderrightcolour = windowborderrightcolour
        ShiftOSDesktop.windowborderbottomcolour = windowborderbottomcolour
        ShiftOSDesktop.windowborderbottomrightcolour = windowborderbottomrightcolour
        ShiftOSDesktop.windowborderbottomleftcolour = windowborderbottomleftcolour
        ShiftOSDesktop.panelbuttonicontop = panelbuttonicontop
        ShiftOSDesktop.panelbuttoniconside = panelbuttoniconside
        ShiftOSDesktop.panelbuttoniconsize = panelbuttoniconsize
        ShiftOSDesktop.panelbuttoniconsize = panelbuttoniconsize
        ShiftOSDesktop.panelbuttonheight = panelbuttonheight
        ShiftOSDesktop.panelbuttonwidth = panelbuttonwidth
        ShiftOSDesktop.panelbuttoncolour = panelbuttoncolour
        ShiftOSDesktop.panelbuttontextcolour = panelbuttontextcolour
        ShiftOSDesktop.panelbuttontextsize = panelbuttontextsize
        ShiftOSDesktop.panelbuttontextfont = panelbuttontextfont
        ShiftOSDesktop.panelbuttontextstyle = panelbuttontextstyle
        ShiftOSDesktop.panelbuttontextside = panelbuttontextside
        ShiftOSDesktop.panelbuttontexttop = panelbuttontexttop
        ShiftOSDesktop.panelbuttongap = panelbuttongap
        ShiftOSDesktop.panelbuttonfromtop = panelbuttonfromtop
        ShiftOSDesktop.panelbuttoninitialgap = panelbuttoninitialgap
        ShiftOSDesktop.minimizebuttoncolour = minimizebuttoncolour
        ShiftOSDesktop.minimizebuttonheight = minimizebuttonheight
        ShiftOSDesktop.minimizebuttonwidth = minimizebuttonwidth
        ShiftOSDesktop.minimizebuttonside = minimizebuttonside
        ShiftOSDesktop.minimizebuttontop = minimizebuttontop

        If shifterskinimages(0) = Nothing Then  Else skinclosebutton(0) = GetImage(shifterskinimages(0))
        If shifterskinimages(1) = Nothing Then  Else skinclosebutton(1) = GetImage(shifterskinimages(1))
        If shifterskinimages(2) = Nothing Then  Else skinclosebutton(2) = GetImage(shifterskinimages(2))
        If shifterskinimages(3) = Nothing Then  Else shifterskintitlebar(0) = GetImage(shifterskinimages(3))
        If shifterskinimages(4) = Nothing Then  Else shifterskintitlebar(1) = GetImage(shifterskinimages(4))
        If shifterskinimages(5) = Nothing Then  Else shifterskintitlebar(2) = GetImage(shifterskinimages(5))
        If shifterskinimages(6) = Nothing Then  Else skindesktopbackground(0) = GetImage(shifterskinimages(6))
        If shifterskinimages(7) = Nothing Then  Else skindesktopbackground(1) = GetImage(shifterskinimages(7))
        If shifterskinimages(8) = Nothing Then  Else skindesktopbackground(2) = GetImage(shifterskinimages(8))
        If shifterskinimages(9) = Nothing Then  Else skinrollupbutton(0) = GetImage(shifterskinimages(9))
        If shifterskinimages(10) = Nothing Then  Else skinrollupbutton(1) = GetImage(shifterskinimages(10))
        If shifterskinimages(11) = Nothing Then  Else skinrollupbutton(2) = GetImage(shifterskinimages(11))
        If shifterskinimages(12) = Nothing Then  Else skintitlebarrightcorner(0) = GetImage(shifterskinimages(12))
        If shifterskinimages(13) = Nothing Then  Else skintitlebarrightcorner(1) = GetImage(shifterskinimages(13))
        If shifterskinimages(14) = Nothing Then  Else skintitlebarrightcorner(2) = GetImage(shifterskinimages(14))
        If shifterskinimages(15) = Nothing Then  Else skintitlebarleftcorner(0) = GetImage(shifterskinimages(15))
        If shifterskinimages(16) = Nothing Then  Else skintitlebarleftcorner(1) = GetImage(shifterskinimages(16))
        If shifterskinimages(17) = Nothing Then  Else skintitlebarleftcorner(2) = GetImage(shifterskinimages(17))
        If shifterskinimages(18) = Nothing Then  Else skindesktoppanel(0) = GetImage(shifterskinimages(18))
        If shifterskinimages(19) = Nothing Then  Else skindesktoppanel(1) = GetImage(shifterskinimages(19))
        If shifterskinimages(20) = Nothing Then  Else skindesktoppanel(2) = GetImage(shifterskinimages(20))
        If shifterskinimages(21) = Nothing Then  Else skindesktoppaneltime(0) = GetImage(shifterskinimages(21))
        If shifterskinimages(22) = Nothing Then  Else skindesktoppaneltime(1) = GetImage(shifterskinimages(22))
        If shifterskinimages(23) = Nothing Then  Else skindesktoppaneltime(2) = GetImage(shifterskinimages(23))
        If shifterskinimages(24) = Nothing Then  Else skinapplauncherbutton(0) = GetImage(shifterskinimages(24))
        If shifterskinimages(25) = Nothing Then  Else skinapplauncherbutton(1) = GetImage(shifterskinimages(25))
        If shifterskinimages(26) = Nothing Then  Else skinapplauncherbutton(2) = GetImage(shifterskinimages(26))
        If shifterskinimages(27) = Nothing Then  Else skinwindowborderleft(0) = GetImage(shifterskinimages(27))
        If shifterskinimages(28) = Nothing Then  Else skinwindowborderleft(1) = GetImage(shifterskinimages(28))
        If shifterskinimages(29) = Nothing Then  Else skinwindowborderleft(2) = GetImage(shifterskinimages(29))
        If shifterskinimages(30) = Nothing Then  Else skinwindowborderright(0) = GetImage(shifterskinimages(30))
        If shifterskinimages(31) = Nothing Then  Else skinwindowborderright(1) = GetImage(shifterskinimages(31))
        If shifterskinimages(32) = Nothing Then  Else skinwindowborderright(2) = GetImage(shifterskinimages(32))
        If shifterskinimages(33) = Nothing Then  Else skinwindowborderbottom(0) = GetImage(shifterskinimages(33))
        If shifterskinimages(34) = Nothing Then  Else skinwindowborderbottom(1) = GetImage(shifterskinimages(34))
        If shifterskinimages(35) = Nothing Then  Else skinwindowborderbottom(2) = GetImage(shifterskinimages(35))
        If shifterskinimages(36) = Nothing Then  Else skinwindowborderbottomright(0) = GetImage(shifterskinimages(36))
        If shifterskinimages(37) = Nothing Then  Else skinwindowborderbottomright(1) = GetImage(shifterskinimages(37))
        If shifterskinimages(38) = Nothing Then  Else skinwindowborderbottomright(2) = GetImage(shifterskinimages(38))
        If shifterskinimages(39) = Nothing Then  Else skinwindowborderbottomleft(0) = GetImage(shifterskinimages(39))
        If shifterskinimages(40) = Nothing Then  Else skinwindowborderbottomleft(1) = GetImage(shifterskinimages(40))
        If shifterskinimages(41) = Nothing Then  Else skinwindowborderbottomleft(2) = GetImage(shifterskinimages(41))
        If shifterskinimages(42) = Nothing Then  Else skinminimizebutton(0) = GetImage(shifterskinimages(42))
        If shifterskinimages(43) = Nothing Then  Else skinminimizebutton(1) = GetImage(shifterskinimages(43))
        If shifterskinimages(44) = Nothing Then  Else skinminimizebutton(2) = GetImage(shifterskinimages(44))
        If shifterskinimages(45) = Nothing Then  Else skinpanelbutton(0) = GetImage(shifterskinimages(45))
        If shifterskinimages(46) = Nothing Then  Else skinpanelbutton(1) = GetImage(shifterskinimages(46))
        If shifterskinimages(47) = Nothing Then  Else skinpanelbutton(2) = GetImage(shifterskinimages(47))

        'skins
        Array.Copy(shifterskinimages, ShiftOSDesktop.skinimages, ShiftOSDesktop.skinimages.Length)

        If skinclosebutton(0) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(0) = skinclosebutton(0).Clone
        If skinclosebutton(1) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(1) = skinclosebutton(1).Clone
        If skinclosebutton(2) Is Nothing Then  Else ShiftOSDesktop.skinclosebutton(2) = skinclosebutton(2).Clone
        ShiftOSDesktop.skinclosebuttonstyle = skinclosebuttonstyle

        If shifterskintitlebar(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(0) = shifterskintitlebar(0).Clone
        If shifterskintitlebar(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(1) = shifterskintitlebar(1).Clone
        If shifterskintitlebar(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebar(2) = shifterskintitlebar(2).Clone
        ShiftOSDesktop.skintitlebarstyle = skintitlebarstyle

        If skindesktopbackground(0) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(0) = skindesktopbackground(0).Clone
        If skindesktopbackground(1) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(1) = skindesktopbackground(1).Clone
        If skindesktopbackground(2) Is Nothing Then  Else ShiftOSDesktop.skindesktopbackground(2) = skindesktopbackground(2).Clone
        ShiftOSDesktop.skindesktopbackgroundstyle = skindesktopbackgroundstyle

        If skinrollupbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(0) = skinrollupbutton(0).Clone
        If skinrollupbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(1) = skinrollupbutton(1).Clone
        If skinrollupbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinrollupbutton(2) = skinrollupbutton(2).Clone
        ShiftOSDesktop.skinrollupbuttonstyle = skinrollupbuttonstyle

        If skintitlebarrightcorner(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(0) = skintitlebarrightcorner(0).Clone
        If skintitlebarrightcorner(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(1) = skintitlebarrightcorner(1).Clone
        If skintitlebarrightcorner(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebarrightcorner(2) = skintitlebarrightcorner(2).Clone
        ShiftOSDesktop.skintitlebarrightcornerstyle = skintitlebarrightcornerstyle

        If skintitlebarleftcorner(0) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(0) = skintitlebarleftcorner(0).Clone
        If skintitlebarleftcorner(1) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(1) = skintitlebarleftcorner(1).Clone
        If skintitlebarleftcorner(2) Is Nothing Then  Else ShiftOSDesktop.skintitlebarleftcorner(2) = skintitlebarleftcorner(2).Clone
        ShiftOSDesktop.skintitlebarleftcornerstyle = skintitlebarleftcornerstyle

        If skindesktoppanel(0) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(0) = skindesktoppanel(0).Clone
        If skindesktoppanel(1) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(1) = skindesktoppanel(1).Clone
        If skindesktoppanel(2) Is Nothing Then  Else ShiftOSDesktop.skindesktoppanel(2) = skindesktoppanel(2).Clone
        ShiftOSDesktop.skindesktoppanelstyle = skindesktoppanelstyle

        If skindesktoppaneltime(0) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(0) = skindesktoppaneltime(0).Clone
        If skindesktoppaneltime(1) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(1) = skindesktoppaneltime(1).Clone
        If skindesktoppaneltime(2) Is Nothing Then  Else ShiftOSDesktop.skindesktoppaneltime(2) = skindesktoppaneltime(2).Clone
        ShiftOSDesktop.skindesktoppaneltimestyle = skindesktoppaneltimestyle

        If skinapplauncherbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(0) = skinapplauncherbutton(0).Clone
        If skinapplauncherbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(1) = skinapplauncherbutton(1).Clone
        If skinapplauncherbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinapplauncherbutton(2) = skinapplauncherbutton(2).Clone
        ShiftOSDesktop.skinapplauncherbuttonstyle = skinapplauncherbuttonstyle

        If skinwindowborderleft(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(0) = skinwindowborderleft(0).Clone
        If skinwindowborderleft(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(1) = skinwindowborderleft(1).Clone
        If skinwindowborderleft(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderleft(2) = skinwindowborderleft(2).Clone
        ShiftOSDesktop.skinwindowborderleftstyle = skinwindowborderleftstyle

        If skinwindowborderright(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(0) = skinwindowborderright(0).Clone
        If skinwindowborderright(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(1) = skinwindowborderright(1).Clone
        If skinwindowborderright(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderright(2) = skinwindowborderright(2).Clone
        ShiftOSDesktop.skinwindowborderrightstyle = skinwindowborderrightstyle

        If skinwindowborderbottom(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(0) = skinwindowborderbottom(0).Clone
        If skinwindowborderbottom(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(1) = skinwindowborderbottom(1).Clone
        If skinwindowborderbottom(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottom(2) = skinwindowborderbottom(2).Clone
        ShiftOSDesktop.skinwindowborderbottomstyle = skinwindowborderbottomstyle

        If skinwindowborderbottomright(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(0) = skinwindowborderbottomright(0).Clone
        If skinwindowborderbottomright(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(1) = skinwindowborderbottomright(1).Clone
        If skinwindowborderbottomright(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomright(2) = skinwindowborderbottomright(2).Clone
        ShiftOSDesktop.skinwindowborderbottomrightstyle = skinwindowborderbottomrightstyle

        If skinwindowborderbottomleft(0) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(0) = skinwindowborderbottomleft(0).Clone
        If skinwindowborderbottomleft(1) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(1) = skinwindowborderbottomleft(1).Clone
        If skinwindowborderbottomleft(2) Is Nothing Then  Else ShiftOSDesktop.skinwindowborderbottomleft(2) = skinwindowborderbottomleft(2).Clone
        ShiftOSDesktop.skinwindowborderbottomleftstyle = skinwindowborderbottomleftstyle

        If skinpanelbutton(0) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(0) = skinpanelbutton(0).Clone
        If skinpanelbutton(1) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(1) = skinpanelbutton(1).Clone
        If skinpanelbutton(2) Is Nothing Then  Else ShiftOSDesktop.skinpanelbutton(2) = skinpanelbutton(2).Clone
        ShiftOSDesktop.skinpanelbuttonstyle = skinpanelbuttonstyle

        If skinminimizebutton(0) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(0) = skinminimizebutton(0).Clone
        If skinminimizebutton(1) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(1) = skinminimizebutton(1).Clone
        If skinminimizebutton(2) Is Nothing Then  Else ShiftOSDesktop.skinminimizebutton(2) = skinminimizebutton(2).Clone
        ShiftOSDesktop.skinminimizebuttonstyle = skinminimizebuttonstyle

        GC.Collect()

        ShiftOSDesktop.setcolours()
        ShiftOSDesktop.setupdesktop()
        ShiftOSDesktop.setuppanelbuttons()
        ShiftOSDesktop.setupalltitlebars()
        ShiftOSDesktop.setupskins()
        ShiftOSDesktop.Invalidate()

        customizationpointsearned = customizationtimepoints
        If customizationsdone < 0 Then customizationpointsearned = customizationpointsearned - Math.Abs(customizationsdone)
        ShiftOSDesktop.codepoints = ShiftOSDesktop.codepoints + customizationpointsearned
        btnapply.Text = "Earned " & customizationpointsearned & " CP"
        btnapply.BackColor = Color.Black
        btnapply.ForeColor = Color.White
        customizationtimepoints = 0
        customizationsdone = 0
        customizationpointsearned = 0
        timerearned.Start()

        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\") Then My.Computer.FileSystem.DeleteDirectory("C:\ShiftOS\Shiftum42\Skins\CurrentCopy\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        loadclone()

        Me.Invalidate()

    End Sub

    Private Function GetImage(ByVal fileName As String) As Bitmap
        Dim ret As Bitmap
        Using img As Image = Image.FromFile(fileName)
            ret = New Bitmap(img)
        End Using
        Return ret
    End Function

    Public Sub saveskintocurrentskin()
        If My.Computer.FileSystem.DirectoryExists("C:\ShiftOS\Shiftum42\Skins\Current\") Then  Else My.Computer.FileSystem.CreateDirectory("C:\ShiftOS\Shiftum42\Skins\Current\")
        My.Computer.FileSystem.CopyDirectory("C:\ShiftOS\Shiftum42\Skins\Current\", "C:\ShiftOS\Shiftum42\Skins\CurrentCopy\")
        ShiftOSDesktop.disposeoldskindata("shifterapply")

        For i = 0 To 50
            If shifterskinimages(i) Is Nothing Then  Else If shifterskinimages(i).Contains("C:\ShiftOS\Shiftum42\Skins\Current\") Then shifterskinimages(i) = shifterskinimages(i).Replace("Current", "CurrentCopy")
        Next

        skinlines(0) = titlebarcolour.ToArgb
        skinlines(1) = windowbordercolour.ToArgb
        skinlines(2) = windowbordersize
        skinlines(3) = titlebarheight
        skinlines(4) = closebuttoncolour.ToArgb
        skinlines(5) = closebuttonheight
        skinlines(6) = closebuttonwidth
        skinlines(7) = closebuttonside
        skinlines(8) = closebuttontop
        skinlines(9) = titletextcolour.ToArgb
        skinlines(10) = titletexttop
        skinlines(11) = titletextside
        skinlines(12) = titletextsize
        skinlines(13) = titletextfont
        skinlines(14) = titletextstyle
        skinlines(15) = desktoppanelcolour.ToArgb
        skinlines(16) = desktopbackgroundcolour.ToArgb
        skinlines(17) = desktoppanelheight
        skinlines(18) = desktoppanelposition
        skinlines(19) = clocktextcolour.ToArgb
        skinlines(20) = clockbackgroundcolor.ToArgb
        skinlines(21) = panelclocktexttop
        skinlines(22) = panelclocktextsize
        skinlines(23) = panelclocktextfont
        skinlines(24) = panelclocktextstyle
        skinlines(25) = applauncherbuttoncolour.ToArgb
        skinlines(26) = applauncherbuttonclickedcolour.ToArgb
        skinlines(27) = applauncherbackgroundcolour.ToArgb
        skinlines(28) = applaunchermouseovercolour.ToArgb
        skinlines(29) = applicationsbuttontextcolour.ToArgb
        skinlines(30) = applicationbuttonheight
        skinlines(31) = applicationbuttontextsize
        skinlines(32) = applicationbuttontextfont
        skinlines(33) = applicationbuttontextstyle
        skinlines(34) = applicationlaunchername
        skinlines(35) = titletextposition
        skinlines(36) = rollupbuttoncolour.ToArgb
        skinlines(37) = rollupbuttonheight
        skinlines(38) = rollupbuttonwidth
        skinlines(39) = rollupbuttonside
        skinlines(40) = rollupbuttontop
        skinlines(41) = titlebariconside
        skinlines(42) = titlebaricontop
        skinlines(43) = showwindowcorners
        skinlines(44) = titlebarcornerwidth
        skinlines(45) = titlebarrightcornercolour.ToArgb
        skinlines(46) = titlebarleftcornercolour.ToArgb
        skinlines(47) = applaunchermenuholderwidth
        skinlines(48) = windowborderleftcolour.ToArgb
        skinlines(49) = windowborderrightcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(50) = windowborderbottomcolour.ToArgb
        skinlines(51) = windowborderbottomrightcolour.ToArgb
        skinlines(52) = windowborderbottomleftcolour.ToArgb
        skinlines(53) = panelbuttonicontop
        skinlines(54) = panelbuttoniconside
        skinlines(55) = panelbuttoniconsize
        skinlines(56) = panelbuttoniconsize
        skinlines(57) = panelbuttonheight
        skinlines(58) = panelbuttonwidth
        skinlines(59) = panelbuttoncolour.ToArgb
        skinlines(60) = panelbuttontextcolour.ToArgb
        skinlines(61) = panelbuttontextsize
        skinlines(62) = panelbuttontextfont
        skinlines(63) = panelbuttontextstyle
        skinlines(64) = panelbuttontextside
        skinlines(65) = panelbuttontexttop
        skinlines(66) = panelbuttongap
        skinlines(67) = panelbuttonfromtop
        skinlines(68) = panelbuttoninitialgap
        skinlines(69) = minimizebuttoncolour.ToArgb
        skinlines(70) = minimizebuttonheight
        skinlines(71) = minimizebuttonwidth
        skinlines(72) = minimizebuttonside
        skinlines(73) = minimizebuttontop

        'convert real locations to currentskin folder
        Dim folderdivider As String = "\"
        For i = 0 To 50
            If shifterskinimages(i) = "" Then
            Else
                If shifterskinimages(i).Contains("\") Then folderdivider = "\" Else folderdivider = "/"
                IO.File.Copy(shifterskinimages(i), "C:\ShiftOS\Shiftum42\Skins\Current\" & shifterskinimages(i).Substring(shifterskinimages(i).LastIndexOf(folderdivider)), True)
                shifterskinimages(i) = "C:\ShiftOS\Shiftum42\Skins\Current\" & shifterskinimages(i).Substring(shifterskinimages(i).LastIndexOf(folderdivider) + 1)
            End If
        Next

        skinlines(100) = shifterskinimages(0)
        skinlines(101) = shifterskinimages(1)
        skinlines(102) = shifterskinimages(2)
        skinlines(103) = shifterskinimages(3)
        skinlines(104) = shifterskinimages(4)
        skinlines(105) = shifterskinimages(5)
        skinlines(106) = shifterskinimages(6)
        skinlines(107) = shifterskinimages(7)
        skinlines(108) = shifterskinimages(8)
        skinlines(109) = shifterskinimages(9)
        skinlines(110) = shifterskinimages(10)
        skinlines(111) = shifterskinimages(11)
        skinlines(112) = shifterskinimages(12)
        skinlines(113) = shifterskinimages(13)
        skinlines(114) = shifterskinimages(14)
        skinlines(115) = shifterskinimages(15)
        skinlines(116) = shifterskinimages(16)
        skinlines(117) = shifterskinimages(17)
        skinlines(118) = shifterskinimages(18)
        skinlines(119) = shifterskinimages(19)
        skinlines(120) = shifterskinimages(20)
        skinlines(121) = shifterskinimages(21)
        skinlines(122) = shifterskinimages(22)
        skinlines(123) = shifterskinimages(23)
        skinlines(124) = shifterskinimages(24)
        skinlines(125) = shifterskinimages(25)
        skinlines(126) = shifterskinimages(26)
        skinlines(127) = shifterskinimages(27)
        skinlines(128) = shifterskinimages(28)
        skinlines(129) = shifterskinimages(29)
        skinlines(130) = shifterskinimages(30)
        skinlines(131) = shifterskinimages(31)
        skinlines(132) = shifterskinimages(32)
        skinlines(133) = shifterskinimages(33)
        skinlines(134) = shifterskinimages(34)
        skinlines(135) = shifterskinimages(35)
        skinlines(136) = shifterskinimages(36)
        skinlines(137) = shifterskinimages(37)
        skinlines(138) = shifterskinimages(38)
        skinlines(139) = shifterskinimages(39)
        skinlines(140) = shifterskinimages(40)
        skinlines(141) = shifterskinimages(41)
        skinlines(142) = shifterskinimages(42)
        skinlines(143) = shifterskinimages(43)
        skinlines(144) = shifterskinimages(44)
        skinlines(145) = shifterskinimages(45)
        skinlines(146) = shifterskinimages(46)
        skinlines(147) = shifterskinimages(47)
        skinlines(148) = shifterskinimages(48)
        skinlines(149) = shifterskinimages(49)
        skinlines(150) = shifterskinimages(50)

        IO.File.WriteAllLines("C:\ShiftOS\Shiftum42\Skins\Current\skindata.dat", skinlines)
    End Sub

    Private Sub setclocktime()
        If ShiftOSDesktop.boughtsplitsecondtime = True Then
            prepaneltimetext.Text = TimeOfDay
        Else
            If ShiftOSDesktop.boughtminuteaccuracytime = True Then
                If Date.Now.Hour < 12 Then
                    prepaneltimetext.Text = TimeOfDay.Hour & ":" & Format(TimeOfDay.Minute, "00") & " AM"
                Else
                    prepaneltimetext.Text = TimeOfDay.Hour - 12 & ":" & Format(TimeOfDay.Minute, "00") & " PM"
                End If
            Else
                If ShiftOSDesktop.boughtpmandam = True Then
                    If Date.Now.Hour < 12 Then
                        prepaneltimetext.Text = TimeOfDay.Hour & " AM"
                    Else
                        prepaneltimetext.Text = TimeOfDay.Hour - 12 & " PM"
                    End If
                Else
                    If ShiftOSDesktop.boughthourspastmidnight = True Then
                        prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60 / 60)
                    Else
                        If ShiftOSDesktop.boughtminutespastmidnight = True Then
                            prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds / 60)
                        Else
                            If ShiftOSDesktop.boughtsecondspastmidnight = True Then
                                prepaneltimetext.Text = Math.Floor(Date.Now.Subtract(Date.Today).TotalSeconds)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub pnlwindowsoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlwindowsoptions.Paint
        'e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlwindowsobjects.ClientRectangle)
    End Sub

    Private Sub catholder_Paint(sender As Object, e As PaintEventArgs) Handles catholder.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), catholder.ClientRectangle)
    End Sub

    Private Sub btnwindows_Click(sender As Object, e As EventArgs) Handles btnwindows.Click
        pnlwindowsoptions.Location = New Point(133, 6)
        pnlwindowsoptions.Size = New Size(458, 297)
        pnlwindowsoptions.Show()
        pnlwindowsoptions.BringToFront()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        pnlreset.Location = New Point(133, 6)
        pnlreset.Size = New Size(458, 297)
        pnlreset.Show()
        pnlreset.BringToFront()
    End Sub

    Private Sub pnltitlebarcolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Colour"
            Colour_Picker.oldcolour = titlebarcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlbordercolour_Click(sender As Object, e As EventArgs) Handles pnlbordercolour.Click
        Colour_Picker.colourtochange = "Window Border Colour"
        Colour_Picker.oldcolour = windowbordercolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlclosebuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlclosebuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Close Button Colour"
            Colour_Picker.oldcolour = closebuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Close Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderrightcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderrightcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Right Colour"
            Colour_Picker.oldcolour = windowborderrightcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Right"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderleftcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderleftcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Left Colour"
            Colour_Picker.oldcolour = windowborderleftcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Left"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Colour"
            Colour_Picker.oldcolour = windowborderbottomcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomleftcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomleftcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Left Colour"
            Colour_Picker.oldcolour = windowborderbottomleftcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom Left"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlborderbottomrightcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlborderbottomrightcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Border Bottom Right Colour"
            Colour_Picker.oldcolour = windowborderbottomrightcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Border Bottom Right"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitletextcolour_click(sender As Object, e As EventArgs) Handles pnltitletextcolour.Click
        Colour_Picker.colourtochange = "Title Text Colour"
        Colour_Picker.oldcolour = titletextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnldesktoppanelcolour_Click(sender As Object, e As MouseEventArgs) Handles pnldesktoppanelcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Desktop Panel Colour"
            Colour_Picker.oldcolour = desktoppanelcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Desktop Panel"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlpanelclocktextcolour_Click(sender As Object, e As EventArgs) Handles pnlpanelclocktextcolour.Click
        Colour_Picker.colourtochange = "Clock Text Colour"
        Colour_Picker.oldcolour = clocktextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlclockbackgroundcolour_Click(sender As Object, e As MouseEventArgs) Handles pnlclockbackgroundcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Clock Background Colour"
            Colour_Picker.oldcolour = clockbackgroundcolor
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Clock Background"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnldesktopcolour_Click(sender As Object, e As MouseEventArgs) Handles pnldesktopcolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Desktop Background Colour"
            Colour_Picker.oldcolour = desktopbackgroundcolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Desktop Background"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmainbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlmainbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "App Launcher Button Colour"
            Colour_Picker.oldcolour = applauncherbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "App Launcher Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmainbuttonactivated_Click(sender As Object, e As EventArgs) Handles pnlmainbuttonactivated.Click
        Colour_Picker.colourtochange = "App Launcher Button Clicked Colour"
        Colour_Picker.oldcolour = applauncherbuttonclickedcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlmenuitemsmouseover_Click(sender As Object, e As EventArgs) Handles pnlmenuitemsmouseover.Click
        Colour_Picker.colourtochange = "App Launcher Mouse Over Colour"
        Colour_Picker.oldcolour = applaunchermouseovercolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlrollupbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlrollupbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Roll Up Button Colour"
            Colour_Picker.oldcolour = rollupbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Roll Up Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlmaintextcolour_Click(sender As Object, e As EventArgs) Handles pnlmaintextcolour.Click
        Colour_Picker.colourtochange = "App Launcher Button Text Colour"
        Colour_Picker.oldcolour = applicationsbuttontextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlpanelbuttontextcolour_Click(sender As Object, e As EventArgs) Handles pnlpanelbuttontextcolour.Click
        Colour_Picker.colourtochange = "Panel Button Text Colour"
        Colour_Picker.oldcolour = panelbuttontextcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnlmenuitemscolour_Click(sender As Object, e As EventArgs) Handles pnlmenuitemscolour.Click
        Colour_Picker.colourtochange = "App Launcher Items Background Colour"
        Colour_Picker.oldcolour = applauncherbackgroundcolour
        Colour_Picker.Show()
    End Sub

    Private Sub pnltitlebarleftcornercolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarleftcornercolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Left Corner Colour"
            Colour_Picker.oldcolour = titlebarleftcornercolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar Left Corner"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitlebarrightcornercolour_Click(sender As Object, e As MouseEventArgs) Handles pnltitlebarrightcornercolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Title Bar Right Corner Colour"
            Colour_Picker.oldcolour = titlebarrightcornercolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Title Bar Right Corner"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlminimizebuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlminimizebuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Minimize Button Colour"
            Colour_Picker.oldcolour = minimizebuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Minimize Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnlpanelbuttoncolour_Click(sender As Object, e As MouseEventArgs) Handles pnlpanelbuttoncolour.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Colour_Picker.colourtochange = "Panel Button Colour"
            Colour_Picker.oldcolour = panelbuttoncolour
            Colour_Picker.Show()
        Else
            If ShiftOSDesktop.boughtskinning = True Then
                Graphic_Picker.graphictochange = "Panel Button"
                Graphic_Picker.Show()
            End If
        End If
    End Sub

    Private Sub pnltitlebarcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarcolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebaroptions_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebaroptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebaroptions.ClientRectangle)
    End Sub

    Private Sub pnlbordercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlbordercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlbordercolour.ClientRectangle)
    End Sub

    Private Sub pnlborderoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderoptions.ClientRectangle)
    End Sub

    Private Sub btntitlebar_Click(sender As Object, e As EventArgs) Handles btntitlebar.Click
        If ShiftOSDesktop.boughtshifttitlebar Then
            pnltitlebaroptions.Show()
            pnltitlebaroptions.Size = New Size(317, 134)
            pnltitlebaroptions.Location = New Point(136, 159)
            pnltitlebaroptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub btnborders_Click(sender As Object, e As EventArgs) Handles btnborders.Click
        If ShiftOSDesktop.boughtshiftborders Then
            pnlborderoptions.Show()
            pnlborderoptions.Size = New Size(317, 134)
            pnlborderoptions.Location = New Point(136, 159)
            pnlborderoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txttitlebarheight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttitlebarheight.KeyPress, txtclosebuttonheight.KeyPress, txtclosebuttonwidth.KeyPress, txtclosebuttonfromtop.KeyPress, txtclosebuttonfromside.KeyPress, txtbordersize.KeyPress, txttitletexttop.KeyPress, txttitletextside.KeyPress, txttitletextsize.KeyPress, txtdesktoppanelheight.KeyPress, txtclocktextsize.KeyPress, txtclocktextfromtop.KeyPress, txtapplicationsbuttonheight.KeyPress, txtappbuttontextsize.KeyPress, txtrollupbuttonheight.KeyPress, txtrollupbuttonwidth.KeyPress, txtrollupbuttontop.KeyPress, txtrollupbuttonside.KeyPress, txttitlebarcornerwidth.KeyPress, txtapplauncherwidth.KeyPress, txticonfromside.KeyPress, txticonfromtop.KeyPress, txtminimizebuttonheight.KeyPress, txtminimizebuttonwidth.KeyPress, txtminimizebuttonside.KeyPress, txtminimizebuttontop.KeyPress, txtpanelbuttoninitalgap.KeyPress, txtpanelbuttontop.KeyPress, txtpanelbuttonwidth.KeyPress, txtpanelbuttonheight.KeyPress, txtpanelbuttongap.KeyPress, txtpaneltextbuttonsize.KeyPress, txtpanelbuttontextside.KeyPress, txtpanelbuttontexttop.KeyPress, txtpanelbuttoniconsize.KeyPress, txtpanelbuttoniconsize.KeyPress, txtpanelbuttoniconside.KeyPress, txtpanelbuttonicontop.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txttitlebarheight_TextChanged(sender As Object, e As EventArgs) Handles txttitlebarheight.TextChanged
        If txttitlebarheight.Text = "" Then
        Else
            titlebarheight = txttitlebarheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btnclosebutton_Click(sender As Object, e As EventArgs) Handles btnbuttons.Click
        If ShiftOSDesktop.boughtshifttitlebuttons Then
            pnlbuttonoptions.Show()
            pnlbuttonoptions.Size = New Size(317, 134)
            pnlbuttonoptions.Location = New Point(136, 159)
            pnlbuttonoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub pnlclosebuttonoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlbuttonoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlbuttonoptions.ClientRectangle)
    End Sub

    Private Sub pnlclosebuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlclosebuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlclosebuttoncolour.ClientRectangle)
    End Sub

    Private Sub txtclosebuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonheight.TextChanged
        If txtclosebuttonheight.Text = "" Then
        Else
            closebuttonheight = txtclosebuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonwidth.TextChanged
        If txtclosebuttonwidth.Text = "" Then
        Else
            closebuttonwidth = txtclosebuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonfromtop_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonfromtop.TextChanged
        If txtclosebuttonfromtop.Text = "" Then
        Else
            closebuttontop = txtclosebuttonfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclosebuttonfromside_TextChanged(sender As Object, e As EventArgs) Handles txtclosebuttonfromside.TextChanged
        If txtclosebuttonfromside.Text = "" Then
        Else
            closebuttonside = txtclosebuttonfromside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtbordersize_TextChanged(sender As Object, e As EventArgs) Handles txtbordersize.TextChanged
        If txtbordersize.Text = "" Then
        Else
            windowbordersize = txtbordersize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btntitletext_Click(sender As Object, e As EventArgs) Handles btntitletext.Click
        If ShiftOSDesktop.boughtshifttitletext Then
            pnltitletextoptions.Show()
            pnltitletextoptions.Size = New Size(317, 134)
            pnltitletextoptions.Location = New Point(136, 159)
            pnltitletextoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txttitletexttop_TextChanged(sender As Object, e As EventArgs) Handles txttitletexttop.TextChanged
        If txttitletexttop.Text = "" Then
        Else
            titletexttop = txttitletexttop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txttitletextside_TextChanged(sender As Object, e As EventArgs) Handles txttitletextside.TextChanged
        If txttitletextside.Text = "" Then
        Else
            titletextside = txttitletextside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub pnltitletextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitletextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitletextcolour.ClientRectangle)
    End Sub

    Private Sub combotitletextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextfont.SelectedIndexChanged
        If combotitletextfont.Text = "" Then
        Else
            titletextfont = combotitletextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub cbpanelbuttonfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpanelbuttonfont.SelectedIndexChanged
        If cbpanelbuttonfont.Text = "" Then
        Else
            panelbuttontextfont = cbpanelbuttonfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub pnltitletextoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnltitletextoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitletextoptions.ClientRectangle)
    End Sub

    Private Sub txttitletextsize_TextChanged(sender As Object, e As EventArgs) Handles txttitletextsize.TextChanged
        If txttitletextsize.Text = "" OrElse txttitletextsize.Text = "0" Then
        Else
            titletextsize = txttitletextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combotitletextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextstyle.SelectedIndexChanged
        Select Case combotitletextstyle.Text
            Case "Bold"
                titletextstyle = FontStyle.Bold
            Case "Italic"
                titletextstyle = FontStyle.Italic
            Case "Regular"
                titletextstyle = FontStyle.Regular
            Case "Strikeout"
                titletextstyle = FontStyle.Strikeout
            Case "Underline"
                titletextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()

    End Sub

    Private Sub btndesktop_Click(sender As Object, e As EventArgs) Handles btndesktop.Click
        pnldesktopoptions.Location = New Point(133, 6)
        pnldesktopoptions.Size = New Size(458, 297)
        pnldesktopoptions.Show()
        pnldesktopoptions.BringToFront()
    End Sub

    Private Sub btndesktoppanel_Click(sender As Object, e As EventArgs) Handles btndesktoppanel.Click
        If ShiftOSDesktop.boughtshiftdesktoppanel Then
            pnldesktoppaneloptions.Show()
            pnldesktoppaneloptions.Size = New Size(317, 134)
            pnldesktoppaneloptions.Location = New Point(136, 159)
            pnldesktoppaneloptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub btnpanelbuttons_Click(sender As Object, e As EventArgs) Handles btnpanelbuttons.Click
        If ShiftOSDesktop.boughtshiftpanelbuttons Then
            pnlpanelbuttonsoptions.Show()
            pnlpanelbuttonsoptions.Size = New Size(317, 134)
            pnlpanelbuttonsoptions.Location = New Point(136, 159)
            pnlpanelbuttonsoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub pnldesktoppanelcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktoppanelcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktoppanelcolour.ClientRectangle)
    End Sub

    Private Sub pnldesktoppaneloptions_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktoppaneloptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktoppaneloptions.ClientRectangle)
    End Sub

    Private Sub pnldesktopbackgroundoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktopbackgroundoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktopbackgroundoptions.ClientRectangle)
    End Sub

    Private Sub pnldesktopcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnldesktopcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnldesktopcolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelclockoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelclockoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelclockoptions.ClientRectangle)
    End Sub

    Private Sub pnlpanelclockcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelclocktextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelclocktextcolour.ClientRectangle)
    End Sub

    Private Sub pnlclockbackgroundcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlclockbackgroundcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlclockbackgroundcolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebarleftcornercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarleftcornercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarleftcornercolour.ClientRectangle)
    End Sub

    Private Sub pnltitlebarrightcornercolour_Paint(sender As Object, e As PaintEventArgs) Handles pnltitlebarrightcornercolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnltitlebarrightcornercolour.ClientRectangle)
    End Sub

    Private Sub pnlapplauncheroptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlapplauncheroptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlapplauncheroptions.ClientRectangle)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles pnlmainbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmainbuttoncolour.ClientRectangle)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlmainbuttonactivated.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmainbuttonactivated.ClientRectangle)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles pnlmenuitemscolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmenuitemscolour.ClientRectangle)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles pnlmenuitemsmouseover.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmenuitemsmouseover.ClientRectangle)
    End Sub

    Private Sub pnlmaintextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlmaintextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlmaintextcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderleftcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderleftcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderleftcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderrightcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderrightcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderrightcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomleftcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomleftcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomleftcolour.ClientRectangle)
    End Sub

    Private Sub pnlborderbottomrightcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlborderbottomrightcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlborderbottomrightcolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttonsoptions_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttonsoptions.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttonsoptions.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttoncolour.ClientRectangle)
    End Sub

    Private Sub pnlpanelbuttontextcolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlpanelbuttontextcolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlpanelbuttontextcolour.ClientRectangle)
    End Sub

    Private Sub btndesktopitself_Click(sender As Object, e As EventArgs) Handles btndesktopitself.Click
        If ShiftOSDesktop.boughtshiftdesktop Then
            pnldesktopbackgroundoptions.Show()
            pnldesktopbackgroundoptions.Size = New Size(317, 134)
            pnldesktopbackgroundoptions.Location = New Point(136, 159)
            pnldesktopbackgroundoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub txtdesktoppanelheight_TextChanged(sender As Object, e As EventArgs) Handles txtdesktoppanelheight.TextChanged
        If txtdesktoppanelheight.Text = "" Then
        Else
            desktoppanelheight = txtdesktoppanelheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combodesktoppanelposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combodesktoppanelposition.SelectedIndexChanged
        Select Case combodesktoppanelposition.Text
            Case "Top"
                desktoppanelposition = "Top"
            Case "Bottom"
                desktoppanelposition = "Bottom"
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub btnpanelclock_Click(sender As Object, e As EventArgs) Handles btnpanelclock.Click
        If ShiftOSDesktop.boughtshiftpanelclock Then
            pnlpanelclockoptions.Show()
            pnlpanelclockoptions.Size = New Size(317, 134)
            pnlpanelclockoptions.Location = New Point(136, 159)
            pnlpanelclockoptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub comboclocktextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboclocktextfont.SelectedIndexChanged
        If comboclocktextfont.Text = "" Then
        Else
            panelclocktextfont = comboclocktextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub comboclocktextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboclocktextstyle.SelectedIndexChanged
        Select Case comboclocktextstyle.Text
            Case "Bold"
                panelclocktextstyle = FontStyle.Bold
            Case "Italic"
                panelclocktextstyle = FontStyle.Italic
            Case "Regular"
                panelclocktextstyle = FontStyle.Regular
            Case "Strikeout"
                panelclocktextstyle = FontStyle.Strikeout
            Case "Underline"
                panelclocktextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub txtclocktextfromtop_TextChanged(sender As Object, e As EventArgs) Handles txtclocktextfromtop.TextChanged
        If txtclocktextfromtop.Text = "" Then
        Else
            panelclocktexttop = txtclocktextfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtclocktextsize_TextChanged(sender As Object, e As EventArgs) Handles txtclocktextsize.TextChanged
        If txtclocktextsize.Text = "" OrElse txtclocktextsize.Text = "0" Then
        Else
            panelclocktextsize = txtclocktextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txttitlebarnornerwidth_TextChanged(sender As Object, e As EventArgs) Handles txttitlebarcornerwidth.TextChanged
        If txttitlebarcornerwidth.Text = "" OrElse txttitlebarcornerwidth.Text = "0" Then
        Else
            titlebarcornerwidth = txttitlebarcornerwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub btnapplauncher_Click(sender As Object, e As EventArgs) Handles btnapplauncher.Click
        If ShiftOSDesktop.boughtshiftapplauncher Then
            pnlapplauncheroptions.Show()
            pnlapplauncheroptions.Size = New Size(317, 134)
            pnlapplauncheroptions.Location = New Point(136, 159)
            pnlapplauncheroptions.BringToFront()
        Else
            infobox.title = "Shifter - Setting not found!"
            infobox.textinfo = "This setting can not be altered due to no system configuration files matching this option." & Environment.NewLine & Environment.NewLine & "The system files required are either corrupt or do not exist!"
            infobox.Show()
        End If
    End Sub

    Private Sub predesktopappmenu_MouseEnter(sender As Object, e As EventArgs) Handles predesktopappmenu.MouseEnter
        Me.Focus()
    End Sub

    Private Sub Shifter_MouseEnter(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.MouseEnter
        ToolStripManager.Renderer = New MyPreviewToolStripRenderer()
        'ShiftOSDesktop.ApplicationsToolStripMenuItem.BackColor = ShiftOSDesktop.applauncherbuttoncolour
    End Sub

    Private Sub txtapplicationsbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtapplicationsbuttonheight.TextChanged
        If txtapplicationsbuttonheight.Text = "" Then
        Else
            If txtapplicationsbuttonheight.Text > desktoppanelheight Then
                infobox.title = "Shifter - Illegal Setting!"
                infobox.textinfo = "The height of the application menu button can not exceed the height of the desktop panel." & Environment.NewLine & Environment.NewLine & "The application menu button height has been automatically reduced."
                infobox.Show()
                txtapplicationsbuttonheight.Text = applicationbuttonheight
            Else
                applicationbuttonheight = txtapplicationsbuttonheight.Text
                setuppreshifterstuff()
            End If
        End If
    End Sub

    Private Sub txtappbuttontextsize_TextChanged(sender As Object, e As EventArgs) Handles txtappbuttontextsize.TextChanged
        If txtappbuttontextsize.Text = "" OrElse txtappbuttontextsize.Text = "0" Then
        Else
            applicationbuttontextsize = txtappbuttontextsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub comboappbuttontextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboappbuttontextstyle.SelectedIndexChanged
        Select Case comboappbuttontextstyle.Text
            Case "Bold"
                applicationbuttontextstyle = FontStyle.Bold
            Case "Italic"
                applicationbuttontextstyle = FontStyle.Italic
            Case "Regular"
                applicationbuttontextstyle = FontStyle.Regular
            Case "Strikeout"
                applicationbuttontextstyle = FontStyle.Strikeout
            Case "Underline"
                applicationbuttontextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub cbpanelbuttontextstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpanelbuttontextstyle.SelectedIndexChanged
        Select Case cbpanelbuttontextstyle.Text
            Case "Bold"
                panelbuttontextstyle = FontStyle.Bold
            Case "Italic"
                panelbuttontextstyle = FontStyle.Italic
            Case "Regular"
                panelbuttontextstyle = FontStyle.Regular
            Case "Strikeout"
                panelbuttontextstyle = FontStyle.Strikeout
            Case "Underline"
                panelbuttontextstyle = FontStyle.Underline
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub comboappbuttontextfont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboappbuttontextfont.SelectedIndexChanged
        If comboappbuttontextfont.Text = "" Then
        Else
            applicationbuttontextfont = comboappbuttontextfont.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtappbuttonlabel_TextChanged(sender As Object, e As EventArgs) Handles txtappbuttonlabel.TextChanged
        If txtappbuttonlabel.Text = "" Then
        Else
            applicationlaunchername = txtappbuttonlabel.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub combotitletextposition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotitletextposition.SelectedIndexChanged
        Select Case combotitletextposition.Text
            Case "Left"
                titletextposition = "Left"
            Case "Centre"
                titletextposition = "Centre"
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub pnlrollupbuttoncolour_Paint(sender As Object, e As PaintEventArgs) Handles pnlrollupbuttoncolour.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), pnlrollupbuttoncolour.ClientRectangle)
    End Sub

    Private Sub combobuttonoption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobuttonoption.SelectedIndexChanged
        Select Case combobuttonoption.Text
            Case "Close Button"
                pnlclosebuttonoptions.Show()
                pnlclosebuttonoptions.BringToFront()
                pnlclosebuttonoptions.Location = New Point(1, 27)
                pnlclosebuttonoptions.Size = New Size(315, 104)
            Case "Roll Up Button"
                pnlrollupbuttonoptions.Show()
                pnlrollupbuttonoptions.BringToFront()
                pnlrollupbuttonoptions.Location = New Point(1, 27)
                pnlrollupbuttonoptions.Size = New Size(315, 104)
            Case "Minimize Button"
                pnlminimizebuttonoptions.Show()
                pnlminimizebuttonoptions.BringToFront()
                pnlminimizebuttonoptions.Location = New Point(1, 27)
                pnlminimizebuttonoptions.Size = New Size(315, 104)
        End Select
        setuppreshifterstuff()
    End Sub

    Private Sub txtrollupbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonheight.TextChanged
        If txtrollupbuttonheight.Text = "" Then
        Else
            rollupbuttonheight = txtrollupbuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonwidth.TextChanged
        If txtrollupbuttonwidth.Text = "" Then
        Else
            rollupbuttonwidth = txtrollupbuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttontop.TextChanged
        If txtrollupbuttontop.Text = "" Then
        Else
            rollupbuttontop = txtrollupbuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtrollupbuttonside_TextChanged(sender As Object, e As EventArgs) Handles txtrollupbuttonside.TextChanged
        If txtrollupbuttonside.Text = "" Then
        Else
            rollupbuttonside = txtrollupbuttonside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtapplauncherwidth_TextChanged(sender As Object, e As EventArgs) Handles txtapplauncherwidth.TextChanged
        If txtapplauncherwidth.Text = "" Then
        Else
            applaunchermenuholderwidth = txtapplauncherwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txticonfromside_TextChanged(sender As Object, e As EventArgs) Handles txticonfromside.TextChanged
        If txticonfromside.Text = "" Then
        Else
            titlebariconside = txticonfromside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txticonfromtop_TextChanged(sender As Object, e As EventArgs) Handles txticonfromtop.TextChanged
        If txticonfromtop.Text = "" Then
        Else
            titlebaricontop = txticonfromtop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonheight.TextChanged
        If txtminimizebuttonheight.Text = "" Then
        Else
            minimizebuttonheight = txtminimizebuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonwidth.TextChanged
        If txtminimizebuttonwidth.Text = "" Then
        Else
            minimizebuttonwidth = txtminimizebuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttontop.TextChanged
        If txtminimizebuttontop.Text = "" Then
        Else
            minimizebuttontop = txtminimizebuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtminimizebuttonside_TextChanged(sender As Object, e As EventArgs) Handles txtminimizebuttonside.TextChanged
        If txtminimizebuttonside.Text = "" Then
        Else
            minimizebuttonside = txtminimizebuttonside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoninitalgap_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoninitalgap.TextChanged
        If txtpanelbuttoninitalgap.Text = "" Then
        Else
            panelbuttoninitialgap = txtpanelbuttoninitalgap.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontop.TextChanged
        If txtpanelbuttontop.Text = "" Then
        Else
            panelbuttonfromtop = txtpanelbuttontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonwidth_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonwidth.TextChanged
        If txtpanelbuttonwidth.Text = "" Then
        Else
            panelbuttonwidth = txtpanelbuttonwidth.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonheight_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonheight.TextChanged
        If txtpanelbuttonheight.Text = "" Then
        Else
            panelbuttonheight = txtpanelbuttonheight.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttongap_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttongap.TextChanged
        If txtpanelbuttongap.Text = "" Then
        Else
            panelbuttongap = txtpanelbuttongap.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpaneltextbuttonsize_TextChanged(sender As Object, e As EventArgs) Handles txtpaneltextbuttonsize.TextChanged
        If txtpaneltextbuttonsize.Text = "" Then
        Else
            panelbuttontextsize = txtpaneltextbuttonsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontextside_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontextside.TextChanged
        If txtpanelbuttontextside.Text = "" Then
        Else
            panelbuttontextside = txtpanelbuttontextside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttontexttop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttontexttop.TextChanged
        If txtpanelbuttontexttop.Text = "" Then
        Else
            panelbuttontexttop = txtpanelbuttontexttop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoniconsize_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoniconsize.TextChanged
        If txtpanelbuttoniconsize.Text = "" Then
        Else
            panelbuttoniconsize = txtpanelbuttoniconsize.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttoniconside_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttoniconside.TextChanged
        If txtpanelbuttoniconside.Text = "" Then
        Else
            panelbuttoniconside = txtpanelbuttoniconside.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub txtpanelbuttonicontop_TextChanged(sender As Object, e As EventArgs) Handles txtpanelbuttonicontop.TextChanged
        If txtpanelbuttonicontop.Text = "" Then
        Else
            panelbuttonicontop = txtpanelbuttonicontop.Text
            setuppreshifterstuff()
        End If
    End Sub

    Private Sub customizationtime_Tick(sender As Object, e As EventArgs) Handles customizationtime.Tick
        If customizationsdone > -10 Then
            customizationtimepoints = customizationtimepoints + 1
            customizationsdone = customizationsdone - 1
        End If
    End Sub

    Private Sub timerearned_Tick(sender As Object, e As EventArgs) Handles timerearned.Tick
        btnapply.Text = "Apply Changes"
        btnapply.BackColor = Color.White
        btnapply.ForeColor = Color.Black
        timerearned.Stop()
    End Sub

    Private Sub cboxtitlebarcorners_CheckedChanged(sender As Object, e As EventArgs) Handles cboxtitlebarcorners.CheckedChanged
        If cboxtitlebarcorners.CheckState = CheckState.Checked Then
            prepgtoplcorner.Show()
            prepgtoprcorner.Show()
            pnltitlebarleftcornercolour.Show()
            pnltitlebarrightcornercolour.Show()
            txttitlebarcornerwidth.Show()
            lbcornerwidth.Show()
            lbcornerwidthpx.Show()
            lbleftcornercolor.Show()
            lbrightcornercolor.Show()
            showwindowcorners = True
        Else
            prepgtoplcorner.Hide()
            prepgtoprcorner.Hide()
            pnltitlebarleftcornercolour.Hide()
            pnltitlebarrightcornercolour.Hide()
            txttitlebarcornerwidth.Hide()
            lbcornerwidth.Hide()
            lbcornerwidthpx.Hide()
            lbleftcornercolor.Hide()
            lbrightcornercolor.Hide()
            showwindowcorners = False
        End If
    End Sub

    Private Sub cbindividualbordercolours_CheckedChanged(sender As Object, e As EventArgs) Handles cbindividualbordercolours.CheckedChanged
        If cbindividualbordercolours.CheckState = CheckState.Checked Then
            Label73.Show()
            Label74.Show()
            Label75.Show()
            Label76.Show()
            Label77.Show()
            pnlborderleftcolour.Show()
            pnlborderrightcolour.Show()
            pnlborderbottomcolour.Show()
            pnlborderbottomrightcolour.Show()
            pnlborderbottomleftcolour.Show()
        Else
            Label73.Hide()
            Label74.Hide()
            Label75.Hide()
            Label76.Hide()
            Label77.Hide()
            pnlborderleftcolour.Hide()
            pnlborderrightcolour.Hide()
            pnlborderbottomcolour.Hide()
            pnlborderbottomrightcolour.Hide()
            pnlborderbottomleftcolour.Hide()
        End If
    End Sub

    Private Sub btnresetallsettings_Click(sender As Object, e As EventArgs) Handles btnresetallsettings.Click
        titlebarcolour = Color.Gray
        windowbordercolour = Color.Gray
        windowbordersize = 2
        titlebarheight = 30
        closebuttoncolour = Color.Black
        closebuttonheight = 22
        closebuttonwidth = 22
        closebuttonside = 5
        closebuttontop = 4
        titletextcolour = Color.White
        titletexttop = 7
        titletextside = 4
        titletextsize = 11
        titletextfont = "Felix Titling"
        titletextstyle = FontStyle.Bold
        desktoppanelcolour = Color.Gray
        desktopbackgroundcolour = Color.Black
        desktoppanelheight = 24
        desktoppanelposition = "Top"
        clocktextcolour = Color.Black
        clockbackgroundcolor = Color.Gray
        panelclocktexttop = 0
        panelclocktextsize = 14
        panelclocktextfont = "Trebuchet MS"
        panelclocktextstyle = FontStyle.Regular
        applauncherbuttoncolour = Color.Gray
        applauncherbuttonclickedcolour = Color.Gray
        applauncherbackgroundcolour = Color.Gray
        applaunchermouseovercolour = Color.Gray
        applicationsbuttontextcolour = Color.Black
        applicationbuttonheight = 24
        applicationbuttontextsize = 10
        applicationbuttontextfont = "Byington"
        applicationbuttontextstyle = FontStyle.Bold
        applicationlaunchername = "Applications"
        titletextposition = "Left"
        rollupbuttoncolour = Color.Black
        rollupbuttonheight = 22
        rollupbuttonwidth = 22
        rollupbuttonside = 32
        rollupbuttontop = 4
        titlebariconside = 8
        titlebaricontop = 8
        showwindowcorners = False
        titlebarcornerwidth = 2
        titlebarrightcornercolour = Color.White
        titlebarleftcornercolour = Color.White
        applaunchermenuholderwidth = 100
        windowborderleftcolour = Color.Gray
        windowborderrightcolour = Color.Gray
        windowborderbottomcolour = Color.Gray
        windowborderbottomrightcolour = Color.Gray
        windowborderbottomleftcolour = Color.Gray
        panelbuttonicontop = 3
        panelbuttoniconside = 4
        panelbuttoniconsize = 16
        panelbuttoniconsize = 16
        panelbuttonheight = 22
        panelbuttonwidth = 186
        panelbuttoncolour = Color.Black
        panelbuttontextcolour = Color.White
        panelbuttontextsize = 10
        panelbuttontextfont = "Microsoft Sans Serif"
        panelbuttontextstyle = FontStyle.Bold
        panelbuttontextside = 22
        panelbuttontexttop = 2
        panelbuttongap = 1
        panelbuttonfromtop = 1
        panelbuttoninitialgap = 5
        minimizebuttoncolour = Color.Black
        minimizebuttonheight = 22
        minimizebuttonwidth = 22
        minimizebuttonside = 59
        minimizebuttontop = 4
        Array.Clear(shifterskinimages, 0, shifterskinimages.Length)
        Array.Clear(skinclosebutton, 0, skinclosebutton.Length)
        skinclosebuttonstyle = ImageLayout.Stretch
        Array.Clear(shifterskintitlebar, 0, shifterskintitlebar.Length)
        skintitlebarstyle = ImageLayout.Stretch
        Array.Clear(skindesktopbackground, 0, skindesktopbackground.Length)
        skindesktopbackgroundstyle = ImageLayout.Stretch
        Array.Clear(skinrollupbutton, 0, skinrollupbutton.Length)
        skinrollupbuttonstyle = ImageLayout.Stretch
        Array.Clear(skintitlebarrightcorner, 0, skintitlebarrightcorner.Length)
        skintitlebarrightcornerstyle = ImageLayout.Stretch
        Array.Clear(skintitlebarleftcorner, 0, skintitlebarleftcorner.Length)
        skintitlebarleftcornerstyle = ImageLayout.Stretch
        Array.Clear(skindesktoppanel, 0, skindesktoppanel.Length)
        skindesktoppanelstyle = ImageLayout.Stretch
        Array.Clear(skindesktoppaneltime, 0, skindesktoppaneltime.Length)
        skindesktoppaneltimestyle = ImageLayout.Stretch
        Array.Clear(skinapplauncherbutton, 0, skinapplauncherbutton.Length)
        skinapplauncherbuttonstyle = ImageLayout.Stretch
        Array.Clear(skinwindowborderleft, 0, skinwindowborderleft.Length)
        skinwindowborderleftstyle = ImageLayout.Stretch
        Array.Clear(skinwindowborderright, 0, skinwindowborderright.Length)
        skinwindowborderrightstyle = ImageLayout.Stretch
        Array.Clear(skinwindowborderbottom, 0, skinwindowborderbottom.Length)
        skinwindowborderbottomstyle = ImageLayout.Stretch
        Array.Clear(skinwindowborderbottomright, 0, skinwindowborderbottomright.Length)
        skinwindowborderbottomrightstyle = ImageLayout.Stretch
        Array.Clear(skinwindowborderbottomleft, 0, skinwindowborderbottomleft.Length)
        skinwindowborderbottomleftstyle = ImageLayout.Stretch
        Array.Clear(skinpanelbutton, 0, skinpanelbutton.Length)
        skinpanelbuttonstyle = ImageLayout.Stretch
        Array.Clear(skinminimizebutton, 0, skinminimizebutton.Length)
        skinminimizebuttonstyle = ImageLayout.Stretch

        'postsettings
        If ShiftOSDesktop.boughtknowledgeinputicon = True Then titletextside = titletextside + 22
        setuppreshifterstuff()
        applysettings()
    End Sub

    'required to fix flashing applauncher button problem
    Public Sub ApplicationsToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles ApplicationsToolStripMenuItem.Paint
        If ApplicationsToolStripMenuItem.BackgroundImage Is Nothing Then
        Else
            e.Graphics.DrawImage(ApplicationsToolStripMenuItem.BackgroundImage, 0, 0, ApplicationsToolStripMenuItem.BackgroundImage.Width, ApplicationsToolStripMenuItem.BackgroundImage.Height)
        End If
    End Sub

    Private Sub tmrfix_Tick(sender As Object, e As EventArgs) Handles tmrfix.Tick



        tmrfix.Stop()
    End Sub
End Class