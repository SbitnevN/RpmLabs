﻿#pragma checksum "..\..\..\..\..\Application\Controls\ListControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2BC04503D69BAF7A41F2F2DFA1568A0B0F777E74"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SportRent.Application.Controls;
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


namespace SportRent.Application.Controls {
    
    
    /// <summary>
    /// ListControl
    /// </summary>
    public partial class ListControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\Application\Controls\ListControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Data;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Application\Controls\ListControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Application\Controls\ListControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Application\Controls\ListControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SportRent;component/application/controls/listcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Application\Controls\ListControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Data = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\Application\Controls\ListControl.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\Application\Controls\ListControl.xaml"
            this.ChangeButton.Click += new System.Windows.RoutedEventHandler(this.ChangeButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RemoveButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\..\Application\Controls\ListControl.xaml"
            this.RemoveButton.Click += new System.Windows.RoutedEventHandler(this.RemoveButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

