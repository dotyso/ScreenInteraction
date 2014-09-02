﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "62229629471FEC57AD365CAD4146DD17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ScreenPlayer {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 68 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel dockPanel1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid controlPanel;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ProgressGrid;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider playProgressSlider;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentPositionTime;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock videoAllTime;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stop;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button play;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pause;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider volumeSlider;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement videoScreenMediaElement;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPlayText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ScreenPlayer;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\MainWindow.xaml"
            ((ScreenPlayer.MainWindow)(target)).Closed += new System.EventHandler(this.MainWindow_Closed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dockPanel1 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 6:
            this.controlPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ProgressGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.playProgressSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 77 "..\..\..\MainWindow.xaml"
            this.playProgressSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.playProgressSlider_ValueChanged);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\MainWindow.xaml"
            this.playProgressSlider.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.playProgressSlider_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.currentPositionTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.videoAllTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.stop = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\MainWindow.xaml"
            this.stop.Click += new System.Windows.RoutedEventHandler(this.stop_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.play = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\MainWindow.xaml"
            this.play.Click += new System.Windows.RoutedEventHandler(this.play_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.pause = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\MainWindow.xaml"
            this.pause.Click += new System.Windows.RoutedEventHandler(this.pause_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.volumeSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 15:
            this.videoScreenMediaElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 99 "..\..\..\MainWindow.xaml"
            this.videoScreenMediaElement.MediaOpened += new System.Windows.RoutedEventHandler(this.videoScreenMediaElement_MediaOpened);
            
            #line default
            #line hidden
            
            #line 99 "..\..\..\MainWindow.xaml"
            this.videoScreenMediaElement.MediaEnded += new System.Windows.RoutedEventHandler(this.videoScreenMediaElement_MediaEnded);
            
            #line default
            #line hidden
            return;
            case 16:
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 17:
            this.lblPlayText = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 19 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.playImage_MouseEnter);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.playImage_MouseLeave);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 38 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 58 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
