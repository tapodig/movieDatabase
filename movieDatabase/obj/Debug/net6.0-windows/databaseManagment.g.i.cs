﻿#pragma checksum "..\..\..\databaseManagment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75273BC5AC4F0C0460F238A1EB4C05AD24D1AD18"
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
using System.Windows.Controls.Ribbon;
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
using movieDatabase;


namespace movieDatabase {
    
    
    /// <summary>
    /// databaseManagment
    /// </summary>
    public partial class databaseManagment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btInsetMovie;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btInsertActor;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btInsertDirector;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btInsertGenres;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem btConnectMovActor;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\databaseManagment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frMain;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/movieDatabase;component/databasemanagment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\databaseManagment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btInsetMovie = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\databaseManagment.xaml"
            this.btInsetMovie.Click += new System.Windows.RoutedEventHandler(this.btInsetMovie_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btInsertActor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\databaseManagment.xaml"
            this.btInsertActor.Click += new System.Windows.RoutedEventHandler(this.btInsertActor_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btInsertDirector = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\databaseManagment.xaml"
            this.btInsertDirector.Click += new System.Windows.RoutedEventHandler(this.btInsertDirector_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btInsertGenres = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\databaseManagment.xaml"
            this.btInsertGenres.Click += new System.Windows.RoutedEventHandler(this.btInsertGenres_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btConnectMovActor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\..\databaseManagment.xaml"
            this.btConnectMovActor.Click += new System.Windows.RoutedEventHandler(this.btConnectMovActor_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.frMain = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

