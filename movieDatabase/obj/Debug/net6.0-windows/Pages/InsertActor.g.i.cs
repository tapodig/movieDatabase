﻿#pragma checksum "..\..\..\..\Pages\InsertActor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59C109A6A25ABA00A175CD717801D40E19C4FD39"
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
    /// InsertActor
    /// </summary>
    public partial class InsertActor : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbActFname;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbActLname;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tcActorGender;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem male;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem femaile;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\InsertActor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btbeszur;
        
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
            System.Uri resourceLocater = new System.Uri("/movieDatabase;component/pages/insertactor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\InsertActor.xaml"
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
            this.tbActFname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbActLname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tcActorGender = ((System.Windows.Controls.TabControl)(target));
            
            #line 18 "..\..\..\..\Pages\InsertActor.xaml"
            this.tcActorGender.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tcActorGender_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.male = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.femaile = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.btbeszur = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Pages\InsertActor.xaml"
            this.btbeszur.Click += new System.Windows.RoutedEventHandler(this.btbeszur_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

