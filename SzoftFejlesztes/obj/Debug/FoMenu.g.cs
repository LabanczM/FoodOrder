﻿#pragma checksum "..\..\FoMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4DA498DD805C12BF4AFBC2F73CE85826C4CA38FCE372958EF32C6E6D2A71222"
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
using SzoftFejlesztes;


namespace SzoftFejlesztes {
    
    
    /// <summary>
    /// FoMenu
    /// </summary>
    public partial class FoMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\FoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Menu;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\FoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Rend;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\FoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Fut;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\FoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Stat;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\FoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Out;
        
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
            System.Uri resourceLocater = new System.Uri("/SzoftFejlesztes;component/fomenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FoMenu.xaml"
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
            this.Menu = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\FoMenu.xaml"
            this.Menu.Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Rend = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\FoMenu.xaml"
            this.Rend.Click += new System.Windows.RoutedEventHandler(this.Rend_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Fut = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\FoMenu.xaml"
            this.Fut.Click += new System.Windows.RoutedEventHandler(this.Fut_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Stat = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\FoMenu.xaml"
            this.Stat.Click += new System.Windows.RoutedEventHandler(this.Stat_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Out = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

