﻿#pragma checksum "..\..\..\..\Pages\InsertConnection.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FEF0C1C93333AF8D7B7F61D98E01EA33044E484"
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
using movieDatabase.Pages;


namespace movieDatabase.Pages {
    
    
    /// <summary>
    /// InsertConnection
    /// </summary>
    public partial class InsertConnection : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Pages\InsertConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgGridMovies;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\InsertConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgGridActors;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\InsertConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbRole;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\InsertConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
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
            System.Uri resourceLocater = new System.Uri("/movieDatabase;component/pages/insertconnection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\InsertConnection.xaml"
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
            this.dgGridMovies = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\..\..\Pages\InsertConnection.xaml"
            this.dgGridMovies.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dgGridMovies_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgGridActors = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\..\Pages\InsertConnection.xaml"
            this.dgGridActors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgGridActors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbRole = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Pages\InsertConnection.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
