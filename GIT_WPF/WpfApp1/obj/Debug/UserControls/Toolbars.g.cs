﻿#pragma checksum "..\..\..\UserControls\Toolbars.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3FD73CF3758BB82550973765DF43142E134AAA06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WpfApp1.UserControls;


namespace WpfApp1.UserControls {
    
    
    /// <summary>
    /// Toolbars
    /// </summary>
    public partial class Toolbars : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenNewProjectBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RescanBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetBtn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PushBtn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UserControls\Toolbars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PullBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/usercontrols/toolbars.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Toolbars.xaml"
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
            this.OpenNewProjectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\UserControls\Toolbars.xaml"
            this.OpenNewProjectBtn.Click += new System.Windows.RoutedEventHandler(this.OpenNewProjectBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RescanBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.ResetBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.PushBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.PullBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

