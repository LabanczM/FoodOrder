﻿#pragma checksum "..\..\Foods.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C600EC9C5D96987964C6804E7A774F81D397C32578E56EA3859B15F81C208336"
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
    /// Foods
    /// </summary>
    public partial class Foods : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\Foods.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Etel_nev;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Foods.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Etel_ar;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Foods.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Elk_ido;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Foods.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Img;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Foods.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SzoftFejlesztes;component/foods.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Foods.xaml"
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
            this.Etel_nev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Etel_ar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Elk_ido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Img = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\Foods.xaml"
            this.Img.Click += new System.Windows.RoutedEventHandler(this.ImgFood_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Out = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Foods.xaml"
            this.Out.Click += new System.Windows.RoutedEventHandler(this.NewFood_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

