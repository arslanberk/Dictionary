﻿#pragma checksum "..\..\..\Pages\uTest.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FBDFC378B4E162C1EE4CCB8DE2200EFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace Dictionary.Pages {
    
    
    /// <summary>
    /// uTest
    /// </summary>
    public partial class uTest : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label question;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton a1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton a2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton a3;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton a4;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton a5;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cont;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label result;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label error;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\uTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
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
            System.Uri resourceLocater = new System.Uri("/Dictionary;component/pages/utest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\uTest.xaml"
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
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Start = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Pages\uTest.xaml"
            this.Start.Click += new System.Windows.RoutedEventHandler(this.Start_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.question = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.a1 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\..\Pages\uTest.xaml"
            this.a1.Click += new System.Windows.RoutedEventHandler(this.radio);
            
            #line default
            #line hidden
            return;
            case 5:
            this.a2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\..\Pages\uTest.xaml"
            this.a2.Click += new System.Windows.RoutedEventHandler(this.radio);
            
            #line default
            #line hidden
            return;
            case 6:
            this.a3 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\..\Pages\uTest.xaml"
            this.a3.Click += new System.Windows.RoutedEventHandler(this.radio);
            
            #line default
            #line hidden
            return;
            case 7:
            this.a4 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\Pages\uTest.xaml"
            this.a4.Click += new System.Windows.RoutedEventHandler(this.radio);
            
            #line default
            #line hidden
            return;
            case 8:
            this.a5 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Pages\uTest.xaml"
            this.a5.Click += new System.Windows.RoutedEventHandler(this.radio);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cont = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\uTest.xaml"
            this.cont.Click += new System.Windows.RoutedEventHandler(this.continue_click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.result = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.error = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
